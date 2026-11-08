# M1-P1 closeout — A coherent ship

**Disposition, 2026-11-08:** M1-G1.1 **PASS**, M1-G1.2 **PASS**, and M1-P1 **COMPLETE** for the selected coherent-ship scope. The broader G0/G1 Gates and M1-P2–P5 remain unqualified. P1–P4 were executed manually on uncommitted `main` HEAD `4ec4b625b7948f02ba6df938263eea7e763dc579`; no runner checkpoint commit was made. Final gameplay source identity and native environment are in [native-playtest](qualification/native-playtest.md#source-and-method). The accepted root checkpoint is `0.1.4` after this closeout.

## Implementation

`Ship` owns the deck, engineer, and helm in `main.tscn`; the camera/HUD and world beacon remain outside it. The deck supplies the same local bounds to drawing and full-body engineer containment. `Ship.cs` owns nearby helm interaction, one Walking/Piloting mode, exclusive direction routing, transition cleanup, and the missing-propellant reason. `Main.cs` presents actual mode/help/feedback, checks the real scene, and runs the explicitly flagged spatial fixture. Normal play has no applied ship propulsion. The fixture translates the real ship from `(480,300)` to `(420,300)` and holds it while the beacon stays at `(930,300)`.

The P4 native pass found title/hull and label/hull overlap in the first fixture. The bounded source repair changed its Y offset to zero and moved/shortened the fixture label. The failed frame, repair, final source hashes, and rechecks are retained in [implementation evidence](qualification/implementation.md#p4-applicability-and-bounded-native-repair-2026-11-08) and [native results](qualification/native-playtest.md#failure-repair-and-limits).

## Verification against selected Gates

| Roadmap criterion | Result and evidence |
| --- | --- |
| G1.1: deck/grid aligned with hull; engineer bounded to it | **PASS.** The real-scene smoke checks shared deck bounds and body inset at every edge/corner. Native normal and translated corner captures show the complete body inside the readable hull/deck/grid: [normal corners](qualification/native-playtest.md#normal-play), [fixture corners](qualification/native-playtest.md#explicit-spatial-fixture). |
| G1.1: ship movement carries interior with local positions/grid unchanged | **PASS.** Actual-scene fixture asserts unchanged local deck/engineer/helm positions and translated globals; sampled native frames show deck and engineer shifting together by 46 pixels. [Motion evidence](qualification/native-playtest.md#explicit-spatial-fixture). |
| G1.1: stationary external landmark and observable spatial result | **PASS.** Beacon remains x `915..944` through native motion frames while ship moves, and the flagged smoke asserts landmark world `(930,300)` throughout. [Motion evidence](qualification/native-playtest.md#explicit-spatial-fixture). |
| G1.2: approach helm, enter Piloting, leave to Walking | **PASS.** Native E press outside range is refused; near E enters once, exit and repeated presses switch once per edge. The translated fixture repeats range and mode behavior. [Normal and fixture interactions](qualification/native-playtest.md). |
| G1.2: exclusive movement input | **PASS.** WASD and right arrow walk in Walking. Native holds of all four directions in Piloting leave engineer/ship fixed; actual-scene `SPACE_FACTORY_P2_CONTROL_OK` and `SPACE_FACTORY_P3_FRAMES_OK` measure Walking versus pilot requests on the same control path. [Normal play](qualification/native-playtest.md#normal-play), [implementation evidence](qualification/implementation.md). |
| G1.2: clear held thrust on exit, preserve engineer local position | **PASS.** Real-scene check measures request and velocity `(0,0)` immediately on exit, and held-direction physics frames resume only Walking. Native entry/exit/repeat images show no jump or stored ship motion. [Normal transitions](qualification/native-playtest.md#normal-play). |
| G1.2: show mode and real unavailable-propulsion condition | **PASS for this phase.** HUD follows `Ship.Mode`; pilot request displays “No propellant supply available. Ship remains stationary.” No tank or supply chain exists yet, so the state is a truthful unavailable capability, not a simulated empty tank or fuel meter. The real tank belongs to M1-P2/P3. [Pilot view](qualification/images/normal-pilot-right.png), [control evidence](qualification/implementation.md). |

`./tools/dev check` passed after the final scene/script repair: import, 0-warning/0-error C# build, ordinary and fixture real-main-scene smokes with required success markers, saved-scene automation, and the expected missing-scene failure. Native `./tools/dev run` and final `./tools/dev p1-demo` launched and closed cleanly with exit 0. [Native playtest](qualification/native-playtest.md) records actions, captures, measured pixels, and the auxiliary capture-helper timeout. No failure was treated as a success marker.

## Progression

**Next gameplay scope: M1-P2 — Prepare the factory.** It must add real finite starting supplies, nearby cargo/processor transfer, one installable pipe route, and a real initially empty propellant tank/engine chain. Retain `Ship` as the mode/capability owner and the current ship-local frame. Feed real supply state into the unavailable reason when the factory/propulsion work warrants it; do not treat the P1 development fixture as powered flight.

Windows/macOS native play and exports, factory transfer/production, actual thrust, landing, survival, and saves remain **NOT OBSERVED**. Broader G0/G1 and later M1 Gates keep their existing roadmap statuses. This manual, uncommitted P1–P4 sequence has package checkpoints in the working tree but no runner Git checkpoint history; reconcile that history before any future runner resume. Reviewable source and evidence are left uncommitted and unpushed.
