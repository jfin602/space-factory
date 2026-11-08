# Documentation index

Space Factory is a proposed 2D game about a single engineer operating a spaceship through its internal factory and a network of persistent surface outposts. This documentation captures the initial design discussion of **2026-11-08**.

**Implementation status: bootstrap sandbox committed; gameplay systems remain planned.** A Godot 4 .NET project, developer commands, and the ported Node.js phase runner live in this repository; see [development setup](development.md) for recorded verification results and [BOOT.md](../BOOT.md) for current routing. Bootstrap delivery and runner tooling do not by themselves qualify the roadmap's full foundation Gates.

**Accepted next milestone:** [M1 — First Factory-Powered Flight](roadmap.md#milestone-m1-first-factory-powered-flight), a five-Phase plan from ship-relative interior movement through a real factory-supplied flight playtest. [The milestone design](planning/p1/first-flight.md) records its scoped choices and implementation boundaries; the roadmap alone tracks Gate progress.

## How to read these documents

For a first overview, read [vision](vision.md), [game design](game-design.md), and [decisions and open questions](decisions-and-questions.md). To begin development, then read [technical direction](technical-direction.md), the next Phase in the [roadmap](roadmap.md), and the relevant [validation scenarios](validation.md).

For a focused task, begin with [AGENTS.md](../AGENTS.md) and [BOOT.md](../BOOT.md), then use the table below instead of reading every file. [The workflow](workflow.md) defines documentation review, prompt authoring, execution, and closeout.

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
| [Technical direction](technical-direction.md) | Working simulation and persistence architecture using the selected Godot/.NET stack. |
| [Development setup](development.md) | Godot/.NET installation, commands, scene automation, exports, and bootstrap evidence. |
| [Module map](../MODULES.md) | Source-backed current responsibilities and explicitly planned future boundaries. |
| [Workflow](workflow.md) | Task-scoped reading, documentation changes, prompt stacks, execution, validation tiers, and closeout. |
| [Phase runner](phase-runner.md) | Node/Codex setup, CLI commands, exact prompt grammar, model mapping, version policy, Git checkpoints/resume, artifacts, and manual handoffs. |
| [Planning index](planning/README.md) | Phase design organization and references to the canonical roadmap. |
| [First-flight milestone design](planning/p1/first-flight.md) | Accepted M1 scope, baseline, state boundaries, deferrals, and execution guidance. |
| [Task index](tasks/README.md) | Executable task conventions and source-bound qualification records. |
| [Decision-record index](decisions/README.md) | Detailed durable decisions linked from the existing decision register. |
| [Roadmap](roadmap.md) | Small development Phases, Gates, dependencies, and expected evidence. |
| [Validation](validation.md) | Scenario-based acceptance, regressions, and the distinction between design and proof. |
| [Decisions and open questions](decisions-and-questions.md) | Confirmed requirements, working recommendations, unresolved choices, and provenance. |
| [Glossary](glossary.md) | Shared terms, including the distinction between a run and an expedition. |
| [Known issues](../known-issues.md) / [feature ideas](../feature-ideas.md) | Reported defects and proposed enhancements, separate from accepted scope. |

## Design status vocabulary

- **Confirmed requirement:** explicitly specified by the project owner in the discussion.
- **Accepted prototype choice:** adopted for a named milestone; it is not a permanent game-wide rule or evidence of implementation.
- **Working design:** a proposed way to realize the confirmed requirements; useful for planning but subject to validation and change.
- **Example:** illustrative content, recipe, scenario, or number; not a locked balance specification.
- **Open decision:** a choice that has not been made. Each should be resolved when its dependent work needs it.
- **Implemented / verified:** reserved for actual code and recorded evidence. The sandbox evidence is recorded in [development setup](development.md); the planned gameplay systems are not thereby complete.

The [decision register](decisions-and-questions.md) owns requirement status. System documents own their detailed behavior. The roadmap owns the intended work sequence, and validation describes what evidence is needed. Avoid copying the full specification into every task.

## First development outcome

Execute M1 in order: a coherent ship, factory preparation, propellant manufacture, first powered flight, and a repeatable playtest. Its fresh scenario starts with zero propellant and finite ice; the player restores a connection and manufactures the supply used for flight. Then expand toward the complete excursion and persistent surface outpost described in the broader roadmap. The roadmap makes these outcomes independently reviewable while retaining the full long-term game concept.
