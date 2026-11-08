# Space Factory Boot Guide

Read [AGENTS.md](AGENTS.md) first. This file gives the current starting point and routes a new session to the next bounded task. [The roadmap](docs/roadmap.md) owns Phase/Gate status; [development setup](docs/development.md) owns setup commands and bootstrap verification.

## Product premise

Space Factory is a single-player, top-down 2D survival and automation game. One engineer starts aboard a stranded ship, restores its internal factory, and uses the resulting supplies to operate the ship. The larger design includes exploration, landings, hostile inhabitants, persistent surface factories, and permanent run failure. [The decision register](docs/decisions-and-questions.md) distinguishes confirmed requirements from working designs and open questions.

The accepted immediate target is [M1 — First Factory-Powered Flight](docs/roadmap.md#milestone-m1-first-factory-powered-flight): prepare the small onboard factory, manufacture propellant, take the helm, and fly to a beacon. Its five implementation Phases retain the broader game direction in the existing system documents.

## Current starting point — 2026-11-08

The bootstrap is committed. The baseline inspected for this workflow import is [Space Factory `536cfd08`](https://github.com/jfin602/space-factory/commit/536cfd08da06f119e91d8a4f8865b4508be2e579). This identifies the inspected source, not a revision to reset to; inspect current HEAD and local work at each session.

| Area | Current state |
| --- | --- |
| Engine and language | Godot 4.7.2 .NET with C# and the Compatibility renderer. |
| SDK | .NET SDK 10.0.403 in `game/global.json`; `Godot.NET.Sdk/4.7.2` and `net10.0` in `game/SpaceFactory.csproj`. |
| Playable sandbox | `game/scenes/main.tscn` composes a drawn deck/grid, bounded engineer movement, camera, and instructions. Movement uses WASD or arrow keys. |
| Developer tooling | `tools/dev` exposes inspection, import, C# build, runtime smoke, saved-scene automation, editor, play, and export commands. |
| Phase runner | Node.js 24 tooling is ported from Dope with `npm run space-factory:phase` and `space-factory:phase:validate`. Root package version `0.1.0` prepares the authored `p1` stack's development checkpoint baseline; it is independent of engine/SDK versions and does not record gameplay completion. See [the runner guide](docs/phase-runner.md). |
| Recorded Linux evidence | Development setup records successful build/check, scene automation, visible movement, and Linux export/launch on Linux Mint. Those are prior bootstrap results, not new runtime checks performed by this documentation import. |
| Windows and macOS | Export presets exist. Their exports and target-OS runs remain unverified in the recorded baseline. |
| Gameplay systems | Factory production, powered ship flight, travel, combat, saves, and outposts remain planned. The visible grid is not an implemented factory placement system. |
| Roadmap | The M1 plan is accepted; all M1 Phases/Gates remain NOT STARTED and their gameplay checks NOT OBSERVED. G0.1 remains IN PROGRESS; G0.2 and subsequent broader Gates retain their unqualified status. Plan adoption and the runner port do not qualify gameplay. |

## Next development scope

The next scope is **M1-P1 — A coherent ship**, covering ship-local interior ownership, deck-relative engineer bounds, a stationary world reference, and nearby helm interaction with exclusive Walking/Piloting modes. Its [p1 execution stack](docs/tasks/p1/README.md), [assessment](docs/tasks/p1/prompt-assessment.md), and [implementation plan](docs/tasks/p1/implementation-plan.md) are authored and unrun. Read the selected [roadmap Gates](docs/roadmap.md#m1-p1-a-coherent-ship) and current source, then execute the requested stack in order when implementation is authorized.

Validate with `npm run space-factory:phase:validate -- p1`. The execution command is `npm run space-factory:phase -- p1`: three implementation/integration prompts precede P4's required native-game checkpoint and sole closeout. P4 uses the canonical manual-handoff field and must be completed in an interactive session with native tools or owner observations. All M1 gameplay statuses remain unqualified.

The adopted M1 factory is finite ice → solar-powered processor → player-installed pipe → propellant tank → engine. Manual fixed-orientation four-direction flight and coasting are scoped prototype choices. Quantities, timings, speed, exact bindings, and presentation tuning remain task-level choices. [The decision register](docs/decisions-and-questions.md#accepted-m1-prototype-decisions) records their scope.

The accepted plan was added against remote `main` at [7a5b1b55](https://github.com/jfin602/space-factory/commit/7a5b1b55acca2fe21d64790c56cd081e4cb8aed8), after the workflow import. The p1 stack was assessed at [295f2056](https://github.com/jfin602/space-factory/commit/295f205657527a2545b47ba3b47a5fbfb154608c) and reconciled with the [a6b77498 runner port](https://github.com/jfin602/space-factory/commit/a6b77498d6319e65a9f49520e509b51083a7d9e1). Inspect current HEAD and preserve newer work. Only M1-P1's stack is authored; later M1 stacks and the expedition/outpost roadmap remain future work. No gameplay stack has been executed by this authoring update.

## Repository responsibilities

| Location | Responsibility |
| --- | --- |
| [AGENTS.md](AGENTS.md) | Contributor instructions and bounded document routing. |
| [MODULES.md](MODULES.md) | Current code responsibilities and clearly labeled future boundaries. |
| `game/` | Godot project, C# gameplay, scenes, and isolated scene-automation helpers. |
| `tools/` | Existing developer CLI and ignored local executable configuration. |
| `scripts/`, `test/unit/`, root `package.json` | Node.js phase-runner CLI/core/validator, runner tests, and development checkpoint metadata. |
| [docs/README.md](docs/README.md) | Product/system documentation index and ownership. |
| [docs/workflow.md](docs/workflow.md) | Documentation, planning, implementation, validation, and closeout process. |
| [docs/phase-runner.md](docs/phase-runner.md) | Runner commands, prompt grammar, checkpoints, version rules, and manual handoffs. |
| [docs/planning/](docs/planning/README.md) | Phase and task design as work is planned. |
| [docs/tasks/](docs/tasks/README.md) | Executable task briefs and source-bound execution evidence. |
| [docs/decisions/](docs/decisions/README.md) | Detailed durable decision records when needed; the existing decision register remains the status index. |
| [known-issues.md](known-issues.md) / [feature-ideas.md](feature-ideas.md) | Defect reports and proposed enhancements with stable IDs. |
| `artifacts/` | Ignored generated logs and exports; retain necessary qualification evidence before cleanup. |
| `.codex-runs/` | Ignored runner status, event logs, final responses, and checkpoint-message artifacts. |

## Start a session

1. Confirm the request, repository identity, current revision, and existing changes. Preserve local work.
2. Find the relevant Phase/Gate or direct task and its actual current state.
3. Read the narrow source/documents needed, including any active task handoff. Keep decisions, assumptions, and evidence separate.
4. Use the existing [development commands](docs/development.md#commands) for the task. Check local readiness when the environment is unknown or changed.
5. Execute the authorized scope, record focused evidence, and leave a precise next step if a material blocker remains.

Keep this guide short. Update current routing after a real milestone or closeout; preserve detailed history in linked task records rather than accumulating dated banners here.
