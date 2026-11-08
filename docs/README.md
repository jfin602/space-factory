# Documentation index

Space Factory is a proposed 2D game about a single engineer operating a spaceship through its internal factory and a network of persistent surface outposts. This documentation captures the initial design discussion of **2026-11-08**.

**Implementation status: bootstrap sandbox in progress.** The game design and its major systems remain planned. A Godot 4 .NET project and developer commands now live in this repository; see [development setup](development.md) for actual verification results.

## How to read these documents

For a first overview, read [vision](vision.md), [game design](game-design.md), and [decisions and open questions](decisions-and-questions.md). To begin development, then read [technical direction](technical-direction.md), the next Phase in the [roadmap](roadmap.md), and the relevant [validation scenarios](validation.md).

For a focused task, use the table below instead of reading every file. [AGENTS.md](../AGENTS.md) provides contributor and coding-agent practices.

## Document map

| Document | Owns |
| --- | --- |
| [Vision](vision.md) | Player fantasy, design priorities, intended experience, and scope boundaries. |
| [Game design](game-design.md) | Core loops, expedition structure, mission examples, progression, and strategic choices. |
| [Factory and resources](systems/factory-and-resources.md) | Machines, inventories, production, logistics, resource examples, and bottlenecks. |
| [Ship and navigation](systems/ship-and-navigation.md) | Ship capabilities, expansion, travel, scouting, and route preparation. |
| [Landings and outposts](systems/landings-and-outposts.md) | Surface play, landed exterior, ports, independent facilities, and revisits. |
| [Survival and runs](systems/survival-and-runs.md) | Engineer risk, combat boundaries, recoverable crises, terminal loss, and run lifecycle. |
| [Tutorial](tutorial.md) | The deliberately solvable stranded-ship opening and first successful departure. |
| [UX and presentation](ux-and-presentation.md) | Interior/exterior views, interaction, readable system states, and warnings. |
| [Technical direction](technical-direction.md) | Proposed architecture and persistence boundaries without choosing a technology stack. |
| [Development setup](development.md) | Godot/.NET installation, commands, scene automation, exports, and bootstrap evidence. |
| [Roadmap](roadmap.md) | Small development Phases, Gates, dependencies, and expected evidence. |
| [Validation](validation.md) | Scenario-based acceptance, regressions, and the distinction between design and proof. |
| [Decisions and open questions](decisions-and-questions.md) | Confirmed requirements, working recommendations, unresolved choices, and provenance. |
| [Glossary](glossary.md) | Shared terms, including the distinction between a run and an expedition. |

## Design status vocabulary

- **Confirmed requirement:** explicitly specified by the project owner in the discussion.
- **Working design:** a proposed way to realize the confirmed requirements; useful for planning but subject to validation and change.
- **Example:** illustrative content, recipe, scenario, or number; not a locked balance specification.
- **Open decision:** a choice that has not been made. Each should be resolved when its dependent work needs it.
- **Implemented / verified:** reserved for actual code and recorded evidence. The sandbox evidence is recorded in [development setup](development.md); the planned gameplay systems are not thereby complete.

The [decision register](decisions-and-questions.md) owns requirement status. System documents own their detailed behavior. The roadmap owns the intended work sequence, and validation describes what evidence is needed. Avoid copying the full specification into every task.

## First development outcome

Begin with a running foundation and a small recoverable ship, then demonstrate the engineer assembling a production connection that makes departure possible. Expand that into a complete excursion and, subsequently, a surface outpost that can be left and revisited. The roadmap makes these outcomes independently reviewable while retaining the full long-term game concept.
