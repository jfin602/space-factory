# Durable engineering decisions

Use this directory for architectural decision records (ADRs) when a consequential engineering choice needs durable reasoning beyond one task. No individual ADR is created by this scaffold.

The [decision register](../decisions-and-questions.md) continues to own confirmed requirements, working designs, open questions, their identifiers, and their status. Existing decisions remain in that register. Add a link to an ADR when a decision needs more detail; keep the status aligned instead of creating a competing register.

## Record format

Name a new record `NNNN-<short-title>.md`, using the next unused four-digit number. Record:

- Title, date, and status: proposed, accepted, superseded, or rejected.
- The concrete problem and relevant source or design context.
- The decision, its scope, and who or what authorized it.
- Rationale and alternatives that materially affected the choice.
- Consequences, preserved boundaries, and conditions for revisiting it.
- Links to the corresponding register entries, affected documents, and any implementation or validation work.

Keep an accepted decision distinct from its implementation and qualification. Record only actual decisions; illustrative recipes, proposed architecture, and unresolved questions retain their existing labels until resolved.

## Placement and updates

Task-specific execution choices belong in [planning](../planning/README.md) or [task implementation plans](../tasks/README.md). Routine edits need no ADR. Use [the documentation workflow](../workflow.md) for a material change to a durable decision, honoring approval already supplied by the owner.

When a decision changes, preserve the original reasoning and link the superseding record. Update the register and affected current design documents so a new session can find the active choice without interpreting a long historical log.
