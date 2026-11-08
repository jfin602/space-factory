# User experience and presentation

This document separates **owner-confirmed presentation requirements** from **recommended interface behavior**. It describes an intended experience; no interface or gameplay implementation exists yet. The [game design](game-design.md) and [decision register](decisions-and-questions.md) govern scope.

## Confirmed player perspective

The game uses a top-down 2D perspective with one directly controlled engineer. The player builds factories inside a spaceship and, after landing, can view the vessel from outside, leave through its access ports, and build connected surface facilities. Larger ships can have multiple access ports.

The opening experience involves restoring a small stranded ship. Permanent engineer death ends the run. Presentation must support both understanding the machinery and recognizing consequential survival decisions.

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
