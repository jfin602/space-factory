# Validation and evidence

**Status: planned checks; none have been executed against a game implementation.** This document defines how to assess the [roadmap](roadmap.md). Documentation validation confirms the documents' integrity only.

## What counts as evidence

For each Gate, record the source revision, selected platform, scenario or seed, actions taken, expected outcome, observed outcome, and any unresolved gaps. Include screenshots or a short recording when spatial presentation matters, plus state values or logs when quantities and persistence matter.

Use three clear outcomes: **PASS**, **FAIL**, and **NOT OBSERVED**. A planned check is NOT OBSERVED. A build, mocked response, or attractive screenshot does not establish that an unobserved gameplay behavior works. Keep earlier failures when documenting a later repair.

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
| C01–C02: 2D perspective and one engineer | G0.1, G3.1 | V08, V13 |
| C03: factory-supported ship operation | G1.2, G2.1 | V02–V05 |
| C04: missions and exploration | G2.1, G5.2 | V05, V19 |
| C05: stranded-ship tutorial | G1.1, G1.2 | V01, V06 |
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
