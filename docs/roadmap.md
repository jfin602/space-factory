# Development roadmap

**Status: M1 First Factory-Powered Flight plan accepted on 2026-11-08; gameplay implementation remains NOT STARTED.** The bootstrap is committed, with its evidence in [development setup](development.md). Existing G0.1 remains IN PROGRESS; no roadmap Gate has been qualified. [Decisions and questions](decisions-and-questions.md) records the owner instruction and the scope of the accepted prototype choices.

## Milestone M1: First Factory-Powered Flight

**Player outcome:** walk around the starter ship, prepare its small factory, manufacture propellant, take the helm, and fly toward a beacon using the manufactured supply. Production continues during flight. Stopping production leaves stored propellant usable; exhausting that reserve removes further powered acceleration; manufacturing more restores thrust.

This is the immediate playtest target. Its five Phases expand the existing foundation and stranded-ship work in broader Phases 0 and 1 below. The `M1-Pn` and `M1-Gn.n` identifiers distinguish these implementation increments from the existing `P0`–`P5` / `G0.1`–`G5.2` expedition roadmap. Existing identifiers and unqualified results are preserved.

[The milestone design](planning/p1/first-flight.md) owns the bounded scope, inspected source, implementation boundaries, and deferrals. The owning [factory](systems/factory-and-resources.md), [ship](systems/ship-and-navigation.md), [tutorial](tutorial.md), and [presentation](ux-and-presentation.md) documents specify the adopted M1 behavior. [Validation](validation.md#first-flight-milestone-m1) owns the check scenarios. This roadmap is the single authority for Phase/Gate progress.

### M1 order and evidence

| Phase | Observable outcome | Dependency | Broader Gates served | Status |
| --- | --- | --- | --- | --- |
| M1-P1 — A coherent ship | Ship-relative interior, world reference, and exclusive walking/piloting modes | Committed bootstrap | G0.1, foundation for G0.2 | NOT STARTED |
| M1-P2 — Prepare the factory | Finite supply can be loaded and the missing pipe installed | M1-P1 | G0.2, G1.1 | NOT STARTED |
| M1-P3 — Manufacture propellant | Timed production and bounded delivery fill the tank | M1-P2 | G0.2, G1.2 | NOT STARTED |
| M1-P4 — First powered flight | Manufactured propellant enables and sustains real thrust | M1-P3 | G1.2 | NOT STARTED |
| M1-P5 — Complete the playtest | Fresh startup, beacon objective, starvation/recovery, and restart work together | M1-P4 | G1.1, G1.2 | NOT STARTED |

All M1 gameplay checks are currently **NOT OBSERVED**. The [p1 stack](tasks/p1/README.md) is authored for M1-P1 only, with three implementation/integration prompts and a required native checkpoint/closeout; it has not been executed. Its prepared 0.1.0 runner baseline and authoring validation do not qualify gameplay. Attach source-bound task evidence to the relevant Gate as work executes, following [the workflow](workflow.md). Focused checks support the integrated result; actual input, appearance, and the player loop require observation in the running game. Existing build/smoke evidence does not qualify future gameplay.

M1-P4 delivers the core first-flight behavior. The full milestone passes when all ten M1 Gates pass, including the repeatable scenario in M1-P5. Review the original G0/G1 criteria against the same evidence before changing those broader statuses; milestone completion does not automatically qualify unrelated criteria or any later expedition Phase.

### M1-P1: A coherent ship

**Outcome:** the engineer walks inside a recognizable ship situated in space. The interior uses ship-local coordinates; the ship itself has a separate world position.

**M1-G1.1 — Ship and interior ownership — NOT STARTED**

- Align the existing deck/grid with the starter hull and express engineer movement bounds relative to that deck.
- Changing ship world position carries the deck, engineer, and installed interior objects together, preserving their local positions and grid alignment.
- Provide a stationary external landmark so world movement can be distinguished from camera movement.
- Observe the spatial result in the game; a bounded translation fixture may establish this Gate before production-powered flight exists, without counting as M1-G4.1 evidence.

**M1-G1.2 — Helm and control modes — NOT STARTED**

- Let the engineer approach and interact with the helm to enter Piloting mode and leave it to restore Walking mode.
- Route movement input exclusively to the active controller; walking input must not also command the ship.
- Clear held thrust requests on helm exit and preserve the engineer's local position.
- Show the active mode and the actual unavailable-propulsion condition while the tank is empty.

### M1-P2: Prepare the factory

**Outcome:** the engineer uses real starting supplies to prepare a small, mostly installed factory. Use a cargo crate, processor, tank, engine, and one missing pipe socket between processor and tank.

**M1-G2.1 — Finite inventory and nearby interaction — NOT STARTED**

- Supply finite ice and one spare pipe segment in the scenario's starting inventory; begin with an empty propellant tank.
- Let the nearby engineer take ice from cargo and load it into processor input through simple quantity-based actions.
- Debit the source and credit the destination once, respecting available stock and destination capacity.
- Reject out-of-range or impossible transfers with readable feedback; repeated interaction cannot create resources.

**M1-G2.2 — Player-installed connection — NOT STARTED**

- Show the missing pipe segment in the actual interior and let the engineer install the supplied part there.
- Consume that part once and establish a real processor-output-to-tank connection with explicit endpoints and a finite transfer rate.
- With the segment absent, processor output cannot reach the tank. The preinstalled tank-to-engine connection supplies only propellant actually stored in the tank.
- Keep this to the defined socket; arbitrary pipe routing, junctions, and general machine placement are later work.

### M1-P3: Manufacture propellant

**Outcome:** ice is processed over time and delivered through the installed pipe into bounded storage. The installed starter solar supply provides processor electricity without manufacturing material or propellant.

**M1-G3.1 — Accounted production — NOT STARTED**

- Start a timed ice-to-propellant job only when its requirements are satisfied; expose progress and running, off, missing-input, or blocked-output state.
- Account for recipe input and output exactly once. Paused or blocked work retains its accounted material and cannot duplicate its product.
- Exhausted input prevents further production. The initially empty tank does not prevent the solar-powered processor from making the first propellant.
- Advance production against one authoritative game clock; equivalent elapsed game time and player actions produce equivalent resource results across rendering rates.

**M1-G3.2 — Real delivery and capacity — NOT STARTED**

- Deliver produced propellant only through the working route, limited by transfer rate and receiving capacity.
- An absent/disconnected route stops new delivery; a full downstream buffer eventually blocks further production without silently deleting inputs or output.
- Restoring an available output path resumes delivery and production as their requirements allow.
- Walking, Piloting, and camera changes preserve the same inventories, jobs, connections, and game time.
- Tune ordinary output to support useful flying while feedstock remains; deliberate production shutdown supplies the starvation scenario.

### M1-P4: First powered flight

**Outcome:** helm input applies four-direction thrust to a fixed-orientation ship, with simple acceleration and a bounded speed. All normal-play propellant is manufactured by the factory.

**M1-G4.1 — Propellant enables thrust — NOT STARTED**

- From an empty-tank start, requesting thrust produces no powered acceleration; production subsequently makes that same control usable.
- Applied thrust consumes stored propellant at a defined rate without negative inventory or a separate free-flight fuel source.
- Exhausting the tank prevents further powered acceleration; existing velocity follows the adopted coasting behavior instead of being erased.
- Thruster effects correspond to actual applied thrust. If an active brake is included, it consumes the same propulsion supply.
- Observe real ship displacement relative to stationary space landmarks with readable camera framing.

**M1-G4.2 — The factory works during flight — NOT STARTED**

- Continue production and consumption against the same game clock while piloting.
- Ship motion preserves the engineer, machinery, grid, and pipe alignment in ship-local space.
- Exit the helm, walk while the ship coasts, and re-enter without resetting velocity, supplies, or production.
- Stopping the processor preserves usable propellant already in the tank. Depletion removes thrust; processing remaining ice restores it.

### M1-P5: Complete the playtest

**Outcome:** a fresh, authored scenario teaches the startup-and-flight loop and gives the player a visible beacon to reach.

**M1-G5.1 — Objective and feedback — NOT STARTED**

- Derive compact startup guidance from actual loading, connection, production, and flight state; recognize valid actions performed early.
- Show carried ice, processor state, tank quantity, control mode, and the cause of an unsuccessful thrust request.
- Use readable processor activity, connection/flow feedback, and actual thrust feedback; keep recovery interactions available.
- Reaching the beacon through the functioning factory-powered flight loop completes the objective.

**M1-G5.2 — Repeatable end-to-end playtest — NOT STARTED**

- Complete [M1-V08](validation.md#first-flight-acceptance-run) from the finite fresh scenario: empty tank, retrieve/load ice, install pipe, manufacture, pilot, and fly.
- Stop production, consume the stored reserve, observe loss of powered acceleration, then manufacture from remaining real inputs and regain thrust.
- Restart playtest restores the defined starting arrangement, supplies, empty tank, motion/control state, and unfinished objective. It is a development scenario reset, not engineer respawning or permanent-loss qualification.
- Run the applicable existing build/runtime checks once for the candidate and observe the complete interaction/camera/flight loop in the real game. Record failures and unavailable observations honestly.

### M1 scope boundary and next work

Linux is the immediate playtest target; Windows/macOS remain desktop targets requiring their own later export and native evidence. Fixed hull and installed machinery, one recipe, one pipe socket, and one beacon bound this milestone. General construction/logistics, ship rotation, damage/repair crafting, complex electrical systems, landings, combat, save/load, permanent-loss qualification, and outposts remain later work.

The next implementation scope is **M1-P1**, using its authored [p1 assessment, plan, and prompts](tasks/p1/README.md) under [the workflow](workflow.md). Authoring does not execute the stack; later M1 execution stacks remain to be written. After the first flight, use observed play to order richer placement, repairs, hull/propulsion improvements, and the following expedition work.

## First integrated slice

Prove this complete experience with a small amount of content: repair a stranded ship, manufacture travel supplies, scout a destination, land, survive a threat, build a surface facility, connect it to the ship, depart, and return to collect its accumulated output. Demonstrate a recoverable emergency and a separate terminal run.

M1 above is the accepted early interior-and-flight milestone within this slice. The broader slice is complete only when the landing, danger, persistent outpost, return visit, and permanent-loss portions also work. The original Phase/Gate identifiers below retain their meaning and evidence requirements.

Use one starter hull, a few recipes, a small destination set, and one initial hostile creature behavior. Resource quantities and timings are prototype tuning. Large content catalogs and a full procedural universe come after the loop is demonstrated.

The proposed Gates assume the working designs for physical logistics, save-and-quit, and constrained outpost operation. Resolve the relevant open decisions before implementing a dependent Gate, and update its criteria if a different design is selected. These assumptions are not additional owner-confirmed requirements.

## Gate evidence

A Gate passes when its listed behavior is observed on an identified revision and the relevant checks in [Validation](validation.md) pass. Record the revision, scenario, result, and remaining gaps. A Phase passes when all of its Gates pass. Builds and document completion alone do not prove gameplay.

### Phase 0: Runnable foundation

**Status: IN PROGRESS — sandbox foundation only**

**G0.1 — Stack and launch — IN PROGRESS**

- Record engine, language, initial platform, and the narrow reasons for choosing them.
- Launch a small 2D scene with actual documented setup instructions.
- Control an engineer and observe collisions or placement bounds in a ship-sized area.

**G0.2 — State and time — NOT STARTED**

- Separate authoritative state from input and presentation.
- Use stable entity identifiers and one explicit game clock.
- Demonstrate that rendering rate and view inspection do not change a fixed scenario's resource outcome.

### Phase 1: Restore the stranded ship

**Status: NOT STARTED**

**G1.1 — Solvable opening — NOT STARTED**

- Build the finite starting situation in [Tutorial](tutorial.md).
- Recover available materials, establish usable startup power, and operate initial equipment. M1 uses an installed solar supply to bootstrap production; more elaborate electrical repair is later scope.
- Show readable causes when a machine lacks an input or power.
- Demonstrate a recovery sequence using only resources genuinely available in the scenario.

**G1.2 — First functioning factory — NOT STARTED**

- Move a resource through processing and storage into a ship system.
- Consume the resulting supply to operate propulsion and show the first powered movement.
- Respect capacity, depletion, and consumption; changing views does not create supplies.
- Show that the player built the functioning connection rather than receiving an unexplained completion reward.

### Phase 2: A voyage with consequences

**Status: NOT STARTED**

**G2.1 — Bounded navigation — NOT STARTED**

- Choose between a few destinations and consume supplies while traveling.
- Present available route information and projected reserves with uncertainty identified.
- Continue onboard production against the same game clock.
- Recover from at least one zero-propulsion-fuel situation using real available inputs.

**G2.2 — Run persistence and loss — NOT STARTED**

- Save and resume a living engineer's state if that working policy is adopted.
- Demonstrate an actual resource-exhaustion death and a durable terminal run.
- Demonstrate a repairable collision and a separate unsurvivable ship crash under the chosen damage rules; only the unsurvivable event ends that scenario's run.
- Prevent normal continuation from reviving that engineer; a new run has a new identity.
- Exercise interrupted-save recovery separately from in-world death.

### Phase 3: Land and connect

**Status: NOT STARTED**

**G3.1 — Exterior, interior and access — NOT STARTED**

- Land on a persistent surface and walk between exterior and interior through an entrance.
- Exercise both an asteroid site and a planetary site using the same landing/access contract and minimal content.
- Derive the landed footprint from the ship layout.
- Demonstrate two usable engineer access points on a larger test hull, preserving position and orientation through each without creating a second inventory or ship. Qualify logistics transfer separately in G3.2; a port may combine functions under the selected design.
- Keep damage and engineer location consistent across views.

**G3.2 — Surface-to-ship factory — NOT STARTED**

- Place a small extraction/processing facility and physical loading connections.
- Transfer resources through compatible ports into actual ship storage or machinery.
- Disconnect on departure without duplication, loss of unrelated stores, or remote transfer.
- Preserve the facility, deposits, buffers, and connections across a save and return visit.

### Phase 4: Prepare for hostile ground

**Status: NOT STARTED**

**G4.1 — Scouting and combat — NOT STARTED**

- Obtain useful but explicitly bounded scouting information before landing.
- Manufacture or load the equipment required for the initial combat model.
- Encounter a hostile creature that can damage the engineer or relevant structures.
- Demonstrate meaningful preparation, a viable retreat, and terminal engineer death in separate scenarios.

**G4.2 — Defend the foothold — NOT STARTED**

- Protect a small facility using defenses with their defined resource costs.
- Interrupt a real loading or production connection through damage and explain the cause.
- Repair it using accounted supplies.
- Demonstrate that losing a facility can leave a living engineer able to continue when another viable route remains.

### Phase 5: Leave, return and qualify the loop

**Status: NOT STARTED**

**G5.1 — Persistent outpost operation — NOT STARTED**

- Advance an unattended facility through production, storage, and depletion limits.
- Account for its independent power and defense resources.
- Distinguish live telemetry from the last received report.
- Verify supported offscreen cases against the chosen simulation contract.

**G5.2 — Complete expedition — NOT STARTED**

- Play the complete first-slice sequence without debug grants or skipped systems.
- Return to an outpost, reconnect, and load the output it actually produced.
- Demonstrate an expedition affected by a failed or exhausted resupply stop.
- Run at least two reproducible resource/threat arrangements; full procedural-generation scope remains open.
- Record both successful survival and permanent loss, including the causes and saved outcomes.

## After the first slice

Use observed play to prioritize hull expansion, additional mission types, more varied locations, equipment discoveries, production depth, combat variety, and presentation polish. Set run length, victory structure, procedural scope, and any between-run carryover before scaling content around them.

Keep the next task small enough to have a visible result. Read only the relevant system documents, implement the selected Gate, and collect evidence before broadening work.
