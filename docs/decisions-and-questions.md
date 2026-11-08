# Decisions and open questions

**Baseline date:** 2026-11-08. This register records the initial project discussion. It is a design record, not a claim of implementation.

## Provenance

- **S1 — Initial concept:** the owner described a 2D, Factorio-like factory world inside a traveling spaceship, where production keeps the ship operational while the player plans missions and explores.
- **S2 — Engineer and failure:** the owner chose a single engineer, a small stranded ship repaired as the tutorial, roguelike features, no respawning, and permanent loss through crashing or exhausting resources.
- **S3 — Surfaces and facilities:** the owner added landable planets, asteroids, and other large objects; hostile inhabitants; scouting and combat preparation; an exterior view of the landed ship; multiple entry ports; surface factories connected to the ship; and recurring resource visits.
- **S4 — Repository initialization:** the owner requested the complete initial plan be turned into project documentation in `jfin602/space-factory`, primarily under `docs/`.

Assistant elaborations are retained below as working designs. Their presence in these documents does not imply the owner separately selected every proposed mechanic, quantity, or technology.

## Confirmed requirements

| ID | Requirement | Source |
| --- | --- | --- |
| C01 | The game uses a 2D, top-down perspective inspired by the described factory-game viewpoint. | S1, S2 |
| C02 | The player directly controls a single engineer. | S2 |
| C03 | The spaceship travels through space, and its internal factory supports its operation and objectives. | S1 |
| C04 | Mission planning and exploration are part of the game. | S1 |
| C05 | The introduction begins aboard a small stranded ship; restoring it is the tutorial. | S2 |
| C06 | A run can end permanently. There is no engineer respawn within that run. | S2 |
| C07 | Permanent ship loss and irreversible resource exhaustion or stranding are possible causes of failure. | S2 |
| C08 | Planets, asteroids, and other large objects can be landed on. | S3 |
| C09 | Some destinations have hostile inhabitants; scouting, arriving prepared, and fighting them are relevant. | S3 |
| C10 | The landed ship can be viewed from outside, and larger ships can have multiple entry ports. | S3 |
| C11 | The engineer can build surface factories and physically connect resource supply into the ship. | S3 |
| C12 | Surface facilities persist between visits and can become recurring resource stops. | S3 |
| C13 | Initial project documentation belongs in this repository, with the detailed set under `docs/`. | S4 |

## Working designs to validate

These proposals connect the confirmed requirements into an implementable game. A task can adopt a scoped prototype assumption and record what it is testing; they are not all prerequisites to writing the first code.

| ID | Working design | Owning document |
| --- | --- | --- |
| W01 | Major capabilities depend on physical inventories, production throughput, power, and connected equipment. Recipe examples are provisional. | [Factory and resources](systems/factory-and-resources.md) |
| W02 | Interior and exterior represent the same hull; entrances and utility ports connect to actual interior systems. | [Landings and outposts](systems/landings-and-outposts.md) |
| W03 | Destination orders and travel priorities let factory work continue during flight. Exact piloting remains open. | [Ship and navigation](systems/ship-and-navigation.md) |
| W04 | Scouting and route forecasts distinguish known constraints from uncertainty and allow deliberate risks. | [UX and presentation](ux-and-presentation.md) |
| W05 | The tutorial has a finite, deliberately solvable resource configuration and generous learning margin. | [Tutorial](tutorial.md) |
| W06 | Resourceful recovery is possible until real supplies and capabilities are exhausted; an empty fuel tank alone is not a terminal-state test. | [Survival and runs](systems/survival-and-runs.md) |
| W07 | Surface production and defenses continue while away, limited by deposits, power, inputs, storage, and defensive supplies. | [Landings and outposts](systems/landings-and-outposts.md) |
| W08 | Outposts need independent supplies or power to continue operating after the ship leaves; remote reports can be stale. | [Landings and outposts](systems/landings-and-outposts.md) |
| W09 | Save-and-quit resumes the same living engineer; terminal death persists. Application crashes are not fictional deaths. | [Survival and runs](systems/survival-and-runs.md) |
| W10 | Capable factories solve routine problems, while new ambitions introduce greater demands. | [Vision](vision.md) |
| W11 | Recovered equipment, improved recipes, hull expansion, and varied destinations can provide progression. | [Game design](game-design.md) |
| W12 | Facilities persist across expeditions within a run. Cross-run world inheritance, blueprint carryover, and permanent unlocks remain undecided. | [Survival and runs](systems/survival-and-runs.md) |
| W13 | Simulation, presentation, persistence, and content definitions have separate responsibilities. | [Technical direction](technical-direction.md) |

## Open decisions

Resolve choices when they affect the next concrete implementation step. Do not require every row to be settled before starting a reversible prototype.

| ID | Decision | When it matters |
| --- | --- | --- |
| Q01 | Target platform, engine, language, input baseline, packaging, and initial hardware budget. No stack has been selected. | Before the runnable foundation is scaffolded. |
| Q02 | Intended run length, victory condition or open-ended objective, and expected session length. | Before long-term pacing and content balance. |
| Q03 | Simulation time, pause/build behavior, time acceleration, and whether any time advances while the application is closed. | Before integrating travel, remote production, and save/load. |
| Q04 | Authored versus procedural locations, seed rules, starting-layout variation, and resource distribution. | Before generating more than the small test world. |
| Q05 | Destination orders versus manual flight, travel representation, landing placement controls, and takeoff costs. | Before the first expedition implementation. |
| Q06 | Life-support model, engineer needs, damage sources, emergency reserves, and exact terminal loss rules. | Before survival and death are treated as complete. |
| Q07 | Combat controls, hostile behavior, damage/armor rules, ship vulnerability while landed, and whether space combat exists. | Before implementing the first hostile surface encounter. |
| Q08 | Hull construction model, expansion constraints, capacity, mass, cooling, and any gravity-related requirements. | Before expanding beyond the starter hull. |
| Q09 | Port types and placement, transfer rates, connector construction, and reconnection convenience. | Before the first complete docking workflow. |
| Q10 | Research and recipe unlocks, equipment progression, saved layout rules, and any cross-run progression. | Before broadening the content/progression system. |
| Q11 | Offscreen threat resolution, communications limits, report timing, and the level of simulation needed for remote facilities. | Before persistent remote defenses are qualified. |
| Q12 | Art direction, asset dimensions, camera transitions, audio style, and detailed accessibility/input options. | Before investing in production presentation assets. |

## Scope and design risks

- **Permanent loss versus investment:** run length and factory complexity must work together. Large rebuilding costs need deliberate pacing and useful lessons from failure.
- **Maintenance fatigue:** repeated arbitrary breakdowns can overwhelm exploration and automation. Prefer legible causes and durable solutions.
- **Overreliance on settled bases:** preserve meaningful onboard survival and repair capability so the ship remains central.
- **Unreadable terminal situations:** explain deficits and remaining options without pretending the game can always prove that no creative recovery exists.
- **Remote simulation exploits:** viewing, unloading, traveling, or saving must not change output through duplication or inconsistent time accounting.
- **Early scope growth:** prove a small integrated voyage and outpost loop before building a large universe or every candidate mission type.

## Updating this register

For a new consequential decision, record the date, the choice, why it was made, its source or approving task, and affected documents. Move a working design to confirmed only when there is an actual decision. Update implementation status separately using evidence from the roadmap and validation process.
