# Task stacks and evidence

This directory holds bounded implementation briefs and their results. No implementation stack has been authored or executed by creating this scaffold. Use the [workflow](../workflow.md) and the selected Gates in the [roadmap](../roadmap.md) to define the next task.

## Folder conventions

Use `docs/tasks/pN/` for a Phase stack, or `docs/tasks/cN-<slug>/` for a bounded correction associated with Phase N. Choose a descriptive slug and preserve existing folder identities once execution begins.

| File or folder | Purpose |
| --- | --- |
| `README.md` | Stack purpose, scope, baseline, dependencies, ordered prompt index, current disposition, and links to results. |
| `prompt-assessment.md` | Decomposition, preserved behavior, risks, deferred work, and validation tiers. |
| `implementation-plan.md` | Source-grounded changes, affected ownership boundaries, likely files, dependencies, and actual validation commands. |
| `P1-<slug>.txt`, `P2-<slug>.txt`, etc. | Short, ordered execution briefs with one coherent responsibility per ordinary implementation prompt. |
| `manual/` | Prompts requiring a deliberate manual handoff, such as visible gameplay qualification. Create only when needed. |
| `qualification/` | Source-bound scenario results, failures, repair evidence, and links to durable supporting artifacts. Create as evidence is collected. |
| `closeout.md` | The final scoped outcome, exact source identity, actual checks, remaining gaps, and next routing. |

The README records the complete dependency order, including manual prompts. Keep prompt numbers unambiguous and contiguous across that order. Plan one final closeout for the stack; an intermediate implementation handoff does not qualify the entire Phase.

## Authoring and execution

`/prompt-ass`, `/prompt-plan`, and `/prompt-write <folder>` are conversational instructions to the assistant. They describe authoring work under [the workflow](../workflow.md). Space Factory does not currently contain an installed phase runner, slash-command executable, automatic checkpoint system, or Phase-based version-bump mechanism.

Writing prompts produces reviewable task files. A request to run the selected stack or implement its task supplies execution authorization for that scope; no second `/activate` step is required. Honor existing authorization and preserve manual checkpoints that the task explicitly requires.

Before execution, inspect current source, Git status, dependencies, and the actual available tools. Reconcile the plan with any intervening changes while preserving other work. Do not claim that a command exists until it is present in the repository or environment; [development setup](../development.md) lists the current `tools/dev` commands.

## Prompt contents

Each execution brief identifies its goal, relevant source/doc references, prerequisite results, scope boundaries, intended changes, concrete done conditions, and smallest sufficient validation. State the validation tier and whether direct GUI/manual observation is required. Model guidance, when included, follows the current workflow and the owner's selected configuration.

Use T1 for focused implementation checks, T2 for affected integration, and T3 for actual gameplay, native, packaging, or release qualification as appropriate. Keep broad or expensive checks at the step that needs them, and inspect command composition to avoid repeating the same build or test work.

## Results and history

Record implementation status separately from verification and progression. An unrun prompt is not implemented; a completed edit is not automatically verified; a passing scoped check does not close all roadmap Gates.

Evidence records should name the source revision, any relevant uncommitted changes, platform/tool versions, scenario, actual actions or commands, expected and observed results, and limitations. Use the result vocabulary in [validation](../validation.md); a missing observation is not a pass. Keep generated logs and exports in the ignored artifact area, with durable findings and any necessary retained evidence linked from the task record.

Preserve executed prompt text, original failure records, and prior source identities. Add corrections and later applicability notes rather than rewriting what ran. At final closeout, reconcile the relevant roadmap status, [BOOT.md](../../BOOT.md) routing, task README, and affected owning documents once. Record an owner-accepted gap as a progression decision while preserving its verification result.
