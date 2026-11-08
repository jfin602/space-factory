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

## The ship as a working factory

**Recommended:** every major capability should have a visible supporting system. Propulsion depends on an available fuel or energy supply; repairs depend on usable material; exploration equipment depends on capacity the player has installed and supplied. Particular propulsion types, recipes, coolant rules, and power requirements remain undecided.

The player should be able to trace a capability back through the factory: engine to supply connection, connection to storage, storage to processor, and processor to its inputs. A stopped engine should expose the relevant failure rather than present an unexplained general ship penalty.

Preserve a useful industrial core aboard the ship. Surface facilities can increase throughput and replenish reserves, but the vessel remains the engineer's mobile workshop and survival system. Moving all repair and processing capability to an outpost should be a deliberate risky specialization, not the default required by the design.

Physical inventories matter. A component in a planetary warehouse is unavailable to an onboard repair machine until it has actually been transferred. The exact inventory model belongs in [factory and resources](factory-and-resources.md); this document establishes the intended relationship between location and availability.

## Travel and mission planning

**Recommended:** begin with destination-based navigation. The engineer selects a location and travel priorities, then works inside while the ship follows those orders. This is a proposal, not a decision to exclude manual piloting. Flight controls, continuous versus sector travel, and the meaning of travel time remain open.

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

Resolve flight controls, route structure, mission objectives, expansion rules, landing and departure costs, and which ship systems are essential in the first playable version. Do not infer an engine or technical architecture from this document; consult [technical direction](../technical-direction.md), [roadmap](../roadmap.md), and [validation](../validation.md). The opening recovery sequence is specified separately in [the tutorial](../tutorial.md).
