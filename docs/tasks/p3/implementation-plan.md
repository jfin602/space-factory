# M1-P3 implementation plan

**State: authored, not executed, 2026-11-09.** The selected scope is [M1-P3](../../roadmap.md#m1-p3-manufacture-propellant). [The README](README.md) indexes six prompts, [the assessment](prompt-assessment.md) explains their decomposition, and [preflight](preflight.md) handles the completed-P2 source and runner baseline before implementation.

## Source and prerequisite contract

The owner reports P2 ran and is complete. Published `main` at [ce163753](https://github.com/jfin602/space-factory/commit/ce163753d8973ccd018f2344c6175c52fe4b113d) still contains P1 plus its pixel-art update and the authored P2 stack: `Ship.cs` handles the helm, `Main.cs` owns HUD/smokes, and no implemented factory owner or P2 qualification record is published. Its root version is `0.2.0`. These are observations about available source, not grounds to replay or overwrite the completed owner checkout.

Before P3 execution, locate the actual P2 resource owner and read APIs, cargo/carried/input/output/tank capacities, pipe endpoints/transfer operation, tank-to-engine reference, context-panel/session dispatcher, HUD, and real C# check extension points. Record their actual paths and source identity in `qualification/implementation.md`. Read and retain existing P2 closeout/evidence when available; record missing historical evidence without inventing PASS or asking for another activation. Missing actual implementation dependencies prevent execution and must be reported precisely rather than rebuilt inside P3.

Preserve the completed P2 source, including compatible owner changes, any updated setup/MCP integration, and its actual engine/SDK pins. Use the repository's current development commands after inspection. The authored P2 contracts describe responsibilities; they are not proof that a particular class name exists. Likely integration surfaces remain `Ship.cs`, `Main.cs`, the actual factory/resource/interaction files introduced by P2, and `game/scenes/main.tscn`.

## Recipe and job contract

Introduce one fixed recipe with named finite positive values: **I ice per job**, **O propellant per completed job**, and **D game seconds per job**. Ice is discrete; preserve P2's finite numeric representation for propellant and its capacity rules. Choose D as a whole number of simulation quanta. Validate that the input buffer can hold I and the output buffer can hold O; no recipe catalog, chooser, or crafting framework is needed.

The processor starts **disabled**, with no job and zero output/tank. Loading or installing alone cannot manufacture material. Its enabled preference is separate from derived operating status. Start sets enabled true; Stop sets it false. Repeating either intent is idempotent and cannot reset a job or debit material.

Keep at most one active job with a stable local job identity, the committed input quantity, and retained progress/completion state:

1. When enabled, electricity is available, no job exists, input has at least I, and output has room for a complete O batch, debit I exactly once and create the job commitment.
2. Advance only that job's remaining work using authoritative simulation steps. The already-paid job can continue when the uncommitted input buffer becomes empty. Missing input prevents the next job.
3. Stop freezes job progress and retains its commitment. It neither refunds input nor discards progress. There is no cancel/refund feature in this phase.
4. At completion, credit O exactly once when enabled, sufficient electricity is available, and output can accept the entire batch; then retire that commitment. If a completed job cannot commit, retain that one completed waiting job and its accounted material until all three conditions hold. Never overwrite it, debit another input, or emit partial/duplicate recipe output.
5. A full output prevents the next job from starting. Resuming after output space returns uses the same retained state. Define whether a newly started job progresses from the next tick or the remaining part of the current tick; use one consistent rule and never charge elapsed time twice or discard overshoot.

Use one operating-status precedence: disabled → Off; insufficient electricity → No power; completed job awaiting output room → Blocked output; active paid job → Running; no job with insufficient input → Missing input; otherwise insufficient full-batch output room → Blocked output; otherwise eligible processing → Running. Keep retained progress visible under Off/No power/Blocked output. The active art follows actual work, so eligibility before the next tick does not fabricate activity. Start, progress, and output commitment all require enabled state and sufficient power; pipe delivery remains independent. Do not add a power-management UI.

For accounting, define job starts S and committed completions C. With no input/output disposal in normal P3, removed ice equals I×S, live job commitment equals I×(S−C), and manufactured propellant equals O×C. Cargo + carried + uncommitted input + committed job ice + completed-recipe ice equivalents must reconcile to initial ice. Output + tank equals produced propellant in normal P3. An isolated fixture withdrawal adds an explicitly measured sink term; do not compare unlike ice and propellant units without the recipe ratio.

## Clock and power contract

The installed, preconnected solar supply provides sufficient startup electricity independently of tank propellant. It creates no ice or propellant and stores no free fuel. A small explicit availability/capacity value is sufficient; no wiring graph, battery, day/night model, or generic energy network is introduced. Default ordinary scenario power is available for the one processor.

One owner advances the same factory instance once from the Godot physics path. Use a fixed positive simulation quantum and an accumulator for accepted finite positive elapsed game time. Keep fractional remainder between calls; execute all due steps without silently clamping or discarding elapsed time. Reject invalid/nonfinite/negative elapsed values without mutation; zero elapsed is a no-op. Retain time that a bounded work budget postpones rather than losing it. Do not add offline catch-up or global pause/time controls.

The fixed-step order is **deliver existing output, then advance/commit/start processor work**. P2 introduces the one clock/job driver; P3 binds the existing route into its delivery slot. Both operations receive the same quantum, once. New output becomes deliverable on the following tick. Define recipe-boundary handling so complete intervals and multiple due cycles are represented; no independent timers, render callbacks, panel callbacks, or second simulation instances may advance production/delivery.

Walking/Piloting and panel/camera changes do not pause or reset this clock. Stop affects only the processor job; the clock and pipe delivery continue. UI refresh and art animation read state. Keep quantum, processed step count/game time, and remainder inspectable enough for deterministic checks.

Compare equivalent total elapsed time and identical action schedules using several outer partitions, such as 30, 60, and 144 updates per second and a bounded irregular/hitch sequence. Apply Start/Stop/Load/Install at identical game-time boundaries, splitting supplied intervals at those boundaries; do not compare differently timed button presses. Compare complete inventories, job identity/commitment/progress, completion totals, connection state, simulation time, and remainder within a documented numeric tolerance.

## Delivery and backpressure contract

Use P2's actual processor-output → tank connection and bounded transfer operation. Each fixed step transfers at most available output, route rate×quantum, and receiving free capacity, with equal debit and credit. The installed tank-to-engine reference continues to report the actual reserve. P3 adds no engine consumption or other normal sink.

The missing pipe stops delivery, not electricity or a job whose own output has room. Continued manufacture eventually fills output and blocks new work. Installing the supplied segment enables delivery; freed output capacity permits production to resume. Full downstream tank similarly blocks delivery, fills upstream output, and eventually blocks production without losing paid material or creating multiple pending jobs.

Stopping the processor does not destroy output or tank contents. Already-produced output may continue flowing into the tank, so the tank need not stay numerically constant immediately after Stop. The combined output/tank reserve remains conserved, and the retained job cannot progress until resumed.

Tune named values against actual P2 configuration. Native play must be able to fill the disconnected output, retain at least one additional recipe's worth of reachable ice, install the one supplied pipe, and free enough output capacity to resume. The empty tank must have sufficient headroom to receive at least an output batch. Adjust only necessary starter tuning, document units/rationale, and keep enough finite supply for later flight/recovery balancing. A nominal recipe-output-per-second and delivery rate can be recorded now; useful flight balance is only provisional until M1-P4's consumption exists.

Also make the separate starvation/reload case reachable through the existing fixed Take/Load actions: one available initial load must finish all its paid jobs and leave input below I while connected output/tank storage still has room for at least one more reloaded job. Tune the named transfer batch, recipe, or capacities as needed; do not assume the player can select an arbitrary small amount or add a quantity editor/dump feature. P5 records the exact button sequence and expected counts for P6. Missing input means less than I with no active job; blocked output means less than O free space, which need not be literal zero input or a visually 100%-full buffer.

Test disconnection after installation and full-tank capacity restoration with isolated actual C# state if ordinary gameplay cannot perform them. A test may remove a known tank amount through a controlled fixture action and record it as a test sink. Do not add a normal dump/disconnect/debug-refill interface or an early engine consumer just to make these checks visible.

## Interaction and presentation contract

Extend the actual P2 processor context panel with explicit **Start** and **Stop** intents. Use its single dispatcher and matching active panel-opening/session guard, current target identity, Walking mode, and range checks. A stale callback from a closed/replaced opening cannot change enabled state. Keep E/Escape close, walking while the panel is open, deterministic targeting, and Piloting E exit. Opening/closing the panel or leaving its range does not disable an already-running processor.

Present enabled/Off preference, actual operating cause, retained cycle progress, input/output quantities, tank amount/capacity, solar availability, and pipe condition. Indicate flow only from positive real transfers; a short retained pulse is acceptable for readability. Keep transaction feedback and production state separate so HUD refresh cannot erase an action result or mutate resources.

Reuse the [starter pixel pack](../../art/starter-pack.md) and [art direction](../../art-direction.md): compatible processor idle/active variants, tank, pipe gap/connected, solar panel, and resource icons already exist. Drive active art from actual processing work, not just enabled state. Keep nearest filtering, registered sprite positions, and interaction/collision bounds independent of art size. Do not regenerate assets or show exhaust before actual thrust exists.

Fuel can now become positive while the ship remains unpowered. Empty-tank messages should reflect actual empty reserve; with stored propellant, explain that applied propulsion is not yet integrated. Do not falsely keep saying the tank is empty, and do not implement thrust to avoid updating that explanation. M1-P4 owns the consumption/movement boundary.

## Work order and evidence ownership

| Task | Bounded implementation | Immediate handoff |
| --- | --- | --- |
| Preflight | Map actual completed P2 source; prepare `0.3.0` before runner startup | Existing state/action/route/check APIs and evidence provenance |
| P1 | Recipe/job model and exact accounting | One retained job; no independent runtime timer |
| P2 | Solar availability and authoritative fixed-step driver | One clock, disabled fresh processor, correct time/remainder |
| P3 | Existing bounded route in that step order, blockage and recovery | Manufactured output reaches the same tank; explicit rate/capacity |
| P4 | Start/Stop, status/progress, real art/flow, truthful helm feedback | Player can operate and inspect the production loop |
| P5 | Accounting, time partition, actual-scene/mode/spatial integration | Source-bound candidate and precise native actions/configuration |
| P6 | Native qualification and one documentation closeout | Selected Gate outcomes and M1-P4 handoff |

## Verification and evidence

Inspect current `tools/dev` composition before running checks. In the published baseline, `./tools/dev check` imports, builds, runs ordinary and translated-fixture C# smokes, exercises saved-scene automation, and checks an expected missing-scene failure. Reuse the current composition once for each changed candidate; do not separately repeat its import/build steps. Use `./tools/dev doctor` only for unknown/changed readiness. No generic test framework, new CLI, or screenshot driver is required.

Focused checks must call the implemented C# state/operations. Integration must also exercise actual scene wiring and the existing action handlers. Preserve nonzero failure exits and required success markers: a failed assertion cannot reach an overall success result. Use isolated states for artificial capacity/disconnection/withdrawal cases and record their fixture-only quantities.

P1/P2 regressions still matter. Adapt the P2 assertion that ordinary output/tank remain zero into a fresh-start/disabled-state assertion; after valid Start and elapsed time, expect exactly manufactured quantities. Keep finite supplies, capacity/conservation, panel-session guards, full-body bounds, exclusive controls, held-input cleanup, stationary beacon, and ship-local machine/pipe alignment. The existing `p1-demo` remains a labeled development translation fixture, not powered flight.

| Required evidence | Scope |
| --- | --- |
| Empty-tank solar startup; timed one-time debit/credit; active job finishing after input empties | Focused job/clock checks plus visible progress/output |
| Stop mid-cycle, wait, resume the same commitment; repeated Start does not restart | State/progress trace and actual panel/native input |
| Missing pipe → output blocks → install → delivery and processing resume | Actual-scene accounting plus reachable native sequence |
| Full tank/disconnected route → capacity/path restored → resume without loss | Isolated actual simulation with any test sink explicitly accounted |
| Finite input exhaustion → no unpaid output → load remaining real ice → resume | Focused rule proof and native small-batch scenario |
| Rate/capacity and equivalent elapsed time/actions across partitions | Quantitative complete-state integration; visual timing is insufficient |
| Same state/clock during panel closure, Walking/Piloting, and translation | Actual-scene references/amounts plus native observation |
| Real positive reserve with unavailable applied propulsion | State/helm check plus honest player feedback; no exhaust/thrust |

P6 may use separate fresh launches for the disconnected recovery, pause/resume, and starvation/reload cases so earlier runs do not exhaust finite ice or fill the tank. Do not require normal-play full-tank draining before P4 supplies a consumer. Native work uses `./tools/dev run` and `./tools/dev p1-demo`, or their confirmed current equivalents. Observe the actual viewport, input focus, feedback persistence, progress, labels, and sprite alignment.

Execution appends `docs/tasks/p3/qualification/implementation.md` with source/dirty-state identity, mapped P2 APIs, parameters/units, commands, expected/observed traces, failures/repairs, and limitations. P6 creates `qualification/native-playtest.md` and `closeout.md` with actual input method and necessary durable artifacts. Generated temporary logs remain in existing ignored locations. None of those future records is prefilled as PASS during authoring.

## Version and runner contract

Folder `p3` uses runner Phase 3, baseline `0.3.0`, and assigned task versions `0.3.1`–`0.3.6`. The root published `0.2.0` is retained during authoring because completed P2 source is not published. Execute [preflight](preflight.md) first in the actual completed checkout; the baseline transition happens before the runner, not inside numbered P1. On a resumed P3 stack, reconcile real history/version instead of repeating that transition.

P1–P5 use `- Browser required: no.` and advance versions only after required scope/checks pass. The runner owns their implementation checkpoints; do not self-commit, push, or change active prompt text. Preserve package scripts/settings and actual engine/SDK pins. A process success or version increment does not certify gameplay.

P6 is the only final closeout and uses `- Browser required: yes.` for the required native handoff, including when `--closeout` is supplied. It can set `0.3.6` only when both selected Gates and the closeout pass; failed or unobserved required evidence retains `0.3.5`. Leave closeout changes uncommitted for human review. [The runner guide](../../phase-runner.md) owns resume/dirty-tree rules.

## Closeout and next Phase

Map actual results to M1-G3.1 and M1-G3.2. Reconcile the canonical roadmap, BOOT, task index/README, MODULES, and affected factory/UX/technical/current-version descriptions once. Preserve earlier P1/P2 failures and qualification provenance; a P3 pass does not fabricate missing P2 history or qualify unrelated broader Gates.

A qualified P3 hands M1-P4 a manufactured propellant reserve, one continuing production/delivery clock, retained stop/resume behavior, bounded connection/storage, and truthful capability feedback. M1-P4 then connects applied thrust and fuel consumption to those actual owners.
