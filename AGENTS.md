# Working on Space Factory

## Start with the task

Read this guide and [docs/README.md](docs/README.md), then read only the documents needed for the requested task. Keep the original goal, relevant constraints, acceptance criteria, current step, and verification evidence explicit in your working context. Documentation is input to the task; reading it is not implementation progress.

The project uses Godot 4.7.2 .NET and C# for a small desktop sandbox. Read [development setup](docs/development.md) for the selected tools and verified commands. Run `./tools/dev doctor`, `./tools/dev check`, `./tools/dev editor`, and `./tools/dev run` from the repository root. The development entry point also works from another working directory.

## Documentation routing

| Task | Relevant documents |
| --- | --- |
| Understand the product or resolve scope | [Vision](docs/vision.md), [game design](docs/game-design.md), [decisions](docs/decisions-and-questions.md) |
| Resources, machines, logistics, or power | [Factory and resources](docs/systems/factory-and-resources.md) |
| Engineer survival, run state, or permanent failure | [Survival and runs](docs/systems/survival-and-runs.md) |
| Ship construction, travel, or scouting | [Ship and navigation](docs/systems/ship-and-navigation.md) |
| Surface play, ports, or persistent outposts | [Landings and outposts](docs/systems/landings-and-outposts.md) |
| Opening experience or presentation | [Tutorial](docs/tutorial.md), [UX and presentation](docs/ux-and-presentation.md) |
| Architecture, persistence, or implementation sequence | [Technical direction](docs/technical-direction.md), [roadmap](docs/roadmap.md) |
| Acceptance and regression checks | [Validation](docs/validation.md), plus the affected system document |

## Design authority

- Preserve the user-confirmed requirements in the decision register, especially single-engineer control, the stranded-ship introduction, permanent failure, and persistent surface supply facilities.
- Working designs and example recipes are proposals. State consequential assumptions when implementing them; update their status when a decision is actually made.
- Direct user instructions take precedence over these project guidelines. Do not turn an unresolved question into an unnecessary approval barrier for unrelated, reversible work.
- Keep current behavior distinct from intended behavior. Do not describe planned systems as implemented.

## Implementation practices

- Work in small playable increments with a clear observable outcome.
- Keep simulation state independent of presentation. Opening a screen or changing a camera must not create resources or alter simulation results.
- Give persistent entities stable identities and clear ownership. Ship and outpost inventory must not be duplicated by docking, travel, unloading, saving, or loading.
- Make resource transfer, production, damage, and terminal run transitions explicit and inspectable.
- Use bounded, task-relevant document retrieval. Carry forward useful findings; do not repeatedly reread the entire documentation set or create recursive documentation tasks.
- Record the actual result of a change and its verification. A passing helper test does not establish that a complete player workflow works.
- Use focused checks for material behavior risks. Documentation changes need content and link checks; they do not require invented game tests or unrelated broad suites.
- Preserve other contributors' changes and keep edits scoped to the task.

## Keeping the docs useful

Update the owning document when behavior or a decision changes, then adjust its links and affected acceptance criteria. Keep the roadmap's progress tied to concrete evidence. Add real setup and test commands only after they exist and have been checked.
