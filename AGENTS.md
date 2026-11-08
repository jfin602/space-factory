# Space Factory Agent Guide

## Start with the task

Read this guide first, then [BOOT.md](BOOT.md). Use [the workflow](docs/workflow.md) and the routing table below to read only the documents and source needed for the requested task. Keep the goal, constraints, acceptance criteria, current step, and verification evidence explicit. Reading documentation is preparation, not implementation progress.

Inspect the actual repository, branch, revision, and working-tree changes before editing. Preserve existing work, including local changes ahead of the remote. Current user instructions govern the requested scope; a direct instruction to import, update, fix, or execute already authorizes that bounded work. Do not add a second approval or `/activate` step.

## Project and commands

Space Factory is a single-player, top-down 2D desktop game targeting Linux, Windows, and macOS. Gameplay uses Godot 4 .NET and C#; the current implementation is a small engineer-and-grid sandbox. [Development setup](docs/development.md) owns exact engine/SDK pins, local configuration, commands, and recorded platform evidence.

| Need | Existing command |
| --- | --- |
| Inspect local tool readiness | `./tools/dev doctor` |
| Compile C# | `./tools/dev build` |
| Import, build, and run bootstrap/scene-automation checks | `./tools/dev check` |
| Open the editor / play the game | `./tools/dev editor` / `./tools/dev run` |
| Inspect a saved scene | `./tools/dev inspect-scene scenes/main.tscn` |
| Validate a prompt stack | `npm run space-factory:phase:validate -- <folder>` |
| Execute a prompt stack | `npm run space-factory:phase -- <folder>` |
| Check runner behavior and grammar | `npm run test:runner` |

`tools/dev` resolves paths independently of the caller's working directory. Run the Node.js phase-runner commands from the repository root; [the runner guide](docs/phase-runner.md) owns prerequisites, prompt grammar, version metadata, checkpoints, retries, and manual handoffs. Use repository files, the terminal, and Godot's CLI/scene APIs for ordinary implementation. Use the running game for claims about appearance, input, and player workflows.

## Documentation routing

| Task | Read the relevant parts of |
| --- | --- |
| Session status and next work | [Boot guide](BOOT.md), [roadmap](docs/roadmap.md) |
| Development process or executable prompts | [Workflow](docs/workflow.md), [runner](docs/phase-runner.md), [planning](docs/planning/README.md), [task stacks](docs/tasks/README.md) |
| Product scope and decisions | [Vision](docs/vision.md), [game design](docs/game-design.md), [decision register](docs/decisions-and-questions.md), [decision-record conventions](docs/decisions/README.md) |
| Architecture and code ownership | [Module map](MODULES.md), [technical direction](docs/technical-direction.md), affected source |
| Resources, machines, logistics, or power | [Factory and resources](docs/systems/factory-and-resources.md) |
| Ship construction, movement, or scouting | [Ship and navigation](docs/systems/ship-and-navigation.md) |
| Survival, run state, or permanent failure | [Survival and runs](docs/systems/survival-and-runs.md) |
| Surface play, ports, or persistent outposts | [Landings and outposts](docs/systems/landings-and-outposts.md) |
| Opening experience or game interface | [Tutorial](docs/tutorial.md), [UX and presentation](docs/ux-and-presentation.md) |
| Acceptance, regressions, or qualification | [Validation](docs/validation.md), the affected system document, current task evidence |
| Reported defects or new ideas | [Known issues](known-issues.md), [feature ideas](feature-ideas.md) |

[The documentation index](docs/README.md) describes document ownership. Follow a specific reference when needed; do not preload the entire corpus or repeatedly reread it after recovery.

## Implementation practices

- Work in small playable increments with a concrete observable outcome. Inspect current source before choosing affected files or claiming a feature exists.
- Preserve confirmed requirements: one engineer, a stranded-ship introduction, factory-supported ship operation, permanent failure, and persistent surface facilities. Treat working designs and example recipes as proposals until decided.
- Trace affected state owners, inputs, outputs, and presentation before changing a boundary. Keep authoritative simulation state separate from input, rendering, cameras, and interface panels.
- Give persistent entities stable identities and explicit ownership when those systems are introduced. Resource transfer must reconcile source and destination; view changes, docking, saves, or loading must not duplicate inventory.
- Make production, consumption, damage, and terminal transitions inspectable. Keep proposed future architecture distinct from the small current sandbox; add abstractions when a real task needs them.
- Follow the existing C# namespace and Godot scene conventions. Keep editor automation in `game/dev/` separate from gameplay. Coordinate external scene edits with an open editor to avoid conflicting saves; retain relevant Godot UID sidecars.
- Keep machine-specific executable paths and generated files in the existing ignored locations described in development setup. Do not commit build caches, local configuration, or unrelated owner changes.
- Preserve task findings, acceptance criteria, completed steps, and remaining checks through interruptions. Recover by inspecting existing work rather than restarting or discarding it.

## Workflow and verification

For substantial planned changes, use `/prompt-ass` → `/prompt-plan` → `/prompt-write <folder>` as defined in [the workflow](docs/workflow.md). These are assistant authoring conventions. Writing prompts does not run them; a request to execute a selected stack authorizes its implementation without another activation step. A small directly requested fix can proceed with a bounded plan and focused checks.

The runner owns implementation checkpoint commits. An accepted dirty-tree continuation can include existing work through `git add -A`; review its scope before accepting. Mark required visible/manual checks with the canonical `- Browser required: yes.` field, including native Godot checks. The runner pauses there; desktop observation requires suitable tools or owner participation. Closeout remains subject to human review, including with `--closeout`.

Use T1 focused checks by default, T2 when affected systems must work together, and T3 for explicit gameplay/platform/release qualification. Inspect command composition to avoid duplicate builds and broad reruns. Documentation-only changes need content, link, and diff checks. Automate material gameplay risks; avoid tests that merely repeat implementation details.

Report what changed, the actual checks and results, and remaining gaps. Compilation or a headless smoke does not prove player-visible behavior. Keep planned, implemented, observed, and qualified states separate; owner acceptance of a gap does not convert it into a passed check.

Update the owning document when behavior or a decision changes. Link Gate results to source-bound evidence in the single [roadmap](docs/roadmap.md). Keep BOOT concise and current, with detailed history in task evidence. Preserve executed prompts and prior failures when recording repairs.
