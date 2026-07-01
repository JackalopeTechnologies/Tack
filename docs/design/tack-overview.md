# Tack — Architecture Overview

Tack is a reusable, domain-agnostic RAG (retrieval-augmented generation) engine
with pluggable seams. It ingests a corpus, indexes it for hybrid retrieval, and
serves it over the Model Context Protocol (MCP). Everything domain-specific is
supplied by a **domain module** plugged in at host composition; the engine
itself makes no assumptions about what it is indexing.

## Pipeline

Ingestion is a five-stage pipeline. Each stage is driven by seam interfaces so a
domain can replace behavior without forking the engine:

```
crawl ──► classify/chunk ──► embed ──► store ──► serve (MCP)
```

1. **Crawl** — an `ISourceCrawler` (selected by an `ISourceCrawlerRegistry`)
   fetches pages from a source (web, a source-control host, and so on) into
   normalized page records.
2. **Classify / chunk** — a classifier assigns each page a `ContentCategory`;
   an `ICategoryRegistry` maps the category to an `IChunkingStrategy` that
   splits the page into chunks. An `IEntityExtractor` optionally enriches each
   chunk with domain entities.
3. **Embed** — an `IEmbeddingProvider` turns chunk text into vectors.
4. **Store** — chunks, vectors, and their metadata are persisted through
   repository seams (the default implementation is MongoDB).
5. **Serve** — an MCP host exposes retrieval tools. `search_docs` runs hybrid
   retrieval (vector + BM25), optionally reranks, and delegates final ordering
   to the active `IRetrievalRanker`.

## Packages

Tack ships as seven NuGet packages under the `Jackalope.Tack.*` id prefix (root
namespace `Tack.*`):

| Package | Namespace root | Responsibility |
|---|---|---|
| `Jackalope.Tack.Core` | `Tack.Core` | Neutral records, enums, and every seam interface. All DTOs a seam references live here so no package depends on a package that depends on it. |
| `Jackalope.Tack.Storage.Mongo` | `Tack.Storage.Mongo` | MongoDB persistence: db context, repositories, class maps, indexes. |
| `Jackalope.Tack.Inference.Local` | `Tack.Inference.Local` | Local inference providers (ONNX + Ollama) for classification and embeddings. |
| `Jackalope.Tack.Search` | `Tack.Search` | Vector search, BM25, reranking, and the default retrieval ranker. |
| `Jackalope.Tack.Sources.Web` | `Tack.Sources.Web` | Web and source-control crawlers over a browser-driven page crawler. |
| `Jackalope.Tack.Pipeline` | `Tack.Pipeline` | The ingestion orchestrator and its five stages, driven entirely by Core seams. |
| `Jackalope.Tack.Mcp` | `Tack.Mcp` | MCP host builder, domain-scoped tool registration, and the general (domain-neutral) tools. |

## Domains

A **domain module** (`IDomainModule`) registers a domain's seam implementations
into DI at host composition: its category registry, chunking strategies,
classifier prompt provider, entity extractor, retrieval ranker, and any
domain-scoped MCP tools. Multiple domains can be composed into one host; MCP
tools tagged with a domain register only when that domain is active, while
unattributed tools are general and always registered.

Tack's reference domain is **coding** (indexing software documentation), plus a
neutral test domain used by the engine's own tests. The engine is neutral by
construction — adding a new domain means writing a module, never editing the
engine.

## Persistence and compatibility

Records carry a `Version` and a pluggable `DomainKind` (persisted as a string,
defaulting to the coding domain when absent). Domain-specific fields on shared
records are optional; the engine never assumes them present. Domains that do not
version their corpus use a sentinel version value.
