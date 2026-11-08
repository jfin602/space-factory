# Development roadmap

**Status: proposed implementation sequence. Bootstrap work has begun; no Gate is yet qualified.** The sandbox is recorded in [development setup](development.md). The sequence can change as experiments provide evidence. Owner-confirmed requirements and unresolved choices live in [Decisions and questions](decisions-and-questions.md).

## First integrated slice

Prove this complete experience with a small amount of content: repair a stranded ship, manufacture travel supplies, scout a destination, land, survive a threat, build a surface facility, connect it to the ship, depart, and return to collect its accumulated output. Demonstrate a recoverable emergency and a separate terminal run.

The early interior-and-flight prototype is a useful milestone within this slice. The slice is complete only when the landing, danger, persistent outpost, return visit, and permanent-loss portions also work.

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
- Recover available materials, restore a basic power path, and operate initial equipment.
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
