# Ship and navigation

This describes intended behavior, not implementation. **Confirmed** identifies owner decisions; **recommended** identifies proposals. Values and examples are illustrative. See [game design](../game-design.md) and the [decision register](../decisions-and-questions.md).

## Confirmed foundations

- The player directly controls one engineer in a top-down 2D game.
- The engineer's factory is inside a spaceship. Its production systems keep the ship operational and support missions and exploration.
- The run begins with a small stranded ship. Restoring it introduces the game's systems.
- The ship travels through space and can land on planets, asteroids, and other sufficiently large objects.
- Ship size affects the number of available access ports. The landed ship is visible from outside.
- A ship can suffer an irreversible crash or become permanently stranded through resource exhaustion. The engineer can die, ending the run without respawning.

The detailed relationship between ship damage, surviving a crash, and engineer death still needs definition. A temporarily disabled engine must not be confused with a confirmed terminal outcome; see [survival and runs](survival-and-runs.md).

## Accepted M1 ship and flight rules

**Scope: First Factory-Powered Flight, accepted for implementation planning on 2026-11-08; gameplay is not yet implemented or qualified.** See the [milestone plan](../planning/p1/first-flight.md) and canonical [roadmap Gates](../roadmap.md#milestone-m1-first-factory-powered-flight).

- Use one fixed starter hull, a recognizable outline, a walkable deck, installed machinery, and a nearby-interaction helm. Stars and stationary beacons make world movement visible.
- Ship position belongs to space. Engineer position, deck bounds, grid cells, machinery, and connections belong to the ship. Translating the ship preserves their local positions and relationships.
- Walking and Piloting are mutually exclusive input modes. The engineer approaches the helm to enter it; leaving restores walking and clears the current thrust request.
- Manual flight uses four-direction thrust with a fixed ship orientation and simple acceleration. Ship rotation, directional-engine layout, and orbital physics are deferred. Bindings, acceleration, consumption, and other tuning values are chosen during implementation.
- Begin with an empty tank. The first powered acceleration depends on propellant manufactured by the [onboard factory](factory-and-resources.md#accepted-m1-factory-loop).
- Applied thrust consumes tank propellant at a defined rate; quantities cannot become negative. An empty tank prevents powered acceleration while preserving existing coasting velocity. If an active brake is included, it uses the same propulsion supply.
- Production continues during piloting and walking. Leaving the helm allows the engineer to tend the factory while the ship coasts; returning preserves velocity, inventories, connections, and production progress.
- Stopping production leaves the stored reserve usable. Once exhausted, more propellant produced from remaining ice restores thrust. An empty tank does not by itself end the scenario or declare the engineer dead.
- Camera changes observe the same authoritative ship and factory state. A wider piloting view may improve readability without replacing or resetting that state.

The immediate objective is to fly to a visible beacon. These controls qualify the small first-flight prototype only; later destination orders, navigation forecasts, landings, survival, and permanent outcomes remain separate work.

## The ship as a working factory

**Recommended:** every major capability should have a visible supporting system. Propulsion depends on an available fuel or energy supply; repairs depend on usable material; exploration equipment depends on capacity the player has installed and supplied. M1 adopts the propellant supply above; broader propulsion types, coolant rules, and power requirements remain undecided.

The player should be able to trace a capability back through the factory: engine to supply connection, connection to storage, storage to processor, and processor to its inputs. A stopped engine should expose the relevant failure rather than present an unexplained general ship penalty.

Preserve a useful industrial core aboard the ship. Surface facilities can increase throughput and replenish reserves, but the vessel remains the engineer's mobile workshop and survival system. Moving all repair and processing capability to an outpost should be a deliberate risky specialization, not the default required by the design.

Physical inventories matter. A component in a planetary warehouse is unavailable to an onboard repair machine until it has actually been transferred. The exact inventory model belongs in [factory and resources](factory-and-resources.md); this document establishes the intended relationship between location and availability.

## Travel and mission planning

**Recommended for later voyages:** destination-based navigation lets the engineer select a location and travel priorities, then work inside while the ship follows those orders. M1 first proves manual flight under the scoped rules above. The later relationship between destination orders and manual piloting, continuous versus sector travel, and voyage time remains open.

Possible orders include holding position, approaching a resource field, following a route, and selecting efficient or faster travel. Each meaningful order should expose its implications for the systems that support it. A speed setting should have an understandable effect on consumption if that tradeoff is adopted.

Travel should connect preparation to opportunity. The player can manufacture supplies en route, provided the necessary inputs and machinery are actually available. A planned delivery or salvage operation may compete with fuel or repair production for space, materials, and power. Missions should make those relationships useful without requiring one universal ship layout.

Before a consequential departure, show current reserves, expected route consumption, usable production during transit, estimated arrival reserves, and known resupply options. Estimates must state their assumptions. A refinery with no feedstock must not contribute its theoretical maximum output to a fuel forecast.

Distinguish known costs from uncertainty. For example, “Arrival leaves insufficient fuel to reach another known supply source” describes the available evidence. It does not assert that an unexplored destination contains no resources. The player may knowingly accept such a risk; a warning is not automatically a departure lock.

## Expansion and placement

**Recommended:** extra hull space creates room for machinery, reserves, and access, while demanding appropriate construction resources. Any effects of mass, hull size, landing footprint, or propulsion load are further proposals requiring explicit rules.

Choices include fuel storage versus production, repair reserves versus hull expansion, and cargo space versus specialized equipment. Machinery should expose its demands before installation.

Maintain a consistent relationship between the ship's layout and its ports. How that layout is represented during flight and landing is covered in [presentation](../ux-and-presentation.md) and [landings and outposts](landings-and-outposts.md).

## Proposed acceptance examples

These are design targets for future validation, not evidence of passing tests:

- An engine's unavailable input can be traced to the actual empty store, broken connection, or stopped machine responsible.
- A route forecast uses accessible reserves and feasible production, labels uncertainty, and updates after a relevant operating change.
- Disabling propulsion leaves the engineer able to inspect, reconfigure, and attempt recovery while survival resources remain.
- Removing an outpost connection removes that supply from the ship's operating plan without deleting either side's remaining inventory.
- An upgrade makes its required inputs and occupied space visible before the player commits resources.

## Decisions still required

M1 selects its first-flight controls, beacon objective, and essential ship systems above. Resolve later flight and route structure, mission objectives, expansion rules, and landing/departure costs when their dependent work begins. Consult [technical direction](../technical-direction.md), [roadmap](../roadmap.md), and [validation](../validation.md) for architecture, implementation order, and evidence. The opening recovery sequence is specified separately in [the tutorial](../tutorial.md).
