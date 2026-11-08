# p1 — M1-P1: A coherent ship

**Disposition: AUTHORED, NOT EXECUTED.** The owner requested `/prompt-ass + /prompt-plan + /prompt-write p1` on 2026-11-08. This stack implements only [M1-P1](../../roadmap.md#m1-p1-a-coherent-ship), serving **M1-G1.1** and **M1-G1.2**. It does not implement the broader expedition roadmap's Phase 1, the remaining M1 Phases, or factory-powered flight.

The [roadmap](../../roadmap.md) remains the sole Gate/Phase progress authority. Both selected Gates remain NOT STARTED and gameplay checks remain NOT OBSERVED. Authorship and parser validation are not execution or gameplay evidence.

## Source and plan

- Assessed Space Factory remote `main` at [295f2056](https://github.com/jfin602/space-factory/commit/295f205657527a2545b47ba3b47a5fbfb154608c); gameplay still matches the [536cfd08 bootstrap](https://github.com/jfin602/space-factory/commit/536cfd08da06f119e91d8a4f8865b4508be2e579).
- Reconciled the concurrent runner port at [a6b77498](https://github.com/jfin602/space-factory/commit/a6b77498d6319e65a9f49520e509b51083a7d9e1). The assessed gameplay files are unchanged; current runner/authoring instructions are included in this stack.
- Read [AGENTS](../../../AGENTS.md), [BOOT](../../../BOOT.md), [workflow](../../workflow.md), the selected Gates, [milestone design](../../planning/p1/first-flight.md), and affected source. Inspect current HEAD and local changes before execution; these revisions are not reset targets.
- [Assessment](prompt-assessment.md) owns decomposition, risks, validation tiers, and efficiency review. [Implementation plan](implementation-plan.md) owns source boundaries, behavior contracts, and the check matrix.

## Ordered prompt index

| Order | Prompt | Responsibility | Tier | GUI | Runner target |
| --- | --- | --- | --- | --- | --- |
| P1 | [Ship-local ownership](P1-ship-local-ownership.txt) | Ship root, shared local bounds, preserved initial placement, world reference, current smoke paths | T1 | No | 0.1.1 |
| P2 | [Helm control modes](P2-helm-control-modes.txt) | Nearby interaction, one control owner, exclusive input, transition cleanup, truthful unavailable-supply feedback | T1 | No | 0.1.2 |
| P3 | [Spatial fixture and integration](P3-spatial-fixture-integration.txt) | Explicit development translation fixture and actual-scene integration checks | T2 | No | 0.1.3 |
| P4 | [Native ship and helm closeout](P4-native-ship-helm-closeout.txt) | Manual native-game observation, then the single evidence-based closeout | T3 then T1 reconciliation | Yes | 0.1.4 |

Execute P1 → P2 → P3 → **manual P4**. Every step requires its predecessor's implemented scope and applicable passing checks. All four prompts are currently unrun. P4 contains the live checkpoint followed by closeout so there is no intermediate native-GUI task that the runner would silently execute without pausing.

## Runner commands and prepared baseline

Use the published [Space Factory runner](../../phase-runner.md), [parser](../../../scripts/space-factory-phase-core.mjs), and [validator](../../../scripts/validate-space-factory-phase.mjs). Folder `p1` requires `TASK: Phase 1 / Pn`, contiguous top-level `Pn-<slug>.txt` files, supported model metadata, sequential 0.1.n targets, and one final closeout. Here the runner's Phase 1 label maps specifically to M1-P1; it does not rename the broader roadmap.

The port initially set root `package.json` to 0.0.0. This authoring change deliberately prepares its existing **development checkpoint baseline at 0.1.0** so P1's 0.1.1 target is valid. The field is independent of Godot/.NET versions and a future public game-release policy. Preparing it does not run a prompt or complete any Gate. All existing manifest scripts/settings are preserved.

From the repository root:

```bash
npm run space-factory:phase:validate -- p1
```

When execution is requested, with the [runner prerequisites](../../phase-runner.md#setup-and-commands) available and a reviewed working tree:

```bash
npm run space-factory:phase -- p1
```

The initial run expects root version 0.1.0 and no root `package-lock.json`. No npm install is needed. After implementation starts, use the runner's version/Git-history resume checks; do not reset a progressed checkout to the initial baseline. Grammar validation does not launch Codex or prove native gameplay.

**Keep P4 as a deliberate manual native-game handoff.** Use the normal launch without `--closeout`. P4 declares the repository's canonical historical `- Browser required: yes.` field, which also marks native Godot checks and stops the runner even if `--closeout` is supplied. Its additional `GUI required: yes` description is informational only. This historical field name does not mean a browser can control the game. After P3, open P4 in an interactive Codex session with actual native desktop access or perform its named player actions with the owner.

Reconcile unexecuted metadata if the actual runner contract changes. Never infer observed gameplay from a parser check, process exit, version update, or checkpoint commit.

## Execution and version contract

1. Read AGENTS and BOOT, this contract, and the current prompt's narrow references. Preserve the goal, selected Gates, current step, source findings, and evidence through recovery; avoid rereading the whole documentation set.
2. Inspect branch, revision, and local changes. Preserve compatible partial work and unrelated changes. Coordinate external scene edits with any open Godot editor and keep relevant UID sidecars.
3. Implement only the selected prompt. Keep normal play unpowered in this stack; the P3 translation fixture is explicitly development-only and does not prove M1-G4.1.
4. Use actual available tools. Run `./tools/dev doctor` when environment readiness is unknown or changed. `./tools/dev check` already imports, builds, executes the main C# smoke, and checks scene automation; do not repeat its component commands on the same candidate without a concrete reason.
5. Preserve meaningful failure exit/marker behavior. A failed or unavailable required check must remain FAIL, BLOCKED, or NOT OBSERVED; a prose completion message cannot substitute for evidence.
6. On a compatible runner path, apply the prompt's target to the existing root package version only after its required scope and checks pass. On failure, leave the prior checkpoint version. The runner checks process/version/Git postconditions, not semantic PASS/FAIL prose; never advance the target to mask an incomplete step.
7. Preserve the existing manifest, scripts, dependency-free tooling, engine/SDK pins, and checkpoint history. If its version/source prerequisites do not match the selected next prompt, inspect existing work and reconcile the execution state before proceeding; do not invent a manifest, lower a progressed version, or fabricate checkpoint commits.
8. Do not self-commit or push from an execution prompt. Under the inspected runner, implementation commits belong to the runner; manual work and final closeout remain reviewable until publication is authorized. Never stage unrelated work to satisfy a checkpoint.
9. Record each implementation step in `docs/tasks/p1/qualification/implementation.md` when evidence actually exists. Include revision plus relevant dirty-source identity, changed files, actions/commands, expected/observed values, and gaps. Preserve earlier failures. Do not pre-create fictional result records.
10. P4 creates `qualification/native-playtest.md` and `closeout.md` from actual results, then reconciles the roadmap, task README, BOOT, MODULES, and affected owning docs once. Update only the selected Gates; owner acceptance of a gap does not convert that check to PASS.

The recommended model strings follow the verified Space Factory parser; actual model availability and an explicit owner selection govern execution. No authoring recommendation changes the current assistant session's model.

## Expected outcome and next routing

The engineer stays inside a deck that belongs to a movable ship root. World references remain stationary. Nearby helm interaction switches exclusively between walking and piloting, clears prior requests, and explains the genuinely unavailable propulsion supply. Ordinary pilot input cannot move the ship. A visibly labeled, explicitly launched spatial fixture demonstrates interior coherence after translation.

P4 may qualify M1-G1.1 and M1-G1.2 only with the required state and native observations. If both pass, the next gameplay scope is M1-P2. Otherwise BOOT and the closeout must identify the exact repair or missing observation; do not advance to factory work under a false completed-Phase claim.

## Authoring verification

Authoring checks on 2026-11-08:

- `npm run space-factory:phase:validate -- p1`: PASS; three implementation prompts, one final closeout, contiguous numbering, supported model fields, and targets 0.1.1–0.1.4.
- Actual runner-core version/history checks against the seven reachable commits through a6b77498: PASS; zero completed prompts, next P1, expected prepared baseline 0.1.0. P1–P3 are non-handoff prompts; P4 has the canonical required-manual flag.
- Relative references/heading targets, Gate coverage/status preservation, and the scoped diff: PASS. The root manifest changes only its development checkpoint version; gameplay and runner implementation source are unchanged.

These are authoring/tooling checks. No Godot gameplay, native input, or live Codex stack execution was performed by authoring this stack. Runtime prerequisites and the actual working tree must still be checked where it is executed.
