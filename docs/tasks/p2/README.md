# M1-P2 — Prepare the factory

**Status: authored on 2026-11-08; NOT EXECUTED.** This stack implements only [M1-P2](../../roadmap.md#m1-p2-prepare-the-factory), with selected Gates **M1-G2.1** and **M1-G2.2**. The roadmap remains the progress authority. Both Gates remain NOT STARTED; authoring and runner validation are not gameplay evidence.

The inspected gameplay baseline is committed `main` at [f274c896](https://github.com/jfin602/space-factory/commit/f274c89630a6033ccd79ad98b7fee6369dd5778a), which publishes the qualified [M1-P1 ship and helm](../p1/closeout.md). Inspect current source and compatible local work before execution; this identity is not a reset target.

## Playable outcome

Walk to cargo, take finite ice and the supplied pipe, load the processor, and install the missing processor-output-to-tank connection. Every action changes the same authoritative inventory or connection state. The ship keeps its existing Walking/Piloting behavior and ship-local interior.

The finished P2 arrangement contains loaded ice, one consumed-and-installed pipe, an initially empty bounded tank, and the preinstalled tank-to-engine connection. Timed production and normal delivery belong to M1-P3; powered movement belongs to M1-P4. Ordinary P2 play creates no propellant.

Read the [assessment](prompt-assessment.md) for decomposition and risks and the [implementation plan](implementation-plan.md) for the shared contracts. Product rules remain in the [factory](../../systems/factory-and-resources.md#accepted-m1-factory-loop) and [presentation](../../ux-and-presentation.md#accepted-m1-interaction-and-feedback) documents.

## Ordered prompts

| Prompt | Deliverable | Configuration | Tier | Assigned version |
| --- | --- | --- | --- | --- |
| [P1 — Finite resource ownership](P1-finite-resource-ownership.txt) | Real starter inventories, capacities, and accounted transfers | GPT-6 Sol High | T1 | `0.2.1` |
| [P2 — Starter factory layout](P2-starter-factory-layout.txt) | A readable fixed arrangement owned by the ship | GPT-6 Sol Medium | T1 | `0.2.2` |
| [P3 — Nearby cargo and loading](P3-nearby-cargo-and-loading.txt) | Contextual interactions, carried supplies, loading, and feedback | GPT-6 Sol High | T1 with bounded interaction integration | `0.2.3` |
| [P4 — Installable pipe connection](P4-installable-pipe-connection.txt) | One consumed part and a real bounded output-to-tank route | GPT-6 Sol High | T1 | `0.2.4` |
| [P5 — Factory preparation integration](P5-factory-preparation-integration.txt) | Actual-scene preparation and preserved control/spatial behavior | GPT-6 Sol High | T2 | `0.2.5` |
| [P6 — Native factory closeout](P6-native-factory-closeout.txt) | Native M1-V02 observations, Gate decisions, and documentation reconciliation | GPT-6 Sol High | T3 plus T1 documentation | `0.2.6` |

The runner's `Phase 2` label and lowercase `p2` folder identify **M1-P2**, not the broader expedition roadmap's Phase 2. Prompt numbers P1–P6 are steps within this stack.

## Run and handoff

From the repository root, with the [runner prerequisites](../../phase-runner.md#setup-and-commands) available:

```bash
npm run space-factory:phase:validate -- p2
npm run space-factory:phase -- p2
```

The first command checks the authored grammar/version plan. The second executes pending implementation prompts P1–P5. **P6 is the required native manual checkpoint and final closeout.** Its canonical `- Browser required: yes.` field makes the runner stop before it, including with `--closeout`. Complete that prompt in an interactive environment with native Godot observation tools or the owner's recorded observations. Browser access alone cannot control the native game.

Use `./tools/dev run` for ordinary play and `./tools/dev p1-demo` for the explicitly labeled spatial fixture. The fixture is development translation, not powered flight. The implementation plan describes the relevant check composition and evidence boundaries; do not run this stack merely to validate its text.

## Version and continuation

The root package version is deliberately prepared at **`0.2.0`** for this stack. This advances development checkpoint metadata from the completed P1 value `0.1.4`; it does not implement P2 or change Godot/.NET versions. Preserve all other package fields.

Initial P2 execution expects the prepared baseline and no completed P2 checkpoint subjects. P1 was committed together after manual execution; its lack of individual `0.1.x` runner checkpoints does not prevent starting this separate P2 stack. Do not rerun P1, fabricate historical checkpoints, or reset to its old baseline.

For P1–P5, set the assigned version only after that prompt's required implementation and checks pass. The runner owns the corresponding implementation commit, whose subject is the assigned version. On a fresh failed attempt, retain the previous checkpoint. On a resumed attempt, inspect the actual partial changes and runner version/history contract; do not blindly rewrite metadata. A successful Codex exit or a final response saying PASS is not independent gameplay verification.

Resume uses the existing runner command and reachable P2 checkpoint history. Inspect dirty work before accepting a continuation: the runner stages all changes with `git add -A`. Keep unrelated work out of that checkpoint and preserve partial implementation. Do not change an active prompt stack underneath the runner.

P6 leaves its changes uncommitted for human review. Keep `0.2.5` if required P2 checks fail or remain unobserved; use `0.2.6` only after the scoped qualification passes. Record an owner-accepted evidence gap as a progression decision, never as a passed observation.

## Evidence and next routing

Execution creates `qualification/implementation.md` for P1–P5, `qualification/native-playtest.md` for P6, and `closeout.md` for the terminal disposition. These are future records, not authored PASS stubs. Each record identifies the actual source, relevant local changes, commands/actions, expected and observed results, and remaining gaps. Preserve prior failures when adding repairs.

P6 reconciles this README, BOOT, the module map, and affected owning documents once. Only supported M1-G2.1/M1-G2.2 results can complete M1-P2. M1-P3–P5 and broader expedition Gates remain unqualified by this stack. Successful closeout routes the next gameplay work to **M1-P3 — Manufacture propellant**.

## Authoring verification

On 2026-11-08, the actual runner validator accepted all six prompts using Node.js `24.22.1`: five implementation prompts and one Browser-required final closeout, with targets `0.2.1`–`0.2.6`. The runner's history detector was also checked against the nine reachable remote commits through `f274c896` and the prepared `0.2.0` manifest: zero completed P2 prompts, with P1 next. Relative links, heading references, whitespace, and the scoped diff were checked. Gameplay, tooling source, and P1 execution/evidence files were unchanged; no P2 implementation or native playtest was run during authoring.
