# M1-P3 — Manufacture propellant

**Status: authored on 2026-11-09; NOT EXECUTED.** This stack implements [M1-P3](../../roadmap.md#m1-p3-manufacture-propellant), targeting **M1-G3.1** and **M1-G3.2**. The owner reports P2 ran and is complete and has requested this next stack. P3 authoring does not implement production or qualify either Gate.

## Source and execution readiness

The inspected published source is `main` at [ce163753](https://github.com/jfin602/space-factory/commit/ce163753d8973ccd018f2344c6175c52fe4b113d). It contains the qualified P1 baseline, starter pixel art, and authored P2 tasks, but still has a helm-only controller, no implemented factory owner, no published P2 closeout, and root package version `0.2.0`. The owner's completed P2 checkout must be reconciled before implementing this stack. This is a source-availability gap, not a claim that the owner's P2 work failed or should be repeated.

The [pre-run preparation brief](preflight.md) maps the actual P2 owners and prepares `0.3.0` before the runner launches P1. **The published root version is intentionally unchanged during this authoring step.** The runner checks its baseline before executing any prompt, so numbered P1 cannot perform that transition itself. Preserve completed P2 work and available evidence; do not rebuild it from its old prompts.

Read the [assessment](prompt-assessment.md) for decomposition and risks and the [implementation plan](implementation-plan.md) for the shared job, clock, delivery, and interaction contracts. Exact P2 class/method names are resolved from the completed checkout rather than invented here.

## Player outcome

Load real ice, start the solar-powered processor, watch a timed recipe produce propellant, and deliver it through the player-installed pipe into the tank. Stop and resume a job without losing paid inputs or progress. Missing input or output space stops the appropriate work; restored supply or capacity permits progress. Production and delivery continue while walking, piloting, or changing presentation.

A useful native sequence starts with the pipe still absent: manufacture into the output buffer until it blocks, then install the supplied pipe and observe delivery and production resume. No engine consumer is needed for that recovery. Powered flight, exhaust, and propulsion consumption remain M1-P4.

## Ordered prompts

| Prompt | Deliverable | Tier | Assigned version |
| --- | --- | --- | --- |
| [P1 — Timed processor jobs](P1-timed-processor-jobs.txt) | One retained job, exact recipe input/output accounting, and pause/resume | T1 | `0.3.1` |
| [P2 — Solar and factory clock](P2-solar-and-factory-clock.txt) | Independent starter electricity and one fixed-step game-time driver | T1 | `0.3.2` |
| [P3 — Bounded delivery and backpressure](P3-bounded-delivery-and-backpressure.txt) | Timed use of the actual pipe, storage limits, and blocked-work recovery | T1 | `0.3.3` |
| [P4 — Processor controls and feedback](P4-processor-controls-and-feedback.txt) | Nearby Start/Stop, real progress/status, existing art states, and truthful fuel feedback | T1 with bounded UI integration | `0.3.4` |
| [P5 — Production integration](P5-production-integration.txt) | Real-scene loop, equivalent-time accounting, mode/spatial regressions | T2 | `0.3.5` |
| [P6 — Native production closeout](P6-native-production-closeout.txt) | Visible production/recovery evidence and the two selected Gate decisions | T3 plus T1 documentation | `0.3.6` |

All six prompts recommend `GPT-6 Sol High`. Runner `Phase 3` and folder `p3` mean **M1-P3**, not the broader landing Phase 3. P1–P6 are task numbers inside this stack.

## Validate, prepare, and run

Grammar can be checked before P2 source synchronization or the version transition:

```bash
npm run space-factory:phase:validate -- p3
```

Complete the [preflight](preflight.md) against the actual completed P2 checkout, including its deliberate `0.3.0` baseline preparation. Then run from the repository root:

```bash
npm run space-factory:phase -- p3
```

P1–P5 are implementation/integration tasks. **P6 is the required native manual checkpoint and final closeout**, using the canonical `- Browser required: yes.` field. The runner pauses there even with `--closeout`. Native observation needs the running Godot game and suitable desktop tools or the owner's actual observations; browser access alone is insufficient.

## Version and continuation

The planned baseline is `0.3.0`; task checkpoints are `0.3.1`–`0.3.6`. Preparing that baseline is development metadata, separate from gameplay completion and engine/SDK pins. P1–P5 advance their assigned version only after their required work/checks pass. The runner owns their implementation commits; tasks do not self-commit or push.

Resume uses actual reachable P3 checkpoint subjects and the matching package version. Do not reset a partial implementation to `0.3.0`, fabricate P2/P3 checkpoints, or change active prompt text under a running stack. Review dirty continuations because the runner stages all changes with `git add -A`. Preserve owner work and keep unrelated changes out of checkpoints.

P6 leaves changes uncommitted for review. Use `0.3.6` only after both selected Gates and closeout pass; otherwise retain `0.3.5` and record the actual failed/unobserved result. An owner-accepted gap permits the stated progression without converting the missing check into PASS.

## Evidence and next scope

Preparation and P1 record the actual P2 source/owner map and any historical evidence gaps in `qualification/implementation.md`; P1–P5 append their own source-bound work/check results there. P6 creates `qualification/native-playtest.md` and `closeout.md`. These records are created during execution, not supplied as authored PASS stubs.

Keep recipe/material accounting, isolated transfer fixtures, real-scene integration, and native observations distinguishable. Only supported M1-G3.1/M1-G3.2 results can complete M1-P3. Preserve existing P1/P2 evidence and do not use P3 authoring to backfill unseen historical results. A qualified closeout routes the next gameplay work to **M1-P4 — First powered flight**.

## Authoring verification

On 2026-11-09, the actual runner validator accepted all six prompts using Node.js `24.22.1`, including the native-required P6 closeout and versions `0.3.1`–`0.3.6`. Against the eleven reachable remote commits through `ce163753`, the runner's history detector correctly rejected the actual root `0.2.0` as not ready for P3. A separate planned-baseline check using `0.3.0` selected P1 with zero completed P3 prompts; that was a contract check, not an executed version transition. Relative links/headings, whitespace, and the scoped diff passed review. Gameplay, art, tooling, root package metadata, and P1/P2 task/evidence files were unchanged. No P3 implementation or native playtest was run during authoring.
