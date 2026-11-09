# Space Factory Boot Guide

Read [AGENTS.md](AGENTS.md) first. This file gives the current starting point and routes a new session to the next bounded task. [The roadmap](docs/roadmap.md) owns Phase/Gate status; [development setup](docs/development.md) owns setup commands and bootstrap verification.

## Product premise

Space Factory is a single-player, top-down 2D survival and automation game. One engineer starts aboard a stranded ship, restores its internal factory, and uses the resulting supplies to operate the ship. The larger design includes exploration, landings, hostile inhabitants, persistent surface factories, and permanent run failure. [The decision register](docs/decisions-and-questions.md) distinguishes confirmed requirements from working designs and open questions.

The accepted immediate target is [M1 — First Factory-Powered Flight](docs/roadmap.md#milestone-m1-first-factory-powered-flight): prepare the small onboard factory, manufacture propellant, take the helm, and fly to a beacon. Its five implementation Phases retain the broader game direction in the existing system documents.

## Current starting point — 2026-11-09

The bootstrap and qualified M1-P1 ship/helm are committed on `main` at [f274c896](https://github.com/jfin602/space-factory/commit/f274c89630a6033ccd79ad98b7fee6369dd5778a). [The p1 closeout](docs/tasks/p1/closeout.md) preserves the original source-bound runtime/native evidence. Inspect current HEAD and local work rather than resetting to an earlier revision.

The owner reports **M1-P2 ran and is complete** and requested the [M1-P3 prompt stack](docs/tasks/p3/README.md). The published source inspected for that authoring, [ce163753](https://github.com/jfin602/space-factory/commit/ce163753d8973ccd018f2344c6175c52fe4b113d), still contains P1 gameplay plus pixel art and the authored P2 tasks; completed P2 code and qualification records are not yet present there. Use the completed owner checkout and [P3 preflight](docs/tasks/p3/preflight.md) to reconcile its real source before execution. Do not replay P2 or infer missing native evidence.

| Area | Current state |
| --- | --- |
| Engine and language | Godot 4.7.2 .NET with C# and the Compatibility renderer. |
| SDK | .NET SDK 10.0.403 in `game/global.json`; `Godot.NET.Sdk/4.7.2` and `net10.0` in `game/SpaceFactory.csproj`. |
| Published gameplay source | `game/scenes/main.tscn` composes the ship-local pixel-art deck, engineer, and helm; world beacon; camera; and overlay. WASD/arrows walk and nearby **E** enters/leaves Piloting. Propulsion remains unavailable. The [starter art pack](docs/art/starter-pack.md) includes machinery variants for factory integration. Actual completed P2 owners must be located in the owner checkout. |
| Developer tooling | `tools/dev` exposes inspection, import, C# build, runtime smoke, saved-scene automation, editor, play, and export commands. |
| Phase runner | Node.js 24 tooling provides `space-factory:phase` and `space-factory:phase:validate`. Published root version remains `0.2.0`; the new [p3 stack](docs/tasks/p3/README.md) requires deliberate `0.3.0` preparation in the completed P2 checkout before running. Authoring does not change gameplay or engine/SDK pins. See [the runner guide](docs/phase-runner.md). |
| Recorded Linux evidence | [P1–P3 implementation evidence](docs/tasks/p1/qualification/implementation.md) records actual-scene checks. [P4 native evidence](docs/tasks/p1/qualification/native-playtest.md) records visible ship, movement, helm, unpowered feedback, and the spatial fixture on Linux Mint. Bootstrap build/export evidence remains in [development setup](docs/development.md). |
| Windows and macOS | Export presets exist. Their exports and target-OS runs remain unverified in the recorded baseline. |
| Gameplay systems | P2 preparation is owner-reported complete with source synchronization pending. Timed production, powered flight, travel, combat, saves, and outposts remain future work. The art grid is not a general placement system. |
| Roadmap | M1-P1 is COMPLETE with selected Gates PASS. M1-P2 is owner-reported complete; its published qualification remains pending. M1-P3 is authored, NOT EXECUTED; M1-P4/P5 remain future work. Broader G0/G1 results are unchanged. |

## Next development scope

The next requested gameplay scope is **M1-P3 — Manufacture propellant**. Its [assessment, implementation plan, preparation brief, and six prompts](docs/tasks/p3/README.md) are authored, not executed. They add one timed recipe, installed solar electricity, one shared production/delivery clock, bounded flow/backpressure, Start/Stop controls, and actual state feedback. Preserve the completed P2 inventories, interaction owner, and installed connection.

Validate grammar with `npm run space-factory:phase:validate -- p3`. Before execution, follow [preflight](docs/tasks/p3/preflight.md) to map the actual P2 source and prepare `0.3.0`; the current published `0.2.0` is not P3 execution-ready. Then `npm run space-factory:phase -- p3` runs P1–P5 and leaves P6 as the required native manual closeout. Its `Browser required: yes` handoff applies even with `--closeout`.

The completed p1 stack was published together without individual runner checkpoint commits. Preserve actual P2 history and owner work as well; do not fabricate earlier checkpoints or reset a progressed checkout to an old baseline. Missing historical P2 evidence alone is recorded as a gap, while missing actual P2 code is a dependency to synchronize before P3.

The adopted M1 factory is finite ice → solar-powered processor → player-installed pipe → propellant tank → engine. Manual fixed-orientation four-direction flight and coasting are scoped prototype choices. Quantities, timings, speed, exact bindings, and presentation tuning remain task-level choices. [The decision register](docs/decisions-and-questions.md#accepted-m1-prototype-decisions) records their scope.

P3 authoring claims no production or flight result. M1-P4/P5 stacks and the expedition/outpost roadmap remain future work.

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
