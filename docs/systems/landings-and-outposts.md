# Landings and persistent outposts

This is a design specification for an unimplemented game. **Confirmed** features come from the owner; **recommended** behavior develops those features and remains subject to decisions recorded in [decisions and questions](../decisions-and-questions.md). See [game design](../game-design.md) for the overall loop.

## Confirmed experience

Planets, asteroids, and other large objects can support landings. Some planets have hostile inhabitants comparable in role to Factorio's biters. The engineer must be able to scope out a landing and arrive prepared to fight when necessary.

After landing, the player can view the spaceship from outside. Larger ships have multiple access ports. The engineer can leave the ship, build factories on the surface, and connect their output physically into the vessel. These facilities persist while the engineer travels elsewhere, allowing return visits to collect resources and supplies.

This establishes a network the player builds during a run: places become useful because of the equipment, connections, and infrastructure left there. Exact hostile behavior, surface generation, defenses, and remote-operation rules are not yet approved.

## Recommended expedition loop

Scout a location, prepare the ship, select a landing area, secure enough working space, establish production, connect the ship, load supplies, and depart. Later visits use and extend the same facility.

Preparation should reflect actual known conditions. A hostile site may justify combat supplies and repair reserves; an isolated asteroid may favor extraction equipment and independent power. Scouting should help the player make these decisions without guaranteeing complete knowledge of the entire location.

Landing placement can create useful choices if adopted: distance to deposits, access to terrain, defensible surroundings, and room for the current hull. Avoid silently declaring a particular gravity model, atmospheric simulation, or universal landing fee. Those mechanics need separate decisions.

## Ship exterior and access

**Recommended:** the landed exterior should correspond to the ship the player constructed. Hull size, entrance locations, and industrial connections should remain understandable when switching between the interior and surface views. Exact footprint matching is a proposed representation rule, not an established technical requirement.

The owner has confirmed multiple access ports, but their types remain open. A useful distinction would be personnel doors for the engineer and industrial interfaces for belts, pipes, and possibly electrical connections. A port could combine functions if the design makes that clear.

An industrial interface should connect to an explicit onboard destination or network. Surface fuel entering a ship should reach an actual tank or processing line. A loading interface must not imply access to every inventory aboard the ship or every facility on the planet.

## Production across the boundary

**Recommended:** treat the ship and the surface installation as separate operating systems joined by explicit connections. Each side owns its machinery, inventory, and operating state. A connected pipe, conveyor, or power cable transfers only the resource it supports, subject to the chosen transfer limits.

Possible arrangements include a surface mine feeding onboard processors, a surface refinery filling onboard tanks, and an onboard workshop supplying construction parts to an emerging outpost. These are examples, not settled recipes.

Production requires actual inputs. Storage is finite, and local deposits should be finite under the recommended resource model. Storage filling should stop or limit the affected output according to a visible rule; the system must not create unlimited reserves because the player is absent.

Before departing, the player needs to understand what disconnects. An outpost temporarily powered by the ship cannot continue at that output after departure unless it has another supply. Likewise, an onboard processor receiving surface feedstock must switch to available onboard inputs or stop. Disconnecting must preserve material already held on either side.

## Operating while the engineer is away

Persistence is confirmed. **The following remote-production and defense model is recommended.** An outpost may continue operating during travel and other in-game activity, constrained by deposits, inputs, power, output capacity, and any other adopted operating costs.

Defenses should consume the resources their design requires, such as ammunition or power. Forecasts can show expected endurance under stated conditions. Exact enemy escalation, attack timing, and damage simulation remain open; leaving a location should not itself secretly create an otherwise unjustified attack.

Remote operation can use simplified simulation while preserving resource limits and credible outcomes. Simulation rules belong in [technical direction](../technical-direction.md).

Remote reports must distinguish live telemetry, estimates, and the last received observation. A communication failure means the current condition is unknown; it does not prove destruction or continued safety. Display when an observation was made and which forecast assumptions may no longer hold.

Whether time advances while paused, saved, or the application is closed remains undecided. Do not introduce offline consumption or attacks as an incidental implementation choice.

## Stakes and recovery

Outposts increase reach but can also create dependence. A ship carrying minimal fuel may rely on a refinery at the next stop. That refinery exhausting its feedstock or losing its supply can invalidate the travel plan. Carrying reserves consumes ship space but preserves options.

The ship should retain a meaningful role in survival and repair. A mobile workshop can help rebuild a damaged facility; a working outpost can help restore a disabled ship. Both require existing materials and functioning pathways. Neither creates free resources or an automatic rescue.

Losing an outpost need not kill an engineer who still has another workable plan. A shortage becomes a terminal run outcome through the agreed survival rules, not merely because one facility stopped. See [survival and runs](survival-and-runs.md).

## Proposed acceptance examples

These examples describe desired future behavior, not completed validation:

- After leaving and returning, the engineer finds the same installation with production and damage reconciled to the adopted simulation rules.
- Loading a resource debits its source and credits its physical destination, including when a transfer stops partway through.
- A disconnected facility loses ship-supplied inputs; reconnecting restores only valid connections.
- An unattended installation cannot exceed its feedstock, power, defense supplies, or storage capacity.
- A stale report is visibly dated and does not masquerade as current inventory or safety information.
- A damaged facility leaves recoverable materials and functioning equipment available according to explicit damage rules.

See [factory and resources](factory-and-resources.md) for inventory behavior, [presentation](../ux-and-presentation.md) for connection visibility, and [validation](../validation.md) for the future evidence process.
