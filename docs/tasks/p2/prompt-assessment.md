# M1-P2 prompt assessment

**Authoring assessment, 2026-11-08.** The owner requested the entire Phase 2 prompt stack after reviewing the Prepare the factory plan. This assessment supports authoring and does not execute gameplay. The [roadmap](../../roadmap.md#m1-p2-prepare-the-factory) owns the selected criteria and progress; the [implementation plan](implementation-plan.md) owns task-level contracts.

## Outcome and source

The engineer retrieves finite starting ice and one pipe segment, carries the supplies, loads processor input, and installs the missing processor-output-to-tank connection. Supplies have actual owners and bounded destinations. The final ordinary P2 tank remains empty; manufacturing and powered movement are later Phases.

Source inspection used committed `main` [f274c896](https://github.com/jfin602/space-factory/commit/f274c89630a6033ccd79ad98b7fee6369dd5778a). That commit contains P1 implementation and Linux qualification at development checkpoint `0.1.4`. Its [closeout](../p1/closeout.md) records earlier uncommitted source identities accurately as historical evidence; its publication does not require inventing individual runner checkpoint commits.

| Inspected boundary | Consequence for P2 |
| --- | --- |
| `game/scenes/main.tscn` owns `Main/Ship/{Deck,Engineer,Helm}`; camera, beacon, and overlay are outside the ship | Machinery and connection visuals must use the existing ship frame. Keep a fixed authored arrangement. |
| `Ship.cs` owns Walking/Piloting, direction routing, and helm interaction | Extend one interaction owner. Separate per-machine E listeners would allow one press to trigger multiple actions. |
| `Main.RefreshHud()` currently shows helm-only help and clears walking feedback each frame | Present the current factory target and retain transaction feedback from authoritative interaction state. |
| Main's actual-scene checks assume a nearby helm around the initial engineer position | Explicitly position/select the helm in its checks when new interaction targets exist; preserve held-input and containment assertions. |
| The current unavailable-supply message is a capability placeholder; no inventory or tank exists | Add real state and show the actual empty reserve without implying that an installed pipe enables flight. |
| `tools/dev check` composes import, C# build, normal and translated-fixture smokes, scene automation, and a negative scene check | Reuse the composition for changed candidates and avoid separately repeating its components. |
| The runner uses Phase version subjects and a canonical Browser-required field | Prepare `0.2.0`, target `0.2.1`–`0.2.6`, and mark only final native P6 as Browser-required. |

Read the [module map](../../../MODULES.md) and affected source when execution begins; adapt to compatible newer work instead of restoring this snapshot.

## Scope and preserved behavior

Selected Gates are **M1-G2.1, finite inventory and nearby interaction**, and **M1-G2.2, player-installed connection**. Their native scenario is [M1-V02](../../validation.md#first-flight-milestone-m1). Preserve P1's one engineer, local containment, stationary world reference, exclusive controls, held-input cleanup, and labeled spatial fixture.

The resource surface is deliberately small: ice, the one pipe part, and propellant storage. A fixed crate, processor, tank, engine, and socket provide the needed owners and targets. Named starting amounts and capacities remain implementation tuning values; they must be finite, inspectable, and large enough to exercise preparation while retaining recovery options for subsequent balancing.

Construction is installation into one defined socket. The starter solar supply is already connected in the adopted M1 design; P2 may represent its location/hookup, but electrical production rules belong with M1-P3 processing. No batteries, wiring network, or fuel grant is introduced.

## Decomposition and validation tiers

| Prompt | One coherent responsibility | Prerequisite | Tier and planning budget |
| --- | --- | --- | --- |
| P1 | Finite resource/storage ownership and bounded transfer operations | Committed qualified P1 ship plus prepared P2 baseline | T1; target 8 minutes including focused validation |
| P2 | Fixed ship-local factory composition and stable target positions | P1 state owner | T1; target 8 minutes |
| P3 | The nearby take/load workflow through one dispatcher and compact panel | P1 accounting and P2 targets | T1 plus immediate input/UI integration; explicit 10–15 minute exception |
| P4 | One-time pipe installation and a bounded route with actual endpoints | P3 interaction path | T1; target 8 minutes |
| P5 | Actual-scene preparation sequence and control/spatial regressions | P1–P4 focused evidence | T2 integration; budget 10–15 minutes |
| P6 | Native observation, scoped Gate decisions, and documentation closeout | P5 candidate and focused evidence | T3 plus T1 docs; allow the time required for native checks |

These are decomposition targets, not completion guarantees. P3's dispatcher, panel lifecycle, focus handling, and retained feedback form one player action boundary; splitting them would leave an ambiguous or unusable interaction intermediate. P5 and P6 intentionally integrate or observe work already introduced. If a task overruns, preserve progress and the specific remaining step; never waive required evidence or advance a version solely to meet the budget.

P1–P4 validate critical invariants before dependent work proceeds. P5 adds integration proofs rather than repeating each unit case without a reason. P6 observes appearance and actual input that headless checks cannot establish. No new generic test framework, screenshot harness, or runner changes are required.

## Risks and controls

| Risk | Required control |
| --- | --- |
| Resource duplication, negative stores, or silent loss at a full destination | One bounded transfer operation; source/destination quantities reconcile; reject invalid requests unchanged. |
| Inventories recreated by HUD refresh, panel open, mode change, or ship translation | One authoritative factory-state instance for the scenario, read by all views and actions. |
| One E press both opens cargo and enters the helm | One deterministic target selection and input dispatcher; handled panel input cannot propagate into another action. |
| A stale panel performs transfers after closing or walking away | Require the matching active panel opening and validate mode, target identity, range, stock, and capacity at the actual mutation. |
| Keyboard focus prevents walking or leaving the helm | Keep the existing Walking/Piloting owner; test UI focus and E/escape behavior through actual events and native play. |
| Success/error text disappears immediately | Retain an action result with a defined display lifetime or replacement rule; HUD reads that result. |
| Pipe installation duplicates a part or creates an ornamental-only connection | Atomically consume one carried part and change the explicit route; already-installed attempts leave state unchanged. |
| A flow test supplies free gameplay propellant | Use a fresh isolated C# state only under the smoke path; assert ordinary scene output/tank remain zero. |
| Full cargo exhaustion cannot be reached in the small native preparation loop | Exercise source exhaustion in focused rule checks; use loading with no carried ice for the native empty-source case unless depletion is reachable normally. |
| Native full-input feedback cannot be reached with chosen supplies | Require positive carrying/input capacities and enough cargo ice to fill processor input while leaving a reachable reserve for another load attempt. |
| New factory targets invalidate old helm-test positioning | Deliberately select the helm in existing checks; keep their behavior assertions rather than deleting them. |
| Version metadata is mistaken for a passed Gate | Set ordinary checkpoints only after required checks pass; final native results own the Gate decision. |

Repeated legitimate Take/Load actions may transfer additional available stock. The forbidden cases are duplicated handling of one event, invalid or impossible transfers, creation of resources, and repeated installation consumption. Do not write a regression that rejects every repeated valid action.

## Deferred work

M1-P3 owns the timed recipe, startup electricity behavior, normal scheduled delivery, production progress, output backpressure, and production time accounting. M1-P4 owns actual thrust, fuel consumption, coasting, and motion feedback. M1-P5 owns the objective and explicit playtest restart.

General inventories/building menus, arbitrary placement or pipe routing, conveyors, junctions, collision/pathfinding frameworks, crafting/salvage, power networks, save/load, survival, landing, and platform exports remain outside this stack. Keep gameplay source and the phase runner separate.

## Authoring and evidence disposition

Author the six prompts and support documents under `docs/tasks/p2/`, using the existing lowercase runner folder grammar. Prepare the root version at `0.2.0` and update current routing without changing P1 results or claiming P2 implementation. Validate the authored stack with the actual parser and inspect the current version/history contract separately.

Execution creates implementation and native qualification records, then a terminal closeout. The [README](README.md) defines their locations and continuation behavior. The required native handoff is explicit, and unavailable observations retain NOT OBSERVED status. A missing observation can be accepted for progression by the owner, but cannot become PASS through authoring or checkpoint metadata.
