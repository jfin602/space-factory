# Technical direction

**Status: working technical plan; no implementation exists.** The owner-confirmed game requirements are recorded in [Decisions and questions](decisions-and-questions.md). The architecture below is a recommendation for implementing them. Engine, language, target platform, distribution, and performance budgets remain undecided.

## Choose a small foundation

Phase 0 should select a stack that can demonstrate top-down movement, tile placement, resource transfer, scene transitions, and local persistence with a small runnable experiment. Record the choice and its reasons, then build the experiment. Evaluate only options relevant to that target; do not build several complete prototypes or turn preparation into an indefinite documentation task.

The first implementation should contain one engineer, one small ship, a few machines, and a bounded set of destinations. It should support the complete expedition described in the [roadmap](roadmap.md) before expanding content. Document actual setup and run commands once they exist; this document intentionally defines no fictitious commands or dependencies.

## Simulation and presentation

Use one authoritative simulation state. Rendering, camera changes, interface panels, and animations observe that state and submit player intentions to it. A view change must not create a second ship, transfer inventory, or advance time by itself.

A fixed simulation step is the recommended starting point. Rendering can run independently. Define pause, time acceleration, and travel-time behavior explicitly before adding them; all resource consumption and hazards must use the same game clock. Wall-clock time while the application is closed should not advance the run under the initial recommendation. That policy remains a design decision, not an existing feature.

Suggested responsibilities are logical boundaries, not a required directory structure:

| Responsibility | Owns |
| --- | --- |
| Run lifecycle | Run identity, seed or scenario, engineer state, terminal outcome |
| Factory | Inventories, recipes, power, conveyors, pipes, machine operation |
| Ship | Hull layout, equipment, local coordinates, ports, propulsion state |
| Navigation | Destinations, route progress, estimates, discovered information |
| Surface locations | Deposits, terrain, local entities, facilities and threats |
| Combat and damage | Attacks, consumable costs, damage and destruction events |
| Persistence | Save format, validation, durable writes and loading |
| Presentation | Input, views, diagnostics, maps, audio and accessibility |

Prefer a small, understandable set of components over a general simulation framework. Introduce abstraction when a second real use establishes the need.

## Space, identity and connections

Represent the ship interior in ship-local coordinates. Landing gives that ship a placement on a surface with a location identifier and transform. The exterior footprint and interior should derive from the same hull description. Walking through an entrance changes the engineer's location and presentation without replacing the underlying ship.

Give persistent identifiers to runs, locations, ships, placed entities, inventories, and ports. A connection records both endpoints and its kind. Departure removes surface-to-ship connections while retaining each side's own machines, inventories, and damage. An outpost must not retain a working pipe to a ship in another region.

Port compatibility, transfer capacity, obstruction, and connection loss should be explicit state. Additional ports must connect to actual interior destinations. See [Ship and navigation](systems/ship-and-navigation.md) and [Landings and outposts](systems/landings-and-outposts.md).

## Resources and content

Every resource quantity has one owner. A transfer must debit its source and credit its destination as one logical operation, respecting compatibility and capacity. Saving, undocking, destruction, or switching views must not duplicate or silently discard that transfer. If an interrupted transfer has a physical in-transit representation, that representation owns the quantity until delivery or a defined loss event.

Keep recipes and machine properties in a small data-driven format: identifiers, inputs, outputs, duration, power needs, capacity, and allowed connections. Choose stable units and rounding rules. Do not add advanced fluid physics, heat simulation, or mass calculations until the relevant design is selected and the simpler model proves insufficient.

Resource depletion, damage, and consumption must produce explainable causes. The interface should derive warnings from that state rather than maintain separate estimates of whether a machine is working. Route forecasts should distinguish known quantities from assumptions and unknown conditions.

## Facilities outside the current view

Persistent outposts need a bounded simulation method. A recommended approach advances them against the same game clock using events at meaningful limits: an input runs out, storage fills, power stops, ammunition is exhausted, or damage changes a production connection.

Multiplying the current production rate by an entire absence is insufficient when that interval crosses a limit. Preserve intermediate dependencies and account for resources consumed by defenses. Use a reproducible random source for stochastic events so a reported failure can be investigated.

Exact offscreen combat fidelity remains open. Choose and document an abstraction before implementing it. For supported cases, compare offscreen outcomes against the normal simulation over the same interval. Remote telemetry records an observation time; it must not present an old reading as current knowledge. See [Validation](validation.md).

## Saves and permanent outcomes

Save-and-quit is a working recommendation for multi-session runs. A save should include a format version, run identity, scenario or random-generator state, simulation time, engineer and ship state, travel progress, discovered information, all visited outposts, and any terminal outcome. Saves preserve actual quantities and connections, not just displayed totals.

Use a validated replacement write so an interrupted write does not overwrite the only usable state. Distinguish application failure from in-world failure: a software crash must not itself kill the engineer. A known terminal outcome must remain terminal when the application restarts; loading an older active snapshot must not become an ordinary continuation path for that dead run.

Define how terminal outcomes become durable and how failed writes are recovered before shipping that feature. A temporarily disabled ship remains an active run while recovery is possible. There is no requirement to solve a general mathematical proof of unwinnability; actual engineer death and explicit run termination provide observable outcomes. See [Survival and runs](systems/survival-and-runs.md).

## Engineering practices and unresolved work

Keep rules testable without rendering. Validate identifiers and content at load boundaries, expose causal diagnostics during development, and exercise the boundaries where inventories, locations, and saves change ownership. Establish performance budgets on the selected target hardware after a representative scene exists; no benchmark is claimed here.

The next technical decisions are stack and target, simulation clock policy, save format, world representation, initial combat model, and outpost abstraction. Follow [AGENTS.md](../AGENTS.md) for task-scoped document routing and [Validation](validation.md) for evidence requirements.
