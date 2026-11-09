# M1-P2 implementation plan

**State: authored, not executed, 2026-11-08.** Implement [M1-P2](../../roadmap.md#m1-p2-prepare-the-factory) against the current repository, with inspected source at [f274c896](https://github.com/jfin602/space-factory/commit/f274c89630a6033ccd79ad98b7fee6369dd5778a). This plan refines the accepted [first-flight design](../../planning/p1/first-flight.md); its task choices do not expand the milestone. [The assessment](prompt-assessment.md) records decomposition and risks; [the README](README.md) indexes the executable prompts.

## Scene and ownership contract

Keep `Main/Ship/{Deck,Engineer,Helm}` and the world-owned camera/beacon. Add the fixed factory arrangement below `Ship`, optionally as a small `Factory` subtree containing cargo, processor, tank, engine, and pipe-socket anchors. All positions and pipe geometry belong to the ship frame. Preserve deck bounds, engineer containment, the current helm, and the normal unpowered scene.

Use stable identifiers for the few actual targets/endpoints. Scene names or a small explicit enum are sufficient; no entity registry or general grid-placement system is required. Arrange the machinery with reachable interaction points, readable labels, and an unobstructed approach to the helm. Visuals can use existing Godot shape/label conventions. A visible solar hookup may indicate the already-installed starter supply; it must not simulate electricity or create material in P2.

`Ship` retains control-mode/capability ownership. One small C# factory-state instance owns quantities and connection state; `Ship` holds or refers to it for the lifetime of the scenario. UI, scene drawing, and input callbacks read that instance and submit actions. Opening a panel, changing modes, translating the ship, or refreshing the HUD cannot construct a new inventory. Avoid mutable shared Godot resources or static stores that leak state between scenario instances.

Likely source changes are a small factory state file and presentation/interaction helpers under `game/scripts/`, `Ship.cs`, `Main.cs`, and `game/scenes/main.tscn`. These are proposed locations, not claims that subsystem files exist. Keep normal namespace and Godot UID conventions. Change `Engineer.cs`, `Deck.cs`, or named input definitions only where the chosen interaction boundary requires it. Runner source and engine/SDK pins remain outside scope.

## Resource and transaction contract

The scenario contains the following real owners:

| Owner | Initial contents and limit |
| --- | --- |
| Cargo | A documented finite amount of ice and exactly one pipe segment |
| Engineer inventory | Empty carried ice and pipe slots/counts, with explicit capacity |
| Processor input | Empty bounded ice storage |
| Processor output | Empty bounded propellant storage |
| Tank | Empty bounded propellant storage |

Use discrete counts for ice and the pipe. Choose an appropriate finite numeric representation for later propellant flow; reject nonfinite values wherever that representation permits them. Keep starting quantities, capacities, interaction ranges, and the positive ice-transfer batch in named configuration. Require positive carried-ice and processor-input capacities, room to carry the one pipe, and initial cargo ice greater than processor-input capacity. Ordinary Take/Load actions must be able to fill the processor and leave reachable ice for another rejected full-input attempt and later recovery; final flight balance is later work. Record chosen values and units in execution evidence rather than treating an illustrative number as a new product requirement.

For a positive transfer request, move only the amount allowed by the request, source stock, and destination free capacity. Report that actual amount. Debit the source and credit the destination exactly once in the same synchronous operation. Reject invalid quantities, incompatible resources/endpoints, self-transfer, or impossible transactions without mutation. No store may become negative or exceed capacity. Taking a pipe moves an item; installation converts that carried part into the installed connection.

The pure resource operation owns accounting. The authoritative player-action handler owns the additional current mode, target, and range checks. Panels must call that handler, never mutate stores directly. All checks occur before the mutation; no asynchronous callback may later apply an already-stale transfer. Isolated tests can call the same state operations, while integration tests must also use the real action path.

## Interaction contract

Use one dispatcher that extends the existing `Ship` interaction path:

1. In Walking with no panel, an E press selects the nearest eligible interaction target in range. Resolve equal-distance candidates by a stable documented priority/identifier. Show the selected target before activation. If none is in range, show a useful approach message.
2. The helm enters Piloting directly. Cargo, processor, and the socket open one compact context panel. The cargo panel offers **Take ice** and **Take pipe**; the processor offers **Load ice**; P4 supplies **Install pipe** at the socket. P3 may expose the socket without enabling installation yet.
3. Show the requested positive ice batch, available/carried/input quantities, relevant capacities, and actual transaction result. No drag-and-drop grid, recipe chooser, text quantity editor, or general build menu is needed.
4. E while a panel is open closes that panel only; Escape also closes it. Walking remains available. Moving out of the target's range or changing mode closes or invalidates the panel. A button action requires its matching panel opening to remain active; revalidate that opening, target identity, mode, range, stock, and capacity at application time. A callback captured before closing/replacing a panel must stay invalid even if that target is reopened nearby; use a small opening token if callbacks can retain old requests.
5. In Piloting, E always exits the helm and preserves P1's immediate direction/velocity cleanup. Factory actions are unavailable. Release events and keyboard echoes must not produce duplicate activations; distinct valid presses may perform distinct transfers.

Consume handled UI input so it cannot also reach another gameplay action. Configure button focus/input handling so the existing movement controls and E remain predictable. Do not add a second mode owner or a hidden movement-lock mode just to support the panel. Use the existing `interact` action and an existing suitable cancel action or a narrowly defined named action where needed.

`Main.RefreshHud()` currently assumes the helm is the only target and clears walking feedback every frame. Replace those assumptions with target/help and a retained action result from the interaction owner. Define a short readable lifetime or explicit replacement rule for that result. Show failure causes such as empty carried supply, full processor, missing pipe, already installed, and out of range. Unavailable-propulsion feedback must now refer to the actual empty tank/supply state while preserving the fact that P2 applies no thrust.

## Connection contract

The only player-installed route is **processor output → propellant tank**. It begins absent. The tank-to-engine route is installed from startup and refers to the same real tank. No separate engine fuel counter or free-flight supply is introduced.

Installation requires Walking, the current socket in range, an absent route, and one carried pipe. Consume one part and establish the installed connection as one transaction; a failed or repeated installation changes neither inventory nor connection. Update visuals from that installed state and show the source and destination clearly.

The connection carries explicit endpoint identities, a finite positive transfer rate, and receiving-capacity limits. Supply a small bounded transfer operation suitable for later use by the authoritative game clock. When connected and passed valid elapsed time, the transferred amount is limited by source output, rate multiplied by elapsed time, and tank free capacity; debit and credit the same amount. Disconnected/invalid endpoints, invalid time/rate, empty output, or full tank must not create or lose propellant. Use appropriate floating-point tolerance in checks if needed.

**P2 does not schedule production or delivery in normal play.** There is no recipe job and no normal source of propellant yet. Exercise the transfer operation on fresh isolated C# state only in the smoke path, with explicitly seeded test output. Assert that the real fresh scenario's processor output and tank remain zero and that a test fixture cannot leak into `./tools/dev run`. M1-P3 will drive this same route with manufactured output and shared game time.

## Work order and likely changes

| Prompt | Work boundary | Likely changes and handoff |
| --- | --- | --- |
| P1 | Resource owner and transfer rules | Small C# state/configuration plus focused C# smoke checks; expose one scenario instance and record units/capacities |
| P2 | Fixed factory scene | Factory subtree/visual adapter, target anchors/identities, real counts, and basic ownership checks |
| P3 | Nearby take/load workflow | Ship dispatcher, context panel, state-backed HUD feedback, and exact control/focus contract |
| P4 | Install and transfer route | Activate the socket action, implement part-to-connection transition and finite delivery operation, test isolated route states |
| P5 | Actual-scene integration | Extend existing smoke/fixture integration through real handlers, preserve previous controls, document the candidate |
| P6 | Native qualification and closeout | Observe ordinary and translated scenes, retain results, decide selected Gates, and reconcile current documentation |

Do not collect unrelated architecture cleanup into these tasks. A small helper can keep checks or presentation out of `Main.cs` if it serves this work, but no new test framework is needed. Keep smoke-only fixture creation clearly separate from ordinary scenario construction.

## Verification and evidence

`./tools/dev doctor` inspects readiness if the environment is unknown or changed. `./tools/dev check` already imports assets, builds C#, runs the ordinary and spatial-fixture real-main-scene smokes, exercises saved-scene automation, and checks the expected missing-scene failure. Run the relevant composition once per changed candidate; do not precede it with redundant builds/imports. `./tools/dev inspect-scene scenes/main.tscn` is available for a concrete composition question, not a mandatory extra check.

Use the actual C# operations and scene handlers. Keep the existing smoke success/failure and bounded-exit behavior: a failed required assertion must reach a nonzero failure, never the overall success marker. Record the added P2 proof markers or measured quantities without conflating existing `SPACE_FACTORY_P2_CONTROL_OK`/`SPACE_FACTORY_P3_FRAMES_OK` names with this roadmap Phase; those older markers describe P1's internal prompt numbers.

| Evidence | Required observations |
| --- | --- |
| P1 focused accounting | Finite initial quantities, zero output/tank, exact debits/credits, bounded partial transfer, empty/full/invalid requests unchanged, isolated instances |
| P2 scene composition | Factory targets and visual endpoints in the ship frame, valid capacities/labels, reachable authored positions, normal scene remains unpowered |
| P3 action boundary | Actual cargo → carried → input transfers; deterministic target selection; one event one action; range/mode/stale-panel guards; retained feedback; preserved helm behavior |
| P4 connection | Missing-part and repeated-install cases; part consumed once; real endpoint ownership; isolated disconnected/rate/capacity/time-limit transfer cases |
| P5 integration | Complete real-scene preparation; conserved ice across cargo/carried/input; pipe count plus installed state reconciles; normal output/tank zero; mode and ship translation preserve the same resources/connections |
| P6 native | Visible Take/Load/Install workflow, readable values and failures, panel focus and range behavior, helm transitions, and functioning interactions in the translated fixture |

Existing Main checks assume the engineer can press E near its initial position to enter the helm. Place/select the engineer deliberately for those assertions once factory targets exist. Preserve full-body bounds, exclusive direction routing, held-input cleanup, stationary beacon, and the labeled fixture's non-propulsion distinction. Extend spatial checks to all new machines/socket endpoints without resetting their inventories during movement.

Native observation uses `./tools/dev run` and `./tools/dev p1-demo`. A fresh launch can establish initial state; a general Restart playtest feature remains M1-P5. Test empty carried input by attempting Load before taking ice. The configured starter stock/capacities must permit filling the processor through legitimate transfers, then attempting another load with real carried ice to observe full-input feedback. Exhausting cargo is a focused rule test unless normally reachable without adding an unload/discard feature. Missing/disconnected delivery and time-rate limits are focused/integration proofs; P2 cannot visibly manufacture fuel.

P1–P5 append source-bound results to `docs/tasks/p2/qualification/implementation.md`. P6 creates `qualification/native-playtest.md` and `closeout.md`. Record actual revision, any dirty-source applicability, tool/platform identity, action/command, expected and observed result, failures/repairs, and limitations. Retain only necessary screenshots/log excerpts durably; temporary generated output stays in the existing ignored artifact locations. Do not create a PASS record during authoring.

## Version and runner contract

The authored stack uses `Phase 2`, folder `p2`, baseline `0.2.0`, and assigned versions `0.2.1`–`0.2.6`. P1–P5 are implementation/integration prompts with `- Browser required: no.`; P6 is the single final closeout with `- Browser required: yes.`. The latter is the historical parser field for the native handoff and stops even with `--closeout`.

Each ordinary prompt sets its assigned root package version only after required implementation/checks pass. Preserve root scripts/settings and all engine/SDK pins. The runner owns implementation commits; a task must not self-commit. On failure retain work and report the precise remaining requirement; on continuation reconcile actual version/checkpoint state before touching it. Do not fabricate a new checkpoint or rewrite old history to bypass a failed task.

P6 can set `0.2.6` only after its required P2 qualification passes; otherwise retain `0.2.5` and preserve failed/unobserved results. Leave closeout changes uncommitted for human review. The [runner guide](../../phase-runner.md#checkpoints-dirty-work-and-resume) and stack README own detailed continuation semantics.

## Closeout and next Phase

Compare source-bound evidence with M1-G2.1 and M1-G2.2, not just prompt completion. Update the selected roadmap results and Phase state only as supported. Reconcile BOOT, this stack's README, MODULES, and the affected factory/UX/current-status descriptions once. Preserve historical P1 records and report any regression explicitly rather than silently deleting prior evidence. Broader G0/G1 Gates and later M1 results remain unchanged by this scoped closeout.

A qualified P2 hands M1-P3 real inventories, a loaded input buffer, an installed route, an empty tank, explicit capacities/rate, and the existing shared ship/control context. M1-P3 then adds the timed ice-to-propellant recipe, startup solar behavior, normal flow, and production feedback.
