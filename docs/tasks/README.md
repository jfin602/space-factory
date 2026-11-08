# Task stacks and evidence

This directory holds bounded implementation briefs and their results. Use the [workflow](../workflow.md) and the selected Gates in the [roadmap](../roadmap.md) to define the next task.

## Task stacks

| Stack | Scope | Current state |
| --- | --- | --- |
| [p1 — A coherent ship](p1/README.md) | M1-P1 / M1-G1.1 and M1-G1.2; three implementation/integration prompts plus one native manual checkpoint and closeout | Executed manually and qualified on Linux; [closeout](p1/closeout.md), checkpoint 0.1.4; uncommitted review state |

The `p1` folder and runner Phase 1 label refer to M1-P1, not the entire broader stranded-ship Phase 1. [The roadmap](../roadmap.md) remains the gameplay progress authority; its selected p1 Gate results link to runtime and native evidence. Authoring status and runner metadata alone do not qualify Gates.

## Folder conventions

Use `docs/tasks/pN/` for a Phase stack, or `docs/tasks/cN-<slug>/` for a bounded correction associated with Phase N. Choose a descriptive slug and preserve existing folder identities once execution begins. [The runner guide](../phase-runner.md) defines the additional inherited continuation/major-family/named-correction forms and their version rules.

| File or folder | Purpose |
| --- | --- |
| `README.md` | Stack purpose, scope, baseline, dependencies, ordered prompt index, current disposition, and links to results. |
| `prompt-assessment.md` | Decomposition, preserved behavior, risks, deferred work, and validation tiers. |
| `implementation-plan.md` | Source-grounded changes, affected ownership boundaries, likely files, dependencies, and actual validation commands. |
| `P1-<slug>.txt`, `P2-<slug>.txt`, etc. | Short, ordered execution briefs with one coherent responsibility per ordinary implementation prompt. |
| `manual/` | Optional supporting instructions/evidence for manual work. The runner does not discover prompts in this subfolder; put ordered handoff prompts at the stack root with `- Browser required: yes.`. |
| `qualification/` | Source-bound scenario results, failures, repair evidence, and links to durable supporting artifacts. Create as evidence is collected. |
| `closeout.md` | The final scoped outcome, exact source identity, actual checks, remaining gaps, and next routing. |

The README records the complete dependency order, including manual prompts. Keep runner prompt files directly at the stack root, numbered contiguously from P1 without leading zeros. Plan one final closeout whose filename slug and TASK title both contain `closeout`; an intermediate implementation handoff does not qualify the entire Phase.

## Authoring and execution

`/prompt-ass`, `/prompt-plan`, and `/prompt-write <folder>` are conversational authoring instructions under [the workflow](../workflow.md). The separate Node.js runner validates and executes those authored files through `npm run space-factory:phase:validate -- <folder>` and `npm run space-factory:phase -- <folder>`. It preserves Dope's implementation checkpoints, resume, retries, and Phase/correction version policies. See [the runner guide](../phase-runner.md) for setup and templates.

Writing prompts produces reviewable task files. A request to run the selected stack or implement its task supplies execution authorization for that scope; no second `/activate` step is required. Honor existing authorization and preserve manual checkpoints that the task explicitly requires.

Before execution, inspect current source, Git status, dependencies, and the actual available tools. Reconcile the plan with any intervening changes while preserving other work. Do not claim that a command exists until it is present in the repository or environment; [development setup](../development.md) lists the current `tools/dev` commands.

## Prompt contents

Each execution brief identifies its goal, relevant source/doc references, prerequisite results, scope boundaries, intended changes, concrete done conditions, and smallest sufficient validation. State the validation tier and whether direct GUI/manual observation is required. Runner prompts require a canonical `TASK: Phase N / Pn — Title` or `TASK: Correction N / Pn — Title`, an exact recommended configuration, and their assigned or unchanged project version. Use the [full grammar and templates](../phase-runner.md#prompt-grammar-and-templates); new prompts normally choose `GPT-6 Sol Medium`, `GPT-6 Sol High`, or `GPT-6 Sol XHigh` as appropriate to the work and available configuration.

Include `- Browser required: yes.` or `- Browser required: no.` exactly. The historical field is also the manual handoff for native Godot checks; `GUI required` is not recognized. Visible gameplay evidence needs an interactive environment with native desktop tools or the owner's actual observations. The default final closeout is manual; `--closeout` can execute it but still leaves uncommitted changes for human review.

Use T1 for focused implementation checks, T2 for affected integration, and T3 for actual gameplay, native, packaging, or release qualification as appropriate. Keep broad or expensive checks at the step that needs them, and inspect command composition to avoid repeating the same build or test work.

## Results and history

Record implementation status separately from verification and progression. An unrun prompt is not implemented; a completed edit is not automatically verified; a passing scoped check does not close all roadmap Gates.

Evidence records should name the source revision, any relevant uncommitted changes, platform/tool versions, scenario, actual actions or commands, expected and observed results, and limitations. Use the result vocabulary in [validation](../validation.md); a missing observation is not a pass. Keep generated logs and exports in the ignored artifact area, with durable findings and any necessary retained evidence linked from the task record.

Preserve executed prompt text, original failure records, and prior source identities. Add corrections and later applicability notes rather than rewriting what ran. At final closeout, reconcile the relevant roadmap status, [BOOT.md](../../BOOT.md) routing, task README, and affected owning documents once. Record an owner-accepted gap as a progression decision while preserving its verification result.
