# User experience and presentation

This document separates **owner-confirmed presentation requirements** from **recommended interface behavior** and scoped prototype choices. The M1-P1 ship, helm, basic mode/help/unavailable-supply overlay, and development spatial fixture are implemented and [natively qualified on Linux](tasks/p1/qualification/native-playtest.md); factory, flight, and later interfaces remain planned. The [game design](game-design.md) and [decision register](decisions-and-questions.md) govern scope.

## Confirmed player perspective

The game uses a top-down 2D perspective with one directly controlled engineer. The player builds factories inside a spaceship and, after landing, can view the vessel from outside, leave through its access ports, and build connected surface facilities. Larger ships can have multiple access ports.

The opening experience involves restoring a small stranded ship. Permanent engineer death ends the run. Presentation must support both understanding the machinery and recognizing consequential survival decisions.

## Accepted M1 interaction and feedback

**Scope: First Factory-Powered Flight, accepted for implementation planning on 2026-11-08.** The Walking/Piloting mode, nearby E helm hint, and truthful unavailable-propellant feedback are qualified under [M1-P1](tasks/p1/closeout.md); the rest of this milestone interface remains planned. See the [milestone plan](planning/p1/first-flight.md) and [roadmap](roadmap.md#milestone-m1-first-factory-powered-flight).

The player's immediate goal is to prepare the onboard factory, manufacture propellant, and fly to a beacon. Use a readable interior cutaway, recognizable hull boundary, and nearby interactions for the crate, processor, missing pipe socket, and helm. Simple **Take**, **Load**, and **Install** actions with counts are sufficient; a full inventory or construction interface is deferred.

| Player situation | Required M1 feedback |
| --- | --- |
| Walking or piloting | Show the current mode and relevant controls. Only that mode receives movement input; leaving the helm clears thrust input. |
| Taking or loading ice | Show available/carried quantities and the actual transfer result; explain empty supply or full destination. |
| Preparing the connection | Make the missing pipe and its endpoints visible; installing the supplied segment changes the real connection state. |
| Processing | Show progress and the actual running, switched-off, missing-input, or blocked-output state. |
| Flying | Show propellant reserve and a thruster effect only when thrust is applied. Stars and stationary beacons make movement readable. |
| Requesting thrust with no fuel | Explain the missing propellant and retain access to factory recovery; do not display a death result. |
| Completing the scenario | Mark the beacon objective from actual ship/world state and offer the explicit **Restart playtest** action. |

Objective prompts identify the next useful task and recognize valid actions completed early. The compact HUD should expose carried ice, processor state, tank quantity, and control mode without covering the machinery needed for the next action.

A wider camera view while piloting is optional. Every view observes the same ship and factory; switching views cannot pause or reset production, duplicate resources, or replace the engineer. Text and simple indicators should make causes understandable without relying on color alone.

Processor activity, visible pipe flow, tank fill, and actual thrust provide the essential feedback. Detailed art, complex transitions, general mission UI, and later survival/landing presentation remain outside this milestone. Restarting this development scenario creates its fresh test state; it does not introduce respawning into the permanent-failure design.

## Recommended spatial presentation

Use a readable interior cutaway during onboard work and an exterior surface view while the engineer moves outside. The roof or hull presentation can change when entering, but the player should retain orientation: which side of the ship they approached, where the entrance leads, and where a connected factory sits.

A matching interior and exterior hull footprint is recommended, not confirmed. Camera transitions, zoom levels, roof behavior, and whether interior activity remains partly visible from outside are open choices.

Make ports legible by function and current connection. Distinguish a personnel entrance from a material or power interface if those separate types are adopted. A connected pipe should visibly cross the ship boundary and lead to an understandable receiving system. Automatic reconnection or docking conveniences require explicit decisions rather than hidden inventory transfers.

## Make causes inspectable

The engineer needs to understand why a system is working or stopped. Machine inspection should show required inputs, available supply, output capacity, and the current blocking condition. Selecting a problem should help reveal the relevant connection or upstream machine.

For example, “Fuel processor stopped: no power available” is more actionable than a general warning icon. Further inspection can identify which active systems consume capacity. Use text and symbols alongside color so operating states remain distinguishable.

Prioritize information affecting the engineer's next decision. Routine production details can remain available on inspection; critical survival changes deserve attention without covering the machinery the player needs to repair.

## Navigation and landing information

**Recommended:** route selection presents accessible reserves, feasible production, estimated costs, arrival margins, and known resupply opportunities. Mark estimates and unknowns explicitly. Scouting information should distinguish observed hostiles from unexamined terrain; missing information must not be presented as a safe landing guarantee.

Risk information should explain a consequence and permit an informed commitment where the rules allow it. The interface should distinguish an impossible action, a risky action with known costs, and an action whose result is uncertain. Departure should expose dependencies that will be disconnected, including outpost power or material feeds.

See [ship and navigation](systems/ship-and-navigation.md) and [landings and outposts](systems/landings-and-outposts.md) for the proposed operating rules.

## Remote facilities and failure

An outpost report should identify the location, observation time, reported inventory, operating condition, and any forecast assumptions. Clearly label current telemetry, stale observations, and estimates. Communications loss is an information gap; it must not silently convert the last report into current truth.

During a crisis, show the survival resources that remain and the systems drawing on them. The player should retain access to inspection and recovery actions while the engineer remains alive. A zero-fuel reading alone must not communicate certain death when usable materials or accessible salvage remain.

After a terminal outcome, explain the recorded causes and the run's final state. Voyage records and reusable player-authored layouts are recommended carryover features, not approved progression systems. They would not restore the dead engineer or supply free construction materials.

Pause, time acceleration, saving, and how to conclude a hopeless wait require explicit decisions. See [survival and runs](systems/survival-and-runs.md).

## Proposed acceptance examples

- Entering or leaving preserves understandable spatial orientation and identifies the actual access port used.
- Inspecting a stopped machine reveals its current cause, rather than only its generic operating requirements.
- A transfer visibly has a source and destination; disconnected endpoints are distinguishable.
- Navigation and remote reports label stale information and uncertain assumptions consistently.
- Critical warnings describe consequences while leaving recovery controls usable.
- A run-ending screen reports an observed terminal outcome rather than guessing that the player has no possible solution.

These are targets for [validation](validation.md), not test results. Follow [the tutorial](tutorial.md) for onboarding, [technical direction](technical-direction.md) for implementation constraints, and [the roadmap](roadmap.md) for future sequencing.
