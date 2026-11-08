# Space Factory Boot Guide

Read [AGENTS.md](AGENTS.md) first. This file gives the current starting point and routes a new session to the next bounded task. [The roadmap](docs/roadmap.md) owns Phase/Gate status; [development setup](docs/development.md) owns setup commands and bootstrap verification.

## Product premise

Space Factory is a single-player, top-down 2D survival and automation game. One engineer starts aboard a stranded ship, restores its internal factory, and uses the resulting supplies to operate the ship. The larger design includes exploration, landings, hostile inhabitants, persistent surface factories, and permanent run failure. [The decision register](docs/decisions-and-questions.md) distinguishes confirmed requirements from working designs and open questions.

The immediate playable target is a spaceship moving on screen because its internal factory supplies propulsion. Plan toward that small observable milestone while retaining the broader game direction in the existing system documents.

## Current starting point — 2026-11-08

The bootstrap is committed. The baseline inspected for this workflow import is [Space Factory `536cfd08`](https://github.com/jfin602/space-factory/commit/536cfd08da06f119e91d8a4f8865b4508be2e579). This identifies the inspected source, not a revision to reset to; inspect current HEAD and local work at each session.

| Area | Current state |
| --- | --- |
| Engine and language | Godot 4.7.2 .NET with C# and the Compatibility renderer. |
| SDK | .NET SDK 10.0.403 in `game/global.json`; `Godot.NET.Sdk/4.7.2` and `net10.0` in `game/SpaceFactory.csproj`. |
| Playable sandbox | `game/scenes/main.tscn` composes a drawn deck/grid, bounded engineer movement, camera, and instructions. Movement uses WASD or arrow keys. |
| Developer tooling | `tools/dev` exposes inspection, import, C# build, runtime smoke, saved-scene automation, editor, play, and export commands. |
| Recorded Linux evidence | Development setup records successful build/check, scene automation, visible movement, and Linux export/launch on Linux Mint. Those are prior bootstrap results, not new runtime checks performed by this documentation import. |
| Windows and macOS | Export presets exist. Their exports and target-OS runs remain unverified in the recorded baseline. |
| Gameplay systems | Factory production, powered ship flight, travel, combat, saves, and outposts remain planned. The visible grid is not an implemented factory placement system. |
| Roadmap | G0.1 remains IN PROGRESS under its existing criteria; G0.2 and subsequent Gates remain NOT STARTED. No Gate is qualified by importing these workflow files. |

## Next development scope

Use the existing [roadmap](docs/roadmap.md), [factory design](docs/systems/factory-and-resources.md), [ship design](docs/systems/ship-and-navigation.md), and current source to prepare a bounded phase plan for the first factory-powered flight playtest. The plan should identify the smallest production-to-propulsion loop and its visible acceptance criteria. Recipe quantities, controls, and other unresolved choices should be resolved only as that task requires them.

The current roadmap also describes the later integrated expedition and outpost slice. Keep that longer destination distinct from the early flight milestone. Detailed execution stacks for the new milestone have not been authored by this import.

## Repository responsibilities

| Location | Responsibility |
| --- | --- |
| [AGENTS.md](AGENTS.md) | Contributor instructions and bounded document routing. |
| [MODULES.md](MODULES.md) | Current code responsibilities and clearly labeled future boundaries. |
| `game/` | Godot project, C# gameplay, scenes, and isolated scene-automation helpers. |
| `tools/` | Existing developer CLI and ignored local executable configuration. |
| [docs/README.md](docs/README.md) | Product/system documentation index and ownership. |
| [docs/workflow.md](docs/workflow.md) | Documentation, planning, implementation, validation, and closeout process. |
| [docs/planning/](docs/planning/README.md) | Phase and task design as work is planned. |
| [docs/tasks/](docs/tasks/README.md) | Executable task briefs and source-bound execution evidence. |
| [docs/decisions/](docs/decisions/README.md) | Detailed durable decision records when needed; the existing decision register remains the status index. |
| [known-issues.md](known-issues.md) / [feature-ideas.md](feature-ideas.md) | Defect reports and proposed enhancements with stable IDs. |
| `artifacts/` | Ignored generated logs and exports; retain necessary qualification evidence before cleanup. |

## Start a session

1. Confirm the request, repository identity, current revision, and existing changes. Preserve local work.
2. Find the relevant Phase/Gate or direct task and its actual current state.
3. Read the narrow source/documents needed, including any active task handoff. Keep decisions, assumptions, and evidence separate.
4. Use the existing [development commands](docs/development.md#commands) for the task. Check local readiness when the environment is unknown or changed.
5. Execute the authorized scope, record focused evidence, and leave a precise next step if a material blocker remains.

Keep this guide short. Update current routing after a real milestone or closeout; preserve detailed history in linked task records rather than accumulating dated banners here.
