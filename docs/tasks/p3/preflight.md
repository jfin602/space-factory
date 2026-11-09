# P3 pre-run preparation

**Purpose:** reconcile the completed P2 implementation and deliberately prepare the runner's `0.3.0` baseline. This brief is Markdown, outside the numbered `.txt` runner sequence, because the runner rejects a wrong baseline before launching P1. Authoring this brief does not execute it.

The owner reported P2 complete on 2026-11-09. The published source inspected for P3 authoring, [ce163753](https://github.com/jfin602/space-factory/commit/ce163753d8973ccd018f2344c6175c52fe4b113d), does not yet contain that implementation. Run this preparation in the checkout that actually contains the completed P2 work. Bring in the P3 documentation while preserving its code, local changes, evidence, and version history; do not reset to the published snapshot or replay P2.

## Preparation brief for the implementing assistant

```text
Prepare the existing completed Space Factory P2 checkout for docs/tasks/p3.

Read AGENTS.md, BOOT.md, docs/tasks/p3/README.md, and the Source and prerequisite contract plus Version and runner contract in docs/tasks/p3/implementation-plan.md. Inspect the actual branch, HEAD, dirty work, root version, and any P3 checkpoint history before editing.

Locate the implemented P2 factory state, cargo/carried/input/output/tank owners, finite capacities, processor-to-tank transfer operation, installed tank-to-engine reference, single interaction dispatcher, active-panel/session checks, HUD, and existing C# checks. Read the P2 closeout/qualification if available. Record the actual source/API map and available evidence in docs/tasks/p3/qualification/implementation.md. The owner already reported P2 complete and requested progression; missing historical evidence alone is recorded as a gap, not an instruction to repeat P2 or seek another activation. Missing actual implementation dependencies must be reported precisely; do not implement substitute P2 systems in this preparation.

Preserve source/engine/SDK pins and compatible owner work. If this is the first P3 run, its actual dependencies exist, and no P3 checkpoint has begun, change only root package.json's version to 0.3.0, preserving every other package field. Record the observed prior version. Do not change a resumed 0.3.x checkout back to baseline.

Validate with npm run space-factory:phase:validate -- p3 and git diff --check. Review and commit only the preparation files you changed as a normal descriptive preparation commit, with no fabricated numbered checkpoint subject and no blanket git add -A. Preserve unrelated work. Do not push or execute the P3 stack unless that is part of the current request. Report the actual source, mapped owners, version transition, checks, remaining gaps, and the runner command.
```

Once preparation is committed and the working tree is reviewed, `npm run space-factory:phase -- p3` can execute the pending P3 tasks. If P3 is already underway, use the existing [runner continuation rules](../../phase-runner.md#checkpoints-dirty-work-and-resume) rather than this fresh-baseline transition.

## Readiness distinction

The prompt validator reads task grammar and assigned versions, not the current root version or completed gameplay. A passing validation against the published `0.2.0` source does not establish execution readiness. The runner's history/version detector must reject that root version for a fresh `p3`; testing the planned `0.3.0` value separately verifies only the intended transition contract.

Existing P2 results retain their own provenance. New P3 checks must use the actual implemented dependencies and create their own evidence. No preparation record may invent native P2 observations, mark its Gates PASS from the owner's short completion report, or substitute a second inventory/connection model for the completed game.
