# Phase planning

This directory holds focused designs for future implementation Phases. The [roadmap](../roadmap.md) remains the single authority for Phase order, Gate criteria, and current progress. No new Phase plan is established by this directory scaffold.

## When to add a plan

Create `docs/planning/pN/` when the selected Phase needs detail beyond the roadmap and existing system documents. A small task can link those documents directly; it does not require another planning document.

A useful Phase plan records:

- The playable outcome and the roadmap Gates it serves.
- Current source and observed behavior, including the baseline revision.
- Scope, preserved behavior, dependencies, and explicitly deferred work.
- Relevant decisions and unresolved choices that affect this Phase.
- State ownership and integration boundaries.
- Observable acceptance criteria and the evidence needed to assess them.

Keep product rules in their owning system documents and decision status in the [decision register](../decisions-and-questions.md). Link those sources instead of copying their full contents.

## From plan to execution

Follow [the development workflow](../workflow.md): assess the task, inspect source to produce an implementation plan, then write a bounded prompt stack when requested. Executable task folders belong under [docs/tasks](../tasks/README.md); their implementation plans describe the actual work sequence against current source.

Label proposed and accepted plans accurately. Plan acceptance, implementation, verification, and owner progression decisions are separate facts. Update current roadmap routing when the corresponding evidence or owner decision changes, while retaining earlier results in their task records.
