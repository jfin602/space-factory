# Space Factory Development Workflow

This workflow adapts Dope's agent routing, documentation process, prompt planning, and evidence discipline to Space Factory's Godot/.NET project. Start with [AGENTS.md](../AGENTS.md) and [BOOT.md](../BOOT.md), then retrieve only the source and documentation relevant to the task.

Slash commands below are instructions to the collaborating assistant. They are not installed shell commands, Godot editor features, or an automated runner. Existing development commands are owned by [development setup](development.md) and implemented in `tools/dev`.

## 1. Establish the task

Before substantial work, identify:

- The requested player/developer outcome, applicable Phase/Gate, acceptance criteria, and explicit exclusions.
- Current Git revision, relevant local changes, existing implementation, and any task already in progress.
- Affected state owners, producers, consumers, scene/input adapters, and the smallest useful implementation boundary.
- Confirmed decisions and task-relevant open choices from [the decision register](decisions-and-questions.md).
- The focused checks needed now and any integration, visual, persistence, or platform evidence needed later.

Use [the module map](../MODULES.md) and [documentation index](README.md) as routers. Carry useful findings and the current execution step through recovery. Do not repeatedly load the full documentation set or turn reading into a separate recursive work loop.

Planning and implementation can happen in the same authorized request. Small fixes need a proportionate plan; substantial multi-step features benefit from the assessment, plan, and prompt stages below.

## 2. Documentation and decisions

`/docs-review` investigates the requested change against current source and relevant decisions, then presents a concrete bounded proposal: affected files, proposed edits, reasons, and consequential unresolved choices. Review alone does not apply changes.

Apply a reviewed proposal when the owner instructs its application. An explicit request to write, import, or update specified documentation already supplies authorization for those scoped edits; do not require another per-file approval. In an external assistant conversation, `/docs-apply` may be used as shorthand for applying the reviewed set. It does not imply that Space Factory implements a native proposal UI.

Update each document that owns the changed facts, and adjust affected references and criteria. Ordinary discussion, an unaccepted suggestion, or a feature-log entry does not silently become a confirmed game requirement. Record a material decision's date, rationale, source, status, and affected documents in [the decision register](decisions-and-questions.md); use [a detailed decision record](decisions/README.md) when the rationale warrants one.

Check relative paths, headings, terminology, current-versus-planned labels, and the actual diff. Documentation changes alone do not implement gameplay or pass Gates.

## 3. Issue and feature registries

Use [known-issues.md](../known-issues.md) for reported defects and [feature-ideas.md](../feature-ideas.md) for proposed additions. Existing accepted game requirements stay in their owning design documents.

| Request | Action |
| --- | --- |
| `/issue <report>` | Add an Open Issue with observed and expected behavior, source/context, impact, and any known evidence or suspected cause clearly labeled. |
| `/feature <idea>` | Add a Proposed Idea with intended behavior, value, relevant constraints, and genuine open questions. |
| `/resolve <ID>` | Resolve the matching issue with a dated resolution and available evidence. Preserve its original report and ID. |
| `/resolve +<ID>` | Mark a feature shipped only when completion is supported by evidence. Preserve its original proposal and ID. |

Assign a random unused four-character ID from `ABCDEFGHJKLMNPQRSTUVWXYZ23456789`; feature IDs have a leading `+`. Check existing IDs before writing and never reuse one. Use `### ID — YYYY-MM-DD — Title` or the corresponding `+ID` heading. Report the ID and the actual update to the owner.

If a report describes an enhancement, route it to the feature log. Deferred, rejected, or superseded work receives that explicit disposition rather than a false resolved/shipped claim. A missing ID produces a not-found result without creating a replacement. Registry updates do not automatically change the roadmap or start implementation.

## 4. Assess, plan, and write executable tasks

The authoring sequence is `/prompt-ass` → `/prompt-plan` → `/prompt-write <folder>`. A combined request can complete these stages together; each stage must still be grounded in the preceding findings.

### /prompt-ass

Define the bounded outcome, preserved behavior, dependencies, work order, risks, deferred work, and required evidence. Assign each planned prompt a validation tier. Favor a small playable increment with one coherent implementation responsibility per ordinary prompt.

