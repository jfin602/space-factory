# P1 prompt assessment — M1-P1: A coherent ship

**Disposition: authored planning; not executed.** This stack targets only [M1-P1](../../roadmap.md#m1-p1-a-coherent-ship), specifically M1-G1.1 (ship/interior ownership) and M1-G1.2 (helm/control modes). The folder name `p1` and runner Phase 1 metadata identify this execution stack; they do not expand it to the broader roadmap's Phase 1, the full five-Phase M1 milestone, or factory-powered flight.

## Outcome and baseline

The player can walk within a recognizable ship, approach its helm, enter and leave Piloting mode, and understand that propulsion has no available supply. The deck, engineer, and helm keep their local positions when a deliberate development fixture translates the ship against a stationary world reference. Ordinary gameplay remains unpowered.

The gameplay assessment inspected `jfin602/space-factory` remote `main` at [295f205657527a2545b47ba3b47a5fbfb154608c](https://github.com/jfin602/space-factory/commit/295f205657527a2545b47ba3b47a5fbfb154608c). During authoring, the published runner port and updated repository contract were rechecked at [a6b77498d6319e65a9f49520e509b51083a7d9e1](https://github.com/jfin602/space-factory/commit/a6b77498d6319e65a9f49520e509b51083a7d9e1); the assessed gameplay files remained unchanged. The accepted milestone plan is documented, and gameplay still has the engineer/grid bootstrap. These source identities are not reset targets. Execution must inspect current HEAD and relevant local work before making changes.

| Current source | Finding | Required response |
| --- | --- | --- |
| [main.tscn](../../../game/scenes/main.tscn) | Deck and Engineer are Main siblings, each positioned at `(480, 300)`; Camera2D is also a root sibling | Introduce ship-local ownership and convert initial child positions with the parent transform. Keep external references outside the ship. |
| [Deck.cs](../../../game/scripts/Deck.cs) | Draws a local rectangle `(-360, -210, 720, 420)` and visual grid | Give drawing and containment one bounds definition; introduce no general construction system. |
| [Engineer.cs](../../../game/scripts/Engineer.cs) | Uses named movement actions but clamps Position to fixed X/Y ranges | Replace those assumptions with deck-relative containment and exclusive control routing. |
| [Main.cs](../../../game/scripts/Main.cs) | Smoke checks exact root-relative node paths and title text before emitting the C# runtime success marker | Update affected assertions with scene changes; preserve meaningful failure and exit behavior. |
| [tools/dev](../../../tools/dev) | Provides the documented development commands; `check` composes import, build, main-scene smoke, and scene automation | Reuse this composition and add only the bounded fixture launch needed for qualification. |

The runner is now present. Its documented commands include `npm run space-factory:phase:validate -- p1` for validation and `npm run space-factory:phase -- p1` for the intended normal launch. Follow the stack README and current runner contract when execution begins; authoring and validation do not execute gameplay prompts.

The imported root Node package starts at version `0.0.0`. This authoring change prepares its existing development checkpoint metadata at `0.1.0` so the requested `p1` folder matches the runner's Phase 1 grammar, with prompt checkpoints `0.1.1` through `0.1.4`. This narrowly scoped metadata preparation is not P1 gameplay implementation, an engine-version change, a public game-release qualification, or evidence that any Gate passed. Runner code and port functionality remain outside this stack's changes.

## Preserved behavior and scope

Preserve the Godot/.NET/C# stack, existing movement actions, placeholder visual conventions, clean window close, real C# smoke execution, scene automation, relevant UID files, and unrelated owner work. Read [AGENTS.md](../../../AGENTS.md) and [BOOT.md](../../../BOOT.md), then only the source and document sections needed by the selected prompt. Keep current findings and completion evidence through recovery.

The scene/state boundary is deliberately small: one ship owner, one shared deck-bounds definition, one engineer, one helm interaction, and one authoritative Walking/Piloting mode. The input path may expose a pilot intention without applying propulsion. The unavailable-supply message must derive from that genuine capability/state, not a second HUD-owned fuel variable or an invented tank simulation.

Normal play receives no free flight, test fuel, production shortcut, or developer movement key. The development translation fixture is separate, explicitly labeled, and demonstrates spatial ownership only. It does not qualify M1-G4.1 or demonstrate factory-supplied movement.

Defer inventories, cargo loading, pipe installation, recipes, tanks, resource consumption, engine forces, actual flight, beacon objectives, M1-P2 through M1-P5, unrestricted construction, rotation, damage, saves, survival, outposts, and platform release qualification. P1 also does not port or redesign the runner.

## Decomposition and dependencies

| Prompt | Coherent deliverable | Dependencies and evidence | Tier | GUI required |
| --- | --- | --- | --- | --- |
| `P1-ship-local-ownership.txt` | Ship-local scene hierarchy, correct initial transforms, shared deck-relative bounds, stationary external reference, and adapted smoke paths | Inspect current bootstrap; establish geometry and immediate spatial invariants before helm work | T1 | no |
| `P2-helm-control-modes.txt` | Nearby helm interaction, one exclusive mode owner, input cleanup, truthful unavailable-supply capability, and contextual overlay | P1 ownership/bounds; check range and input transitions without introducing propulsion | T1 | no |
| `P3-spatial-fixture-integration.txt` | Bounded labeled translation fixture on the actual main scene, integrated behavioral checks, and a precise native handoff | P1/P2; extend real C# smoke/failure semantics and exercise translation plus control boundaries | T2 | no |
| `P4-native-ship-helm-closeout.txt` | Observe both Gates in the native game, then perform the stack's sole evidence/documentation closeout | P3 candidate and focused results; direct input/visual evidence is required before a passing disposition | T3 observation, then T1 document reconciliation | yes |

The order is strict. P1 creates the geometry consumed by P2. P3 verifies their interaction and provides a launchable observation fixture. P4 collects the player-facing evidence that headless checks cannot supply and then reconciles the actual result.

There is one final closeout. The imported runner stops before final closeout by default, whereas `GUI required` is informational and does not itself create a native-game pause. P4 therefore combines the native checkpoint and closeout. Per the current repository contract, its historical `- Browser required: yes.` metadata is the runner-recognized native Godot/manual-handoff flag; P4 also states `GUI required: yes`. P1–P3 use `Browser required: no`. The intended normal launch must not use `--closeout` to run P4 automatically. Inspect the actual current runner before execution and preserve this native evidence boundary.

P3 is planned to add `./tools/dev p1-demo`, invoking the explicit game user argument `--p1-spatial-demo`. Neither is an existing command at this assessment baseline. The fixture must perform a bounded translation/hold/reset sequence on the actual ship, identify itself visibly, and leave ordinary control requests unpowered. Its implementation and documented launch path belong to P3; the manual tester must not need to edit source to activate it.

## Risks and focused safeguards

| Risk | Safeguard and useful observation |
| --- | --- |
| Reparenting applies the original `(480, 300)` twice | Convert initial positions together with the ship root; compare local and world positions before and after translation. |
| Drawing and containment disagree | Share deck bounds and account for the existing engineer collider radius; check all edges/corners after translation. This does not require a wall-physics or placement framework. |
| External scenery travels with the ship or only the camera changes | Keep the landmark in world space and observe ship movement relative to it; frame both clearly during the fixture. |
| More than one component toggles modes from the same action | Use one authoritative interaction/mode transition path; test repeated presses and reject out-of-range entry. |
| Walking velocity or pilot intention leaks through a mode transition | Clear the inactive movement/request state; enter while moving and exit while holding a pilot direction. Preserve engineer local position. |
| A dummy fuel subsystem makes unavailable feedback misleading | Report the real absent supply/capability and apply no propulsion. Do not introduce a fake reserve, free-flight branch, or independent UI state. |
| The fixture becomes an ordinary propulsion bypass | Require explicit developer launch, visibly label it, bound its motion, and check normal launch remains stationary under pilot input. |
| Smoke succeeds after hierarchy failure or bypasses the real implementation | Adapt current node checks, exercise actual scene/control paths, and preserve nonzero failure and success-marker discipline. |
| Automation is mistaken for live gameplay evidence | Keep checks and GUI observations separate; P4 cannot mark either Gate passed without its required source-bound observation. |

The highest-value integration checks stimulate the implemented paths: ship translation preserves local ownership; deck bounds still apply after translation; helm range uses compatible coordinates; walking and piloting are exclusive; transitions clear stale requests; and normal pilot input cannot move an unpowered ship. Avoid building a duplicate simulation only to test it, or a large testing framework for this small scene.

## Validation efficiency and budgets

Follow [the workflow](../../workflow.md): ordinary prompts target up to eight minutes including focused validation, with a ten-minute soft ceiling and fifteen-minute ordinary execution budget. These are decomposition guides, not completion guarantees or reasons to hide incomplete work.

P1 and P2 each own one cohesive change. Run the smallest check supporting that changed candidate and carry its evidence forward. Preserve essential smoke coverage while restructuring the scene; do not defer a known broken entry point. P3 is the dedicated T2 integration step and may reasonably exceed the ordinary target if actual scene/frame/input behavior or a material repair requires it. P4 is the dedicated native qualification/closeout step; its duration depends on real GUI access, observed behavior, and evidence collection.

Inspect command composition before running checks. `./tools/dev check` already imports, builds, runs the main-scene C# smoke, and exercises scene automation. Do not repeat those parts on an unchanged candidate without a concrete reason. Source changes can warrant rerunning affected checks; documentation closeout alone does not. GUI-required work is concentrated in P4 instead of being implied by each earlier headless prompt.

Do not add unconditional export, broad platform, performance, save/load, or full-game suites. This stack needs meaningful geometry/control checks plus the actual native player sequence. No build or gameplay test is claimed by writing these prompts.

## Native handoff and final disposition

P4 observes ordinary play first: deck limits, nearby versus distant helm interaction, mode feedback, repeated entry/exit, held-direction cleanup, and truthful unavailable propulsion with no normal ship movement. It then uses the explicit spatial fixture to observe translated ship/interior coherence, a stationary world reference, and correct walking/helm behavior after translation.

Screenshots support appearance and before/after state; record actual actions or a recording for movement and interaction claims. Capture source identity, relevant dirty state, platform/tool versions, expected/observed results, and limitations. If native access is missing or a behavior fails, record NOT OBSERVED or FAIL, preserve evidence, and identify the exact next task. A human progression decision does not convert that result into PASS.

The [roadmap](../../roadmap.md) remains the sole Gate/progress authority. At the single closeout, link actual evidence, update [MODULES.md](../../../MODULES.md) only for responsibilities that now exist, and reconcile BOOT/task routing with the real disposition. Passing M1-G1.1 and M1-G1.2 does not automatically qualify broader Phase 0/1 criteria or later M1 work. Preserve earlier executed prompts and failures when a correction is required.
