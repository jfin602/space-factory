# Validation and evidence

**Status: planned gameplay checks; none of M1-V01–M1-V08 or V01–V20 have been qualified.** Bootstrap checks for the Godot sandbox are recorded separately in [development setup](development.md). This document defines how to assess the [roadmap](roadmap.md). Accepting the M1 plan adds check scenarios, not passing results.

## What counts as evidence

For each Gate, record the source revision, selected platform, scenario or seed, actions taken, expected outcome, observed outcome, and any unresolved gaps. Include screenshots or a short recording when spatial presentation matters, plus state values or logs when quantities and persistence matter.

Use three clear outcomes: **PASS**, **FAIL**, and **NOT OBSERVED**. A planned check is NOT OBSERVED. A build, mocked response, or attractive screenshot does not establish that an unobserved gameplay behavior works. Keep earlier failures when documenting a later repair.

## First-flight milestone M1

These scenarios assess [M1 — First Factory-Powered Flight](roadmap.md#milestone-m1-first-factory-powered-flight). Their identifiers are scenario references, not installed test commands. All currently have **NOT OBSERVED** results. Store source-bound results under the selected task's qualification records and link them from the roadmap; this document defines the scenarios rather than a second progress tracker.

| ID | Scenario and required observation | Roadmap Gates | Evidence scope |
| --- | --- | --- | --- |
| M1-V01 | Walk to deck limits; translate the ship and preserve engineer/interior local positions; approach/enter/leave the helm; only the active controller responds and exit clears thrust input. A stationary world reference makes translation visible. | M1-G1.1, M1-G1.2 | Spatial state checks plus live input/camera observation. |
| M1-V02 | Take finite ice from cargo, load processor input, and install the supplied pipe part once. Quantities reconcile, range/capacity limits hold, and the absent connection cannot deliver propellant. | M1-G2.1, M1-G2.2 | Focused accounting checks plus actual nearby interactions. |
| M1-V03 | Solar-powered processing starts with zero propellant, consumes inputs and produces outputs exactly once, retains accounted in-progress material when paused/blocked, and stops when ice is exhausted. Equivalent game time/actions at different rendering rates yield equivalent resources. | M1-G3.1; broader G0.2 | Focused recipe/time comparisons and visible state/progress. |
| M1-V04 | Missing/disconnected pipe prevents delivery; rate and receiving capacity bound transfer; full output eventually blocks production without loss; restoring capacity/connection resumes it. | M1-G3.2 | Integration trace of source/job/output/tank quantities plus failure feedback. |
| M1-V05 | Empty tank prevents powered acceleration; manufactured propellant permits thrust and is consumed without going negative. Depletion preserves coasting. Actual thrust matches effects; if braking exists, it uses the same supply. | M1-G4.1 | Propulsion/accounting integration and live movement relative to a landmark. |
| M1-V06 | Production continues while flying, walking aboard a coasting ship, and re-entering the helm. Camera/mode transitions preserve inventories, jobs, connections, local positions, and velocity. Stopping production leaves the existing reserve usable; real refueling restores thrust after depletion. | M1-G4.2 | Integrated state comparisons plus the actual player sequence. |
| M1-V07 | Startup guidance recognizes valid early actions; HUD/failed-thrust messages reflect actual state; the beacon objective completes through the factory-powered flight loop. Restart restores the defined fresh state, including zero propellant and motion, finite initial supplies, initial mode, and unfinished objective. | M1-G5.1, M1-G5.2 | Live objective/HUD/input observation and restart state comparison. |
| M1-V08 | Complete the fresh empty-tank-to-flight, starvation, recovery, and restart sequence below using only starting resources. | M1-G5.2, integrated M1 Gates | T3 running-game qualification on an identified Linux revision, supported by relevant T1/T2 checks. |

Run the smallest meaningful checks at each implementation boundary. Use the existing documented build/runtime composition once for an unchanged candidate where relevant; its main-scene smoke cannot prove flight, resource accounting, or usability. A native game is a GUI surface. If its input/appearance cannot be observed, record NOT OBSERVED and the required handoff rather than inferring success from a headless check.

### First-flight acceptance run

**Scenario M1-V08:** choose a documented finite starting supply sufficient for the beacon trip and one recovery demonstration. Preserve some reachable ice for recovery; do not inject extra resources during the run.

1. Start a fresh scenario with zero propellant, the missing pipe, initial finite ice/pipe supplies, and an unfinished beacon objective.
2. Enter the helm, request thrust, and observe no powered acceleration plus the actual empty-supply explanation. Leave the helm.
3. Retrieve ice from cargo and load processor input; record the source/carried/input quantities.
4. Install the missing pipe using the supplied part; confirm the part is consumed and the route exists.
5. Start processing, observe timed output and tank filling, and account for the consumed ice and produced propellant.
6. Take the helm and fly toward the beacon while observing continued production and real propellant consumption. Reach the beacon and observe objective completion before beginning the starvation exercise.
7. Leave the helm, walk aboard the coasting ship, stop the processor, then re-enter and continue using the stored reserve.
8. Consume that reserve; observe loss of further powered acceleration without an invented terminal loss or instant velocity reset.
9. Leave the helm and restore production using the remaining real ice; observe the tank refill, re-enter the helm, and regain thrust.
10. Restart playtest; confirm the defined initial supplies/layout, empty tank, zero motion, initial mode, and unfinished objective, then verify that another startup can begin.

Record input/visual evidence and the relevant quantities at the transitions. Keep T1/T2 results, real-game observations, and any missing checks distinguishable. This sequence does not qualify save/load, engineer death, respawning, permanent loss, landing, or Windows/macOS behavior. Review the original G0/G1 criteria individually before applying M1 evidence to those broader Gates.

## Scenario matrix

The identifiers below are references for future work, not test commands.

| ID | Scenario | Required observation | Best initial evidence |
| --- | --- | --- | --- |
| V01 | Restore the starter ship | Available finite resources support a complete recovery sequence | Manual play and resource trace |
| V02 | Starved or blocked machine | Missing input, power, or output space causes the correct stoppage and diagnosis | Rule checks and interface observation |
| V03 | Transfer and capacity | Source, destination, and in-transit quantities reconcile; full storage stops transfer | Automated accounting checks |
| V04 | Frame rate and game time | Equivalent game time and inputs produce equivalent resource results | Simulation comparison |
| V05 | Voyage forecast | Displayed known costs agree with execution; uncertain conditions are labeled | State trace and manual navigation |
| V06 | Zero fuel with recovery available | The run remains active and real ingredients or reachable salvage can restore propulsion | Manual recovery scenario |
| V07 | Exhausted survival reserves | Defined consumption causes engineer death and a terminal outcome | Rule checks and visible loss state |
| V08 | Enter, leave and view the ship | Position, hull, damage, and inventory remain consistent across views; two engineer entrances work on a larger hull, on asteroid and planetary sites | Manual spatial check and state comparison |
| V09 | Dock and depart during transfer | Quantities retain ownership; links disconnect; no later remote delivery occurs | Boundary checks and manual departure |
| V10 | Revisit an outpost | Its identity, buildings, deposits, buffers, and damage persist | Save/load and return excursion |
| V11 | Production while away | Inputs, power, throughput, and storage bound accumulated output | Normal/offscreen comparison |
| V12 | Unattended defenses | Defense costs and damage follow the selected model; report freshness is truthful | Reproducible event trace |
| V13 | Prepared and unprepared landing | Scouting and carried equipment change observable survival options | Paired manual scenarios |
| V14 | Facility loss with engineer alive | Infrastructure loss does not automatically kill a recoverable run | Manual retreat or alternate-route scenario |
| V15 | Save during an active run | Inventories, location, route progress, time, and outposts resume consistently | Round-trip state checks |
| V16 | Death followed by restart | A known terminal run cannot resume as a living engineer through normal loading | End-to-end persistence check |
| V17 | Interrupted or damaged save | Application failure is handled explicitly without silently inventing death or resources | Fault-injection check |
| V18 | New run isolation | New run identity and state do not inherit old supplies or facilities accidentally | Persistence isolation check |
| V19 | Complete expedition | Tutorial, travel, hostile landing, building, departure, and resupply return operate together | Recorded play on one revision |
| V20 | Collision and terminal ship crash | Repairable damage permits recovery; an explicitly unsurvivable crash permanently ends the run; application interruption is handled separately | Paired gameplay scenarios and terminal-state reload check |

## Confirmed requirement coverage

The IDs below refer to [the decision register](decisions-and-questions.md). The map shows where evidence is planned, not that any requirement has passed.

| Confirmed requirements | Planned Gates | Main scenarios |
| --- | --- | --- |
| C01–C02: 2D perspective and one engineer | M1-G1.1, M1-G1.2; G0.1, G3.1 | M1-V01; V08, V13 |
| C03: factory-supported ship operation | M1-G3.1 through M1-G4.2; G1.2, G2.1 | M1-V03–M1-V06, M1-V08; V02–V05 |
| C04: missions and exploration | G2.1, G5.2 | V05, V19 |
| C05: stranded-ship tutorial | M1-G2.1, M1-G2.2, M1-G5.1, M1-G5.2; G1.1, G1.2 | M1-V02, M1-V07, M1-V08; V01, V06 |
| C06–C07: permanent death, crashes, and irreversible exhaustion | G2.2, G4.1 | V07, V16, V20 |
| C08: landable planets, asteroids, and large objects | G3.1 | V08, V19; additional body content follows the same contract |
| C09: scouting and hostile inhabitants | G4.1, G4.2 | V12–V14 |
| C10: landed exterior and multiple access points | G3.1 | V08 |
| C11: connected surface factories | G3.2 | V03, V09 |
| C12: recurring visits to persistent facilities | G5.1, G5.2 | V10–V12, V19 |
| C13: repository documentation | Documentation integrity review | Relative links, decision labels, and source consistency |

## Focus testing on real risk

Automate rules that can silently break the game: conservation of resources, capacities, recipe costs, time accounting, connection ownership, terminal-state persistence, and supported offscreen calculations. Use representative boundary cases, including an input exhausting midway through an absence and storage filling before all available production time elapses.

Use manual play for readability, movement, targeting, landing-site choices, factory placement, entrances, warnings, and whether the tutorial explains the underlying cause of a failure. Combine both methods for important transitions such as undocking during a transfer or dying while a save is being written.

Do not create large test suites that repeat implementation details or expand testing without a concrete remaining risk. Introduce performance measurements when a representative target scene exists and set explicit budgets then. No performance result is assumed in these docs.

## Fair failure checks

Confirm that recoverable breakdowns remain playable. An empty fuel tank, destroyed outpost, or lost connection is not by itself proof that the engineer is dead. Conversely, ordinary reload or scene transitions must not reverse a terminal outcome. Check [Survival and runs](systems/survival-and-runs.md) when defining each failure cause.

For a loss caused by planning or supplies, the evidence should explain the relevant earlier commitment, available information, consumption, and final cause. This evaluates the information the game provided; it does not require every risk to be known in advance or every failed expedition to be recoverable.

## Documentation changes

For a documentation-only change, check relative links, file names, heading consistency, decision labels, and contradictions between system descriptions. Verify that examples and proposed mechanics are not presented as confirmed owner decisions, shipped behavior, or passed Gates. Review the diff for unrelated changes.

Update documentation when an implemented decision changes behavior, and link the corresponding Gate evidence. Keep runtime qualification distinct from document review so the project's progress remains truthful.
