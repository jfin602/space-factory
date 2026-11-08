# Factory and resources

The factory keeps the traveling spaceship operational and supports missions, exploration, and surface operations. This document describes resource relationships; [ship and navigation](ship-and-navigation.md) describes their use during travel.

## Confirmed foundation

The player controls one engineer in a 2D top-down game. The spaceship contains a factory, travels through space, and can land on planets, asteroids, and other sufficiently large bodies. The engineer can leave the landed ship, establish persistent surface factories, transfer their products into the ship, and revisit those locations as a network of outposts. Larger ships can provide multiple access ports; the exact division between entrances and industrial interfaces is a working design.

Resources matter to survival: exhaustion can leave the ship permanently stranded and end the engineer's life. The economy must preserve that possibility. The M1 prototype choices below are accepted for that milestone; the broader resource catalog, equipment, transport mechanisms, and balance remain working designs. See [decisions and questions](../decisions-and-questions.md).

## Accepted M1 factory loop

**Scope: First Factory-Powered Flight, accepted for implementation planning on 2026-11-08; gameplay is not yet implemented or qualified.** The [roadmap](../roadmap.md#milestone-m1-first-factory-powered-flight) owns its Phases and Gates; the [milestone plan](../planning/p1/first-flight.md) describes the bounded scenario.

Use a fixed starter arrangement: finite ice in a cargo crate, one installed processor, a bounded propellant tank, and an installed engine. The tank begins empty. One missing pipe segment separates the processor output from the tank; the engine's tank connection is already installed. The engineer receives one spare pipe segment in the starting supplies.

| Stage | M1 behavior |
| --- | --- |
| Startup electricity | An installed, preconnected solar panel supplies the processor. It creates no ice or propellant. Batteries, power routing, and day/night simulation are outside M1. |
| Loading | Nearby take/load actions transfer ice through the engineer's inventory into the processor, debiting each source and respecting destination capacity. |
| Processing | One timed ice-to-propellant recipe consumes inputs and produces output exactly once. Recipe quantities, cycle time, and capacities are tunable implementation values. |
| Delivery | Installing the supplied pipe consumes that part and creates a physically represented route with explicit endpoints, a finite rate, and capacity checks. |
| Propulsion supply | The engine consumes actual propellant in the connected tank when applying thrust. No initial fuel grant substitutes for manufactured output. |

Production and delivery share authoritative game time and continue during walking and piloting. A camera or control-mode change cannot refill a tank, duplicate a job, or alter its rate. Expose running, switched-off, missing-input, and blocked-output states from the actual simulation.

Empty input prevents new production. Full output or downstream storage blocks work without losing committed material or generating duplicate products; restoring an available route permits progress. Transfers reconcile source, destination, and any in-flight ownership. Changing the pipe connection or stopping the processor affects new delivery; propellant already in the tank remains usable.

Tune the initial chain to support ordinary flying while ice remains. Starvation checks can stop processing or use a small finite input batch. Recovery uses remaining ice and the same production path, without hidden refills.

M1 construction is the single defined pipe connection. General machine placement, arbitrary pipe routing, conveyors, junctions, fluid pressure, salvage, and repair crafting follow later. The chain below remains illustrative beyond this accepted prototype selection.

## The relationship between production and capability

The recommended rule is that every major capability depends on understandable equipment and supplies: stored products, continuous power, or replacement components after damage. Avoid giving every system the same generic upkeep meter.

These chains illustrate that relationship without committing to chemistry or balance; the ice-to-propellant chain is selected for M1 above:

| Candidate chain | Capability | Useful tradeoff |
| --- | --- | --- |
| Ice → processing → propellant | Travel and maneuvering | Store a large reserve or devote space to manufacturing underway. |
| Ore → plates → components | Repairs and construction | Expand now or preserve material for damage. |
| Metals + electronics → drones | Collection and external work | Improve resource intake or spend components elsewhere. |
| Reactor fuel → electrical power | Machines and ship equipment | Choose priorities when simultaneous demand exceeds supply. |
| Recovered machinery → analysis or installation | New equipment | Decide whether an expedition justifies its preparation cost. |

The factory can prepare supplies during travel. A larger engine can expose a new bottleneck. Surface factories can specialize and replenish the returning ship. Production while unvisited remains undecided; persistence does not promise unlimited offscreen output.

## Logistics across ship and surface

The working design uses conveyors, pipes, storage, and connected machines. Their interfaces and the need for drones in the first version remain open.

Landing should connect two distinct inventories through actual transfer equipment. An entrance supports movement by the engineer; a port supports cargo or another defined service. They may share a location, but opening a door must not automatically pool every inventory on the planet with the ship.

Each transfer needs a source, destination, capacity, and visible operating condition. A full bay stalls loading. Disconnected equipment cannot supply a departing ship; goods already aboard stay aboard. See [landings and outposts](landings-and-outposts.md).

Factory layout should create understandable constraints. Storage competes with manufacturing equipment for hull space. Adding another machine helps only if its inputs, power, and output capacity support it. These are recommended sources of depth; exact tile sizes and placement rules are unresolved.

## Finite supply and recovery

Recovery must draw from existing material. Dismantling machinery or salvaging damaged sections may resolve a shortage; exact salvage yields remain a balance decision.

Recommended accounting rules:

- A consumed input is removed exactly once when its production transaction commits.
- A canceled job follows one explicit refund rule and cannot refund more than it consumed.
- Moving, unloading, dismantling, or repairing an object cannot duplicate its contents.
- A completed product appears once, including after interrupted saving or loading.
- Storage and energy limits apply consistently during normal operation and recovery.
- Recycling loops cannot create net material or usable energy without an explicit external source.

A reliable supply line should solve its ordinary task. Ambitions, environments, and understandable damage create further pressure. Successful automation earns time to explore and improve the ship.

## Information and acceptance scenarios

Show quantities, relevant consumption and production rates, blocked outputs, and the cause of stopped machines. Distinguish a usable reserve from raw material that still needs processing. Forecasts must explain their assumptions rather than imply certainty about unknown destinations.

Candidate acceptance scenarios for later [validation](../validation.md):

1. An engine drains stored fuel faster than the factory replenishes it; the deficit and remaining reserve are visible.
2. A full output container stops production without consuming inputs for nonexistent products.
3. Surface loading fills the ship and reduces the source by the same amount; leaving breaks the connection without duplicating either inventory.
4. The engineer sacrifices existing equipment for a finite recovery supply, with the lost capability remaining lost.
5. Save interruption during production or cargo transfer produces neither duplicate goods nor repeated consumption after recovery.

See [game design](../game-design.md) for mission choice. Beyond the scoped M1 recipe and the selected Godot/.NET stack, the wider content catalog, balance, and detailed simulation frequency remain to be defined.
