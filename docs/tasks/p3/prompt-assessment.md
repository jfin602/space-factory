# M1-P3 prompt assessment

**Authoring assessment, 2026-11-09.** The owner reports P2 ran and is complete and requested `/prompt-ass + /prompt-plan + /prompt-write p3`. The next scope is [M1-P3 — Manufacture propellant](../../roadmap.md#m1-p3-manufacture-propellant), with M1-G3.1 and M1-G3.2. This document assesses the work; it is not implementation or qualification evidence.

## Source and uncertainty

Published `main` at [ce163753](https://github.com/jfin602/space-factory/commit/ce163753d8973ccd018f2344c6175c52fe4b113d) contains P1 gameplay and the newer pixel-art pack. Its `Ship.cs` is still helm-only, the module map has no implemented factory owner, package metadata remains `0.2.0`, and the P2 closeout is absent. Only `main` was published when checked. The authored [P2 contracts](../p2/implementation-plan.md) and the owner's completion report therefore supply the expected predecessor behavior, while the actual completed P2 implementation remains to be reconciled in its checkout.

This limits exact source/API mapping, not authoring of the next bounded outcome. The stack explicitly extends the implemented P2 owners; it never prescribes an invented existing class or rebuilds missing P2 work. [Preflight](preflight.md) resolves that mapping and the version transition before execution. Existing evidence is retained when available; missing historical observations remain gaps without adding an approval step to the owner's authorized progression.

## Player outcome and selected Gates

The engineer loads ice using P2's actions, starts the processor, observes timed manufacture, and watches real propellant reach the tank through the installed pipe. Production can be stopped and resumed; missing input or blocked output has a visible cause. Walking, Piloting, panel changes, and ship translation retain the same jobs, supplies, and game time.

M1-G3.1 requires one accounted timed recipe, initial solar startup with zero propellant, retained paused/blocked work, exhaustion behavior, and equivalent results for equivalent game time/actions across rendering rates. M1-G3.2 requires the real bounded route, capacity/disconnection handling and recovery, consistent state across modes/views, and documented tuning suitable for the later flight integration. Actual flight balance cannot be qualified before M1-P4 implements its consumer.

Preserve finite cargo/carried/input/output/tank ownership, the one installed-pipe transaction, active-panel validation, the single control owner, ship-local geometry, and P1/P2 checks. Extend the processor panel and existing art; avoid another inventory, interaction dispatcher, or game clock.

## Decomposition

| Prompt | Coherent outcome | Immediate dependency | Tier and planning budget |
| --- | --- | --- | --- |
| P1 | One timed job with exact input commitment, retained progress, and one output commit | Actual P2 state mapped; `0.3.0` prepared | T1; target 8 minutes including checks |
| P2 | Starter solar and one authoritative fixed-step clock driving the job | P1 job operations | T1; target 8 minutes, up to the 15-minute ordinary budget if clock wiring needs it |
| P3 | Existing route driven by that clock, with rate/capacity/backpressure recovery | P1/P2 plus actual P2 pipe operation | T1; target 8 minutes |
| P4 | Nearby idempotent Start/Stop and real status/progress/flow/art | Integrated P1–P3 simulation | T1 with coupled UI integration; explicit 10–15 minute allowance |
| P5 | Complete production/delivery/time and real-scene regression evidence | P1–P4 focused results | T2 integration; allow 10–15 minutes |
| P6 | Native production and recovery observations, Gate decisions, and closeout | P5 candidate | T3 plus T1 docs; time needed for the real scenarios |

Targets guide decomposition, not qualification shortcuts. P4's intent, panel-session checks, state precedence, and feedback are one visible workflow. P5 and P6 combine already-introduced behavior and can take longer. Preserve a precise continuation if interrupted; incomplete required checks cannot advance a checkpoint.

## Main contracts and risks

| Risk | Required control |
| --- | --- |
| Input charged every update or output credited twice | One job-owned commitment and exactly one completion transition; no recipe logic in drawing or controls. |
| Stop loses paid material or restarts the cycle | Stop pauses the retained job; Start is idempotent; no cancellation/refund feature is introduced. |
| Empty input incorrectly stops a job already paid for | An active job uses its commitment; input availability gates the next job. |
| Output blockage destroys inputs or makes unlimited pending jobs | Check full-batch room before new input debit; keep at most one active/completed waiting job. |
| Missing pipe prevents all processing and hides output-buffer behavior | Pipe availability gates delivery; processor can run while its own output has room. |
| Frame partitions create different production or discard time | One fixed quantum, retained remainder, explicit step order, identical action timestamps, and complete-state comparisons. |
| Rendering, UI, and physics each advance the factory | One production/delivery entry point, called by one physics owner; presentation reads only. |
| Stopping appears to lose output because the tank still changes | Pipe delivery may drain existing output while the processor is off; account for output plus tank together. |
| Full-tank recovery requires a nonexistent engine sink | Prove capacity-restored recovery in isolated actual C# state with an explicitly accounted test withdrawal. No gameplay dump/debug-fuel feature. |
| Native blocked-output recovery is unreachable with tuning | Ensure finite ice can fill disconnected output while retaining a job's input and tank headroom; recover by installing the supplied pipe. |
| Filled tank still displays an empty-fuel failure | Present actual fuel amount and the still-unavailable applied-propulsion capability separately. |
| New production invalidates old zero-fuel checks | Keep zero-output/tank assertions at fresh/off boundaries; expect manufactured output only after valid processing. |
| Pixel visuals indicate activity without simulation work | Active processor and flow indications follow real progress/positive transfer, not the enabled flag alone. |

The [implementation plan](implementation-plan.md) makes these choices concrete. Resource amounts, recipe duration/yield, capacities, and rate remain named tuning values. Choose them together after reading actual P2 configuration; preserve real ownership and document any bounded adjustment.

## Verification strategy

Use actual C# rules and the actual main scene, reusing the existing smoke/check composition. P1–P3 prove their accounting and time boundaries before dependent work proceeds. P4 proves the control/state adapters; P5 compares the full production/delivery state and checks scene/mode integration. P6 observes input, progress, labels, artwork, and recovery in the running game.

The native recovery case is deliberately achievable without flight: process with the original pipe absent, fill the output buffer, observe blocked state, then install the supplied pipe and see delivery/resumption. Stop/resume and starvation/reload can use separate fresh launches to retain finite resources and tank space. A fresh launch is not a new save/restart feature.

Disconnected-after-install and full-tank-capacity-restored cases use isolated real simulation state. Test fixtures must identify any manufactured or removed quantity and cannot seed normal play. Exact rate limits and render-partition equivalence require quantitative traces, not a visual impression. A native empty tank alone cannot prove route enforcement.

## Deferrals and disposition

M1-P4 owns applied thrust, engine fuel consumption, coasting, and exhaust. M1-P5 owns the beacon objective, complete starvation/refueling flight sequence, and explicit Restart playtest. General crafting, building, logistics, power networks, solar day/night, batteries, saves, offline simulation, global pause/time acceleration, survival, and platform export qualification remain outside P3.

Publish the assessment, plan, preflight, and six executable prompts under `docs/tasks/p3/`. Keep the root version unchanged while the completed P2 source is unavailable; document the exact pre-run `0.3.0` transition. Validate parser grammar separately from actual baseline readiness. Current routing can acknowledge the owner's P2 completion and P3 authoring without inventing P2 Gate evidence or P3 results.
