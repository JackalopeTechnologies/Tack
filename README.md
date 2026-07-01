# Tack

A reusable, domain-agnostic RAG engine with pluggable seams: crawl → classify/chunk → embed → store → serve over MCP.

Tack is split into seven NuGet packages under the `Jackalope.Tack.*` id prefix (root namespace `Tack.*`):

| Package | Responsibility |
|---|---|
| `Jackalope.Tack.Core` | Neutral records, enums, and the seam interfaces every other package depends on. |
| `Jackalope.Tack.Storage.Mongo` | MongoDB persistence: db context, repositories, class-map registration, indexes. |
| `Jackalope.Tack.Inference.Local` | Local inference providers (ONNX + Ollama) for classification and embeddings. |
| `Jackalope.Tack.Search` | Vector search, BM25, and reranking. |
| `Jackalope.Tack.Sources.Web` | Source crawlers (web + GitHub) over a Playwright page crawler. |
| `Jackalope.Tack.Pipeline` | The ingestion orchestrator and its stages, driven entirely by Core seams. |
| `Jackalope.Tack.Mcp` | MCP host builder, domain-scoped tool registration, and general tools. |

See [docs/design/tack-overview.md](docs/design/tack-overview.md) for the architecture.

Licensed under the [MIT License](LICENSE).
