# Space Factory

A planned 2D, top-down survival and automation game about one engineer keeping a spaceship alive through its internal factory. The repository now includes a small Godot 4 .NET development sandbox. Factory production, combat, travel, saves, and outposts remain future work.

The game begins with a stranded ship that the engineer repairs. Later expeditions will involve planetary landings, hostile inhabitants, and persistent surface facilities. A run can end permanently.

## Start here

- [Current state and session boot](BOOT.md)
- [Development setup and commands](docs/development.md)
- [Documentation index](docs/README.md)
- [Development workflow](docs/workflow.md)
- [Phase runner](docs/phase-runner.md)
- [Development roadmap](docs/roadmap.md)
- [Decisions and open questions](docs/decisions-and-questions.md)
- [Agent and contributor guide](AGENTS.md)
- [Code responsibilities](MODULES.md)

Run `./tools/dev doctor` to inspect the local setup and `./tools/dev check` to validate the sandbox. Use `./tools/dev editor` to open it in Godot and `./tools/dev run` to play it.

## Phase runner

The Dope Node.js runner is available under Space Factory command names. From the repository root, with Node.js 24 and a locally installed/authenticated Codex CLI:

```bash
npm run space-factory:phase:validate -- <folder>
npm run space-factory:phase -- <folder>
```

Choose an authored folder under `docs/tasks/`; no implementation stack is bundled with this port. No npm install is needed. The runner preserves model selection, capacity retries, Git checkpoints/resume, dirty-tree handling, and manual handoffs. `--verbose` shows detailed output; `--closeout` can execute the final closeout while retaining human review. See [the runner guide](docs/phase-runner.md) for prompt templates, version rules, prerequisites, and Godot GUI handoffs. Run `npm run test:runner` for its tests.

## Project layout

| Location | Purpose |
| --- | --- |
| `game/` | Godot project, C# scripts, scenes, and isolated scene automation. |
| `tools/` | Developer command entry point and ignored machine-local configuration. |
| `scripts/`, `test/unit/` | Node.js phase runner, prompt validator, and runner tests. |
| `package.json` | Private development tooling commands and roadmap/checkpoint version metadata. |
| [docs/](docs/README.md) | Game design, system contracts, roadmap, development, and validation. |
| [docs/planning/](docs/planning/README.md) | Phase designs and scoped planning documents. |
| [docs/tasks/](docs/tasks/README.md) | Assessments, implementation plans, executable prompts, and evidence. |
| [docs/decisions/](docs/decisions/README.md) | Detailed durable decisions, linked from the existing decision register. |
| [known-issues.md](known-issues.md) / [feature-ideas.md](feature-ideas.md) | Reported defects and proposed enhancements. |
| `artifacts/` | Ignored generated logs and exports. |
| `.codex-runs/` | Ignored runner execution records and Codex output. |

The workflow follows the useful agent/planning conventions from Dope, adapted to this game's existing structure. Start new work with `AGENTS.md` and `BOOT.md`; keep Phase/Gate progress in the single `docs/roadmap.md`.
