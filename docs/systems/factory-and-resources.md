# Factory and resources

The factory keeps the traveling spaceship operational and supports missions, exploration, and surface operations. This document describes resource relationships; [ship and navigation](ship-and-navigation.md) describes their use during travel.

## Confirmed foundation

The player controls one engineer in a 2D top-down game. The spaceship contains a factory, travels through space, and can land on planets, asteroids, and other sufficiently large bodies. The engineer can leave the landed ship, establish persistent surface factories, transfer their products into the ship, and revisit those locations as a network of outposts. Larger ships can provide multiple access ports; the exact division between entrances and industrial interfaces is a working design.

Resources matter to survival: exhaustion can leave the ship permanently stranded and end the engineer's life. The economy must preserve that possibility. Exact materials, recipes, equipment, transport mechanisms, and production rates are working design choices, not approved specifications. See [decisions and questions](../decisions-and-questions.md).

## The relationship between production and capability

The recommended rule is that every major capability depends on understandable equipment and supplies: stored products, continuous power, or replacement components after damage. Avoid giving every system the same generic upkeep meter.

These chains illustrate that relationship without committing to chemistry or balance:

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

See [game design](../game-design.md) for mission choice. Recipes, simulation frequency, and technology remain undecided.
