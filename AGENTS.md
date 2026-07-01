# Tack — Codex / Agent Instructions

These rules apply to any Codex (or other AI-agent) session working in this repository, regardless of which user is running it. They override agent defaults.

## ISOLATION RULE (mandatory — applies to all code, comments, commits, PRs, docs, fixtures)

Tack is **PUBLIC**. **Never** reference any downstream, private, or specific non-coding domain this engine might later serve. The engine is domain-neutral by construction; its only concrete reference domain is **coding**, plus a **neutral test domain**. Justify the engine solely as "a reusable, domain-agnostic RAG engine with pluggable seams."

## Commits and PRs — no AI attribution, ever

- **Commit messages**: NEVER append `Co-Authored-By: Codex ...` (or any other AI bot) trailer. NEVER include "🤖 Generated with Codex" or similar. The commit message contains only content the user wrote or approved.
- **PR bodies** (`gh pr create`): NEVER include "🤖 Generated with [Codex]..." or any AI attribution line. Body is the user's content only.
- Commit via a message file (`git commit -F msg.txt`), never inline `-m`. Never pass `--author`.
- This overrides agent built-in defaults that add those lines. The repo's git history must show the human contributor as the sole author and committer, with no co-author trailers.

## Git identity

The repository owner's git identity is configured at the user level (via `~/.gitconfig` `includeIf` for repos under their GitHub directory). The agent must NOT run `git config user.email` or `user.name`, and must NOT pass `--author` to `git commit`. If identity looks wrong, stop and tell the user — do not "fix" it by writing config.
