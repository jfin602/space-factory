# Space Factory module map

This map describes responsibility boundaries and their current source locations. Read [technical direction](docs/technical-direction.md) for the intended architecture and [development setup](docs/development.md) for exact commands. Update this map when a responsibility moves or becomes implemented.

## Current M1-P1 sandbox

The repository contains a Godot 4.7.2 .NET/C# sandbox with a ship-local deck, engineer, and helm; a stationary world beacon; a camera; and a small state-driven overlay. [M1-P1](docs/tasks/p1/closeout.md) qualified these boundaries on Linux.

| Responsibility | Current source | Owns |
| --- | --- | --- |
| Project composition | [project.godot](game/project.godot), [main.tscn](game/scenes/main.tscn) | Engine settings and named movement/interaction actions; `Main/Ship/{Deck,Engineer,Helm}` local hierarchy; world-owned camera/beacon; and HUD. |
| Ship control and capability | [Ship.cs](game/scripts/Ship.cs) | Authoritative Walking/Piloting mode, nearby E interaction, exclusive input routing, request/velocity cleanup, and truthful unavailable-propellant reason. It applies no propulsion. |
| Main scene, HUD, and checks | [Main.cs](game/scripts/Main.cs) | Mode/help/feedback from ship state; explicit `--smoke` scene/control/integration assertions and failure exit; flagged `--p1-spatial-demo` translation and its checks. |
| Engineer movement and drawing | [Engineer.cs](game/scripts/Engineer.cs), [engineer sprite](game/assets/pixel/engineer/engineer_idle_down.png) | Walking from ship-routed direction through `CharacterBody2D`, full-body deck containment, and idle pixel-art presentation. |
| Deck presentation and bounds | [Deck.cs](game/scripts/Deck.cs), [starter art](game/assets/pixel/ship/deck_tile.png) | One local interior rectangle for tiled floor/hull drawing and engineer bounds. The art grid has no placement or factory simulation rules yet. |
| Development commands | [tools/dev](tools/dev) | Tool selection, import/build/check/run/editor, explicit `p1-demo`, bounded logged operations, and export invocation. |
| Scene automation | [scene_tool.gd](game/dev/scene_tool.gd) | Saved-scene inspection and a disposable scene serialization/reload check through Godot APIs. This GDScript utility is separate from C# gameplay. |
| Build and export configuration | [SpaceFactory.csproj](game/SpaceFactory.csproj), [global.json](game/global.json), [export_presets.cfg](game/export_presets.cfg) | The Godot .NET SDK, .NET SDK selection, and platform export presets. |

`main.tscn` composes the present runtime. `tools/dev check` imports/builds, runs normal and fixture real-scene C# smokes, and exercises the scene utility. [Implementation evidence](docs/tasks/p1/qualification/implementation.md) and [native results](docs/tasks/p1/qualification/native-playtest.md) own the M1-P1 qualification; [development setup](docs/development.md) owns command details and prior bootstrap verification.

## Phase-runner tooling

The Node.js runner is separate from the Godot runtime. [The runner guide](docs/phase-runner.md) owns its user-facing contract and Dope source provenance.

| Responsibility | Current source | Owns |
| --- | --- | --- |
| Stack execution | [space-factory-phase.mjs](scripts/space-factory-phase.mjs) | Codex launcher, prompt execution, terminal progress, capacity retries, Git checkpoints/resume, artifacts, and manual/closeout handoffs. |
| Shared runner logic | [space-factory-phase-core.mjs](scripts/space-factory-phase-core.mjs) | Prompt grammar, model mapping, Phase/correction version plans, checkpoint matching, event tracking, and display helpers. |
| Standalone validation | [validate-space-factory-phase.mjs](scripts/validate-space-factory-phase.mjs) | Parse a task folder and report its prompt/version plan without launching Codex. |
| Tooling metadata and tests | [package.json](package.json), `test/unit/space-factory-phase-*.test.ts` | CLI aliases, Node version requirement, development checkpoint version, and runner regression coverage. |

The runner schedules implementation instructions; it adds no gameplay system, screenshot harness, or native game-input driver. Actual Godot checks belong in the relevant prompt and task evidence.

## Planned gameplay responsibilities

These are proposed logical boundaries from the existing design. They have no implemented subsystem paths yet. Introduce source organization as the relevant playable increment needs it.

| Planned responsibility | Intended ownership | Design reference |
| --- | --- | --- |
| Authoritative simulation | Shared game time, entity identities, state transitions, and rules independent of rendering | [Technical direction](docs/technical-direction.md) |
| Factory and resources | Inventories, recipes, power, machines, and resource transfers | [Factory and resources](docs/systems/factory-and-resources.md) |
| Ship and navigation beyond M1-P1 | Real supply/engine chain, applied propulsion, destinations, and travel state; the hull and control-mode owner already exist above | [Ship and navigation](docs/systems/ship-and-navigation.md) |
| Surface locations and outposts | Landed placement, entrances, ports, persistent facilities, and remote operation | [Landings and outposts](docs/systems/landings-and-outposts.md) |
| Survival and run lifecycle | Engineer risk, damage, recovery, and terminal outcomes | [Survival and runs](docs/systems/survival-and-runs.md) |
| Persistence | Validated save/load, durable terminal state, and recovery from interrupted writes | [Technical direction](docs/technical-direction.md) |
| Gameplay presentation beyond M1-P1 | Factory feedback, navigation information, and later failure states; basic mode/help/unavailable-supply feedback already exists above | [UX and presentation](docs/ux-and-presentation.md) |

Simulation owns quantities and outcomes; presentation observes them and submits player intentions. A camera change, scene transition, or interface inspection must not duplicate state or resources. Keep the initial implementation small and add abstractions when real dependencies justify them.

## Repository homes

| Path | Purpose |
| --- | --- |
| `game/` | Godot project, C# gameplay, saved scenes, and the isolated scene utility. |
| `tools/` | Repository development commands; machine-specific overrides stay local and ignored. |
| `scripts/`, `test/unit/` | Node.js phase-runner implementation, validator, and TypeScript tests. |
| `docs/` | Product/system design, development guidance, roadmap, decisions, plans, tasks, and evidence summaries. |
| `artifacts/` | Ignored, reproducible logs and exports. Preserve any evidence needed for a durable claim in the relevant task record or a durable linked artifact before cleanup. |
| `.codex-runs/` | Ignored runner invocation records, Codex events/final responses, and checkpoint-message files. |

Start a session with [AGENTS.md](AGENTS.md) and [BOOT.md](BOOT.md). Use the [workflow](docs/workflow.md) to turn the next roadmap outcome into bounded implementation work.