### /prompt-plan

Inspect actual source and available checks. Trace simulation ownership, inputs/outputs, scenes, persistence, and platform boundaries only where relevant. Identify likely files, failure cases, implementation order, and the smallest meaningful checks. Choose a manual playtest when appearance, input, or a complete player action must be observed.

Store phase-level design under [planning](planning/README.md), and task-specific assessment and implementation plans with [their task stack](tasks/README.md). Link shared contracts rather than copying them into every prompt.

### /prompt-write <folder>

Write the selected stack under `docs/tasks/<folder>/` using the [task conventions](tasks/README.md). Each execution brief states its goal, prerequisites, narrow reading list, allowed scope, explicit deferrals, implementation steps, validation tier, real commands or check scenarios, observable done condition, and required final report.

Identify `GUI required: yes` or `GUI required: no`. A native game playtest is a GUI task even when no browser is involved. A required owner/manual checkpoint is a visible handoff; a future runner must pause there. Prompt files are execution instructions, not proof that execution occurred.

Use model recommendations only for configurations actually available to the owner, respecting the selected model and effort. Choose effort appropriate to the task; an authored recommendation does not change a live session's configuration.

### Prompt efficiency review

Before finishing a new stack, review all prompts together:

1. Give each ordinary prompt one coherent deliverable and keep its prerequisites explicit. Split independent simulation, persistence, presentation, and qualification responsibilities when needed.
2. Use Dope's ordinary planning budget as a decomposition guide: target up to 8 minutes including focused validation, a 10-minute soft ceiling, and a 15-minute ordinary execution budget. Narrow work that plainly cannot fit. Dedicated integration, manual qualification, and release tasks can require longer.
3. Keep context bounded. Carry the goal, acceptance criteria, relevant decisions, and completed steps instead of copying entire documents into prompts.
4. Select checks for real risks and affected behavior. Do not invent a framework or a new test suite merely to make a prompt look complete.
5. Inspect actual command composition. `./tools/dev check` already imports, builds, runs the real main-scene smoke, and exercises scene automation; do not repeat those steps independently on the same unchanged candidate without a reason.
6. Assign expensive or manual evidence to the appropriate integration/qualification step. Validate a critical invariant before dependent work proceeds when deferring it would make the intermediate state unsafe.
7. Ensure a clear final disposition and one final stack closeout. Keep any intermediate manual checkpoints distinct from that closeout.

Record meaningful exceptions in the assessment/plan. Time targets never justify hiding failures, skipping necessary checks, or claiming completion. If an execution overruns, preserve the work and identify the remaining bounded steps honestly.

## 5. Execute the authorized scope

A deliberate request to implement or run a selected task/stack authorizes that work. There is no separate `/activate` requirement. Authoring prompts alone does not run them or authorize an unrelated Phase.

Before editing, inspect current source and any changed dependencies. Continue compatible partial work; protect unrelated changes. Do not reset, stash, overwrite, or include other work in a commit without applicable authorization. If current source materially invalidates the plan, explain the conflict and revise the bounded plan before proceeding.

Use the existing `tools/dev` entry point for build/run/scene operations. This repository currently has no Dope-style phase runner, automatic checkpoint commits, model retry service, or phase-to-version mapping. Operate prompts through the available assistant/CLI workflow and record completion explicitly. Add runner functionality only as a separately requested implementation task.

Preserve started/completed prompt text and its execution evidence. Amend unexecuted plans explicitly; use a new correction or recovery brief when a completed task needs repair. A resumed session should inspect current progress rather than replay completed work automatically.

For Git publication, follow the current request and existing authorization. Keep commits scoped and report the actual branch/revision. Recheck the remote head before publishing remotely and preserve concurrent work; do not force a history rewrite to finish an import.

## 6. Validation tiers

Choose the lowest tier that supports the claimed outcome. [Validation](validation.md) owns gameplay scenarios and the evidence standard; [development setup](development.md) owns executable commands and their actual coverage.

