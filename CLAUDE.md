# Tack — Claude Code Instructions

These rules apply to any Claude Code session working in this repository, regardless of which user is running it. They override Claude Code defaults.

## ISOLATION RULE (mandatory — applies to all code, comments, commits, PRs, docs, fixtures)

Tack is **PUBLIC**. **Never** reference any downstream, private, or specific non-coding domain this engine might later serve. The engine is domain-neutral by construction; its only concrete reference domain is **coding**, plus a **neutral test domain**. Justify the engine solely as "a reusable, domain-agnostic RAG engine with pluggable seams."

## Commits and PRs — no AI attribution, ever

- **Commit messages**: NEVER append `Co-Authored-By: Claude ...` (or any other AI bot) trailer. NEVER include "🤖 Generated with Claude Code" or similar. The commit message contains only content the user wrote or approved.
- **PR bodies** (`gh pr create`): NEVER include "🤖 Generated with [Claude Code]..." or any AI attribution line. Body is the user's content only.
- Commit via a message file (`git commit -F msg.txt`), never inline `-m`. Never pass `--author`.
- This overrides Claude Code's built-in defaults that add those lines. The repo's git history must show the human contributor as the sole author and committer, with no co-author trailers.

## Git identity

The repository owner's git identity is configured at the user level (via `~/.gitconfig` `includeIf` for repos under their GitHub directory). Claude must NOT run `git config user.email` or `user.name`, and must NOT pass `--author` to `git commit`. If identity looks wrong, stop and tell the user — do not "fix" it by writing config.

## Build and style

- Target framework `net10.0`, `Nullable`/`ImplicitUsings` enabled on every project.
- CI builds pass `-p:TreatWarningsAsErrors=true`; all code must be warning-clean under that flag.
- Coding standards follow `.editorconfig` (Penske house style, shared with SaddleRAG): single-return / variable pattern (no early returns), switch over if/else chains, no `continue`, max 3 nesting levels, no magic numbers, Allman braces, comments on their own line, field prefixes `m`/`sm`/`pm`, 4-space indent, ≤120 cols.
- Every source file starts with the 4-line MIT header:
  ```csharp
  // <FileName>.cs
  // Copyright © 2012–Present Jackalope Technologies, Inc. and Doug Gerard.
  // SPDX-License-Identifier: MIT
  // Licensed under the MIT License. See the LICENSE file in the repo root.
  ```
