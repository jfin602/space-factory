# Space Factory module map

This map describes responsibility boundaries and their current source locations. Read [technical direction](docs/technical-direction.md) for the intended architecture and [development setup](docs/development.md) for exact commands. Update this map when a responsibility moves or becomes implemented.

## Current bootstrap

The repository contains a Godot 4.7.2 .NET/C# sandbox with a moving engineer, a drawn deck, a camera, and a small overlay. The following boundaries describe that existing code.

| Responsibility | Current source | Owns |
| --- | --- | --- |
| Project composition | [project.godot](game/project.godot), [main.tscn](game/scenes/main.tscn) | Engine settings, input actions, initial scene, node composition, camera, collision shape, and overlay. |
| Main-scene smoke entry | [Main.cs](game/scripts/Main.cs) | The explicit `--smoke` path, required-node checks, success/failure marker, and smoke-process exit. |
| Engineer movement and drawing | [Engineer.cs](game/scripts/Engineer.cs) | Keyboard movement through `CharacterBody2D`, current position bounds, and placeholder engineer visuals. |
| Deck presentation | [Deck.cs](game/scripts/Deck.cs) | Placeholder deck, grid, border, and decorative shapes. The drawn grid has no placement or factory simulation rules yet. |
| Development commands | [tools/dev](tools/dev) | Tool selection, import/build/check/run/editor commands, bounded logged operations, and export invocation. |
| Scene automation | [scene_tool.gd](game/dev/scene_tool.gd) | Saved-scene inspection and a disposable scene serialization/reload check through Godot APIs. This GDScript utility is separate from C# gameplay. |
| Build and export configuration | [SpaceFactory.csproj](game/SpaceFactory.csproj), [global.json](game/global.json), [export_presets.cfg](game/export_presets.cfg) | The Godot .NET SDK, .NET SDK selection, and platform export presets. |

`main.tscn` composes the present runtime. `tools/dev check` imports and builds the project, runs the real scene's smoke mode, and exercises the scene utility. These checks establish their recorded bootstrap scope; [development setup](docs/development.md) owns the verification record.

## Planned gameplay responsibilities

These are proposed logical boundaries from the existing design. They have no implemented subsystem paths yet. Introduce source organization as the relevant playable increment needs it.

| Planned responsibility | Intended ownership | Design reference |
| --- | --- | --- |
| Authoritative simulation | Shared game time, entity identities, state transitions, and rules independent of rendering | [Technical direction](docs/technical-direction.md) |
| Factory and resources | Inventories, recipes, power, machines, and resource transfers | [Factory and resources](docs/systems/factory-and-resources.md) |
| Ship and navigation | Hull, equipment, propulsion, destinations, and travel state | [Ship and navigation](docs/systems/ship-and-navigation.md) |
| Surface locations and outposts | Landed placement, entrances, ports, persistent facilities, and remote operation | [Landings and outposts](docs/systems/landings-and-outposts.md) |
| Survival and run lifecycle | Engineer risk, damage, recovery, and terminal outcomes | [Survival and runs](docs/systems/survival-and-runs.md) |
| Persistence | Validated save/load, durable terminal state, and recovery from interrupted writes | [Technical direction](docs/technical-direction.md) |
| Gameplay presentation | Player input, views, factory feedback, navigation information, and readable failure states | [UX and presentation](docs/ux-and-presentation.md) |

Simulation owns quantities and outcomes; presentation observes them and submits player intentions. A camera change, scene transition, or interface inspection must not duplicate state or resources. Keep the initial implementation small and add abstractions when real dependencies justify them.

## Repository homes

| Path | Purpose |
| --- | --- |
| `game/` | Godot project, C# gameplay, saved scenes, and the isolated scene utility. |
| `tools/` | Repository development commands; machine-specific overrides stay local and ignored. |
| `docs/` | Product/system design, development guidance, roadmap, decisions, plans, tasks, and evidence summaries. |
| `artifacts/` | Ignored, reproducible logs and exports. Preserve any evidence needed for a durable claim in the relevant task record or a durable linked artifact before cleanup. |

Start a session with [AGENTS.md](AGENTS.md) and [BOOT.md](BOOT.md). Use the [workflow](docs/workflow.md) to turn the next roadmap outcome into bounded implementation work.