| Tier | Purpose | Space Factory application |
| --- | --- | --- |
| T1 — Focused | Establish the changed behavior and immediate invariants. | Content/link/diff review for docs; C# build or a targeted rule/scene check for code; the existing bootstrap check when it directly covers the changed surface. |
| T2 — Integration | Establish that affected systems work together. | Exercise the actual production/consumption/movement boundary, or another implemented cross-system transition, with state values and relevant failure cases. Run appropriate build/runtime checks once for that candidate. |
| T3 — Qualification | Establish the complete claimed player, platform, or release outcome. | Run the named scenario in the real game, capture input/visual results, and validate restart/save/export behavior only when part of the Gate. Qualify each claimed target platform separately. |

Tiers describe evidence scope, not a universal ban on a command. The current small `./tools/dev check` can be appropriate focused validation; it is not a comprehensive gameplay suite. It does not prove future factory behavior, manual play, or Windows/macOS support.

Add focused regression checks for material risks such as resource conservation, capacities, time accounting, connection ownership, and durable terminal outcomes when those behaviors exist. Purely visual or low-impact document changes need proportional checks. Tests should detect meaningful failure, not mirror the implementation.

Escalate when the task requires integrated proof, a shared contract changes, or focused evidence reveals a plausible broader regression. After a repair, rerun the affected checks and any broader evidence it invalidated. Do not repeat an unchanged passing suite just for reassurance. Report unavailable tools or unobserved behavior as evidence gaps.

### Player-facing changes

Consult [UX and presentation](ux-and-presentation.md) and the affected system design. State the player's goal, input/entry point, next action, feedback, and recovery path. Reuse existing Godot presentation conventions and keep resource/system state authoritative outside the display. Verify applicable readability, focus/input, camera, viewport, and failure feedback in the running game; do not import Dope's IDE palette or browser-specific rules.

## 7. Evidence, Gates, and closeout

Record the source revision, relevant dirty-state qualification, platform/tool versions, scenario, actions, expected result, observed result, and remaining gaps. Distinguish a prior recorded result from a check rerun in the current session. Logs/screenshots that exist only on another machine must not be described as independently inspected.

Use **PASS**, **FAIL**, and **NOT OBSERVED** for individual checks. Explain a **BLOCKED** result with the specific missing dependency. Keep three questions separate:

- **Implementation:** what source or behavior has actually been added?
- **Verification:** what was observed on which source and platform?
- **Progression:** can the next bounded task proceed, and under what stated conditions?

The [roadmap](roadmap.md) remains the single Phase/Gate progress authority. A Gate passes when its criteria have the required source-bound evidence; a Phase passes when all of its Gates pass. A passing helper check, authored stack, commit, or accepted design does not substitute for that evidence. Owner acceptance of a gap can permit progression, but the original failed/unobserved check retains its result.

Keep detailed task results under the task's qualification records and final `closeout.md`. Preserve earlier failures and add the repair and its new evidence. A correction should include a focused regression guard when meaningful for the defect class. Generated bulk output stays under ignored `artifacts/`; retain essential evidence durably with the task or at a stable referenced location before cleanup.

At terminal closeout, reconcile the affected roadmap status, task record, BOOT routing, and any changed owning documents once. Link evidence rather than copying it throughout the repository. State the exact scope that passed, outstanding requirements, and the next actionable step. Documentation reconciliation needs text/source review; it is not a reason to rerun gameplay or release checks.

## Import provenance

Adapted on 2026-11-08 from `jfin602/dope` at [commit `02bb1377`](https://github.com/jfin602/dope/commit/02bb13779acb7e2409f8c6ee42aeffccc0180c37): [AGENTS.md](https://github.com/jfin602/dope/blob/02bb13779acb7e2409f8c6ee42aeffccc0180c37/AGENTS.md), [BOOT.md](https://github.com/jfin602/dope/blob/02bb13779acb7e2409f8c6ee42aeffccc0180c37/BOOT.md), [docs/workflow.md](https://github.com/jfin602/dope/blob/02bb13779acb7e2409f8c6ee42aeffccc0180c37/docs/workflow.md), and its responsibility/registry/planning/task layout.

Space Factory's existing `game/`, `tools/`, system documents, `docs/roadmap.md`, and decision register retain their roles. Historical Dope phase results, product features, Node/Theia packages, and runner implementation are outside this documentation import.
