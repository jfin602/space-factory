# M1 — First Factory-Powered Flight

**Design status: accepted for the prototype on 2026-11-08.** The owner requested that the preceding five-Phase plan be added to repository documentation after checking BOOT and the workflow. [The decision register](../../decisions-and-questions.md#accepted-m1-prototype-decisions) records that provenance and the limits of the choices. This is an implementation plan, not evidence that gameplay exists.

The [canonical roadmap](../../roadmap.md#milestone-m1-first-factory-powered-flight) owns M1 Phase order, dependencies, Gate criteria, and all progress. This document supplies scope and engineering context. M1 expands broader Phases 0 and 1; the existing expedition, landing, combat, permanent-loss, and outpost roadmap remains intact.

## Intended player outcome

Walk around the starter ship, load finite ice, install its missing pipe segment, manufacture propellant, enter the helm, and fly toward a beacon while the factory continues operating. Stored propellant remains usable when production stops. Once it is exhausted, manufacture more from remaining real ice to restore thrust.

M1-P4 proves the core factory-powered flight. M1-P5 turns it into a readable, repeatable first playtest. Complete the milestone only when the roadmap's Gates have their required evidence.

## Inspected starting point

Planning used remote `main` at [7a5b1b55](https://github.com/jfin602/space-factory/commit/7a5b1b55acca2fe21d64790c56cd081e4cb8aed8), including the new agent/boot/workflow guides. Gameplay files still match the [536cfd08 bootstrap](https://github.com/jfin602/space-factory/commit/536cfd08da06f119e91d8a4f8865b4508be2e579). These are source identities, not reset targets; inspect current HEAD and local work before execution.

| Existing source | Observed responsibility | Consequence for M1 |
| --- | --- | --- |
| [main.tscn](../../../game/scenes/main.tscn) | Main scene composes deck, engineer, camera, and overlay as siblings | Establish ship-local ownership and a separate world transform. |
| [Deck.cs](../../../game/scripts/Deck.cs) | Draws a fixed deck/grid and decorative shapes | Add only the hull/bounds and limited socket semantics needed now; the drawing is not a construction system. |
| [Engineer.cs](../../../game/scripts/Engineer.cs) | Moves a `CharacterBody2D` and clamps its position to fixed coordinates | Make movement bounds deck-relative and arbitrate walking versus piloting. |
| [Main.cs](../../../game/scripts/Main.cs) | Checks exact main-scene nodes and emits the real C# smoke result | Update affected assertions when scene composition changes; preserve meaningful success/failure behavior. |
| [tools/dev](../../../tools/dev) | Existing build, runtime smoke, scene automation, editor, and run entry point | Reuse documented commands; inspect composition to avoid duplicate checks. |

[Development setup](../../development.md) records prior Linux bootstrap evidence. No new gameplay observation is claimed by this document. [MODULES.md](../../../MODULES.md) remains the source map; gameplay subsystem locations should be introduced only when implemented.

## Bounded prototype scope

| Area | Adopted M1 choice | Owning detail |
| --- | --- | --- |
| Starter ship | One fixed hull, visible interior, recognizable outline, one engineer and nearby helm | [Ship](../../systems/ship-and-navigation.md) |
| Factory | Mostly installed cargo crate, processor, tank, engine, and one missing pipe socket | [Factory](../../systems/factory-and-resources.md) |
| Supply | Finite ice and one pipe part; zero initial propellant; a single timed ice-to-propellant recipe | [Factory](../../systems/factory-and-resources.md) |
| Startup electricity | Installed small solar supply runs the processor independently of engine propellant | [Factory](../../systems/factory-and-resources.md) |
| Player assembly | Take/load actions and installation of the real missing processor-to-tank connection | [Tutorial](../../tutorial.md) |
| Flight | Exclusive Piloting mode, fixed orientation, four-direction thrust, simple acceleration and coasting | [Ship](../../systems/ship-and-navigation.md) |
| Space and objective | Stationary landmarks and one reachable beacon in a small authored test space | [Presentation](../../ux-and-presentation.md) |
| Session | Fresh repeatable playtest; explicit restart restores its defined state | [Tutorial](../../tutorial.md) |
| Platform | Linux playtest first; Windows/macOS remain later native qualification targets | [Development setup](../../development.md) |

These are scoped prototype choices, not permanent restrictions on the full game. Resource quantities, storage sizes, processing duration, flow rate, speed/acceleration, key bindings, camera framing, and visual tuning remain adjustable task-level values. Choose enough finite starting ice for the beacon objective and a real starvation/recovery demonstration; normal factory output should support useful flying while feedstock lasts.

The solar supply produces electricity only. It neither creates ice/propellant nor secretly refills stores. This avoids a startup cycle in which making the first engine propellant would require that same propellant. The initial stranding is explained by the empty tank and missing supply connection; a damage/repair system is not required for M1.

## Smallest implementation boundaries

| State owner | Required boundary |
| --- | --- |
| Ship | World position/velocity and a fixed hull; onboard cells, objects, and engineer position remain ship-local. |
| Engineer and interaction | One engineer, bounded local movement, carried quantities, nearby take/load/install/helm actions. |
| Factory | Real cargo/input/output/tank quantities, one recipe/job, available startup power, running and blocked states. |
| Connection | Defined source/destination, installed state, finite throughput, and receiving capacity. |
| Propulsion | Consume actual tank supply when applying thrust; empty supply removes powered acceleration and preserves coasting behavior. |
| Presentation | Observe the same simulation, display cause/state, and submit actions; camera or control changes do not recreate resources. |

Use one authoritative C# simulation and shared game time for production, transfers, and consumption, as described in [technical direction](../../technical-direction.md). Add only the entities and identifiers these real state owners need. Do not build a generic factory framework before this loop works.

An installed pipe represents a real bounded transfer route even though the first layout has only one valid socket. A stopped processor is different from an empty engine supply: stored propellant remains usable. Account for inputs already committed to an unfinished job if output blocks; changing controls or views must neither lose nor duplicate that material.

Walking and Piloting are mutually exclusive. Leaving the helm clears thrust input while preserving ship motion and engineer location. The factory continues in both modes. An optional active brake draws from the same propellant supply; an empty tank does not imply instant stopping or engineer death.

## Execution approach

Follow [AGENTS.md](../../../AGENTS.md), [BOOT.md](../../../BOOT.md), and [the workflow](../../workflow.md), with task-scoped reading. The roadmap's M1-P1 through M1-P5 order is the dependency order. Use `/prompt-ass` → `/prompt-plan` → `/prompt-write <folder>` when authoring the selected execution stack; this plan does not itself create prompts, run a stack, or install a phase runner.

The first selected execution stack is now authored under [docs/tasks/p1](../../tasks/p1/README.md), with its [assessment](../../tasks/p1/prompt-assessment.md) and [implementation plan](../../tasks/p1/implementation-plan.md). It implements M1-P1 only. The published [phase runner](../../phase-runner.md) validates its four prompts; the initial 0.1.0 development checkpoint baseline is prepared without executing gameplay. Later M1 stacks remain unauthored, and all gameplay progress stays in the roadmap.

Each Phase may need several short prompts. Keep each ordinary prompt to one coherent responsibility, with explicit prerequisites and the smallest meaningful validation. Apply the workflow's planning budgets as decomposition guidance, not as a promise that the whole Phase or milestone will finish within a fixed time. Preserve any explicit manual checkpoint when a stack is later authored.

| Evidence boundary | Appropriate checks |
| --- | --- |
| Local rule/state changes | T1 focused checks for conservation, capacities, timing, and control arbitration when implemented. |
| Connected production/propulsion | T2 integration using real state and failure cases, including blocked output and fuel exhaustion/recovery. |
| Spatial/input/player outcome | T3 running-game observation of the named scenario; a native game GUI counts as GUI-required work. |

`./tools/dev check` already imports, builds, runs the main-scene C# smoke, and exercises saved-scene automation. Adapt affected checks as the scene evolves, and run the appropriate composition once for an unchanged candidate. It cannot stand in for observing player interactions or flight.

[M1 validation scenarios](../../validation.md#first-flight-milestone-m1) specify the evidence, including [the complete acceptance run](../../validation.md#first-flight-acceptance-run). If direct observation is unavailable, record NOT OBSERVED and the concrete handoff; do not substitute an inferred pass. Link actual results from task evidence into the roadmap.

## Deferred beyond M1

- Unrestricted machine placement, arbitrary pipes/belts/junctions, and general construction or dismantling.
- Damage, repair crafting, hull expansion, rotation, directional-engine layouts, and richer flight physics.
- Batteries, electrical wiring networks, day/night power variation, and advanced fluid/thermal simulation.
- Landing, exterior walking, resource extraction, enemies, combat, and persistent surface facilities.
- Save/load, full survival rules, durable permanent loss, and cross-run behavior.
- Full tutorial/mission frameworks, procedural worlds, production art, and Windows/macOS release qualification.

These deferrals preserve the larger game requirements. Use first-playtest evidence to prioritize their later increments. Restart playtest is an explicitly labeled development convenience and does not establish respawning within a future permanent-failure run.
