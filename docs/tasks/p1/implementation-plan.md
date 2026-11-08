# p1 implementation plan — M1-P1

**Status: source-grounded plan; not executed.** This plan follows [the assessment](prompt-assessment.md) and serves only [M1-G1.1 and M1-G1.2](../../roadmap.md#m1-p1-a-coherent-ship). Follow the [stack contract and order](README.md). All proposed new scripts, helper flags, and commands below are implementation work, not existing capabilities.

## Source audit

Assessed remote `main` [295f2056](https://github.com/jfin602/space-factory/commit/295f205657527a2545b47ba3b47a5fbfb154608c), then reconciled the [a6b77498 runner port](https://github.com/jfin602/space-factory/commit/a6b77498d6319e65a9f49520e509b51083a7d9e1). The gameplay files are unchanged: a small C# bootstrap with no ship controller, helm, factory inventory, propulsion implementation, or placement system. The existing root package baseline is prepared at 0.1.0 for this authored p1 stack; that is tooling metadata, not gameplay progress.

| Existing source | Finding | Required change or preservation |
| --- | --- | --- |
| [main.tscn](../../../game/scenes/main.tscn) | Deck and Engineer are Main siblings, both at (480, 300); camera is another sibling; overlay is a CanvasLayer | Introduce ship-local ownership while preserving the initial visible arrangement. Keep world landmark/camera ownership distinct from the ship and HUD. |
| [Deck.cs](../../../game/scripts/Deck.cs) | Draws local deck bounds (-360, -210, 720, 420) and a decorative grid | Share one real deck-bounds definition with containment; do not invent a full logical construction grid. |
| [Engineer.cs](../../../game/scripts/Engineer.cs) | Reads named movement actions in `_PhysicsProcess`, calls `MoveAndSlide`, then clamps Position to X 140–820/Y 100–500 | Convert bounds and initial placement together; account for the existing radius-13 body. Route input through the selected mode owner. |
| [Main.cs](../../../game/scripts/Main.cs) | `--smoke` checks exact root-relative Deck/Engineer/Camera paths and overlay title, then exits from `_Ready` | Change path/title assumptions alongside scene changes; extend bounded checks without printing success before deferred physics checks finish. |
| [project.godot](../../../game/project.godot) | WASD/arrows map to four named movement actions; viewport is 960×600 | Preserve those bindings; add one named interaction action for helm entry/exit and communicate its binding. |
| [tools/dev](../../../tools/dev) | `check` imports, builds, runs a 30-second C# smoke, then scene automation and a missing-scene check; `run` builds and launches without forwarding extra user arguments | Reuse the check composition. P3 adds a narrow explicit fixture launch path; do not pretend `run` already forwards arguments. |
| [scene_tool.gd](../../../game/dev/scene_tool.gd) | Isolated saved-scene inspection/round-trip utility | Preserve it; game behavior and its C# checks must exercise the actual runtime, not a replacement GDScript simulation. |

Keep the selected Godot/.NET SDK, Compatibility renderer, C# namespace, named movement actions, clean window exit, CLI error behavior, and source UID conventions. [Development setup](../../development.md) owns pins/commands. Previous Linux bootstrap evidence remains historical evidence rather than a current gameplay result.

## State and scene boundaries

| Owner | Planned responsibility |
| --- | --- |
| Main/world | Main scene composition, stationary space reference, existing camera, smoke entry, and presentation wiring. |
| Ship root | Ship world transform plus a small control/capability owner. A proposed `game/scripts/Ship.cs` is reasonable if it keeps responsibilities clear; adapt to compatible source already present at execution time. |
| Deck and engineer under ship | Deck-local bounds/drawing and engineer-local movement/position. Convert both child starting positions to the new frame; retaining their old (480, 300) values would apply the offset twice. |
| Helm under ship | Visible helm location and nearby interaction target. Its local position travels with the ship; range is evaluated in a consistent coordinate frame. |
| One input/control owner | Walking/Piloting state, the current movement intent, one interaction edge, transition cleanup, and the real unavailable-propulsion reason. |
| Overlay | Observe current mode, interaction affordance, and capability failure; do not keep an independent gameplay mode or fake fuel meter. |

The fixed-orientation prototype requires no rotation, scaling, rigid-body ship simulation, collision world, multiple recreated views, generic entity framework, inventory subsystem, or actual engine force. Keep the current simple fixed camera unless a small framing change is required to see the hull and landmark.

## P1 — Scene ownership and bounds

Introduce a ship root at the appropriate world origin and make deck/engineer local to it. Keep the fresh scene visually coherent. Draw the hull/grid from one deck definition and contain the whole engineer body within an appropriate inset of those bounds. Current bounds embedded in `Engineer.cs` must not remain attached to screen/world coordinates.

Add a world-fixed landmark outside the ship's hierarchy. Verify that translating the actual ship root changes relevant world positions by the same offset while preserving local positions and the landmark. Keep the current required runtime nodes and smoke marker semantics meaningful as paths change. Ordinary movement stays engineer-only; this step does not add normal-play ship propulsion.

P1's focused checks cover initial composition, shared bounds and a nonzero ship-origin case. Deep control/fixture integration belongs to P3; do not introduce a duplicate scene model just to test local math.

## P2 — Helm and control arbitration

Add a named interaction action, initially using a simple communicated binding such as E, and one authoritative mode owner. A single interaction edge may enter only while nearby; it may exit while piloting. Do not let separate handlers enter and exit in the same frame.

On entry, stop engineer movement and clear residual walking velocity without teleporting the engineer. In Piloting, movement input may form a ship-control intention but cannot move the engineer. On exit, clear the previous ship request immediately; subsequent Walking uses current input normally and must not revive stored thrust. Repeated interactions preserve positions and state. Range must still work after ship translation.

Represent the actual P1 capability: no connected/available propellant supply, hence no applied thrust. Derive the explanation from that owner. Do not create an inventory/tank mock, manufactured fuel, or a HUD-only working-state flag. Later M1 Phases supply the real inventory/engine behavior. Show current mode, the nearby interaction hint, and the failure reason when a pilot requests unavailable thrust.

## P3 — Bounded fixture and integrated checks

Add the explicit developer command **`./tools/dev p1-demo`**, implemented in this step, to build and launch the real main scene with game user argument **`--p1-spatial-demo`**. Reuse existing tool selection and logging conventions. At assessment time neither the command nor flag exists. Document the command in development setup only after it exists and has been checked.

The flag enables a visibly labeled **development translation fixture** on the actual ship root. Move through a small bounded translation, then hold or reset predictably so the engineer can walk and test helm range at the translated origin. Keep the hull and stationary landmark in view. Do not require the owner to edit source between observations. Normal `./tools/dev run` must neither enable the fixture nor provide a hidden free-flight control. The fixture grants no propellant and is not powered-flight evidence.

Extend the existing real-scene C# smoke or a small C# helper it invokes. Reuse actual movement and control paths, allow bounded physics frames where needed, release injected test inputs, and finish within the existing smoke timeout. Print the success marker only after all required checks pass; missing nodes, failed invariants, or timeouts must produce a failed check. Preserve existing saved-scene automation.

| Check | Observable invariant |
| --- | --- |
| Initial and translated hierarchy | Engineer/deck/helm retain local positions; world positions change with the ship; the landmark does not. |
| Four bounds and corners | The engineer remains within the body-inset deck before and after a nonzero translation. |
| Nearby/out-of-range helm | Only a nearby Walking engineer can enter; range uses the same space after translation. |
| Exclusive controls | Walking changes engineer position only; Piloting preserves engineer local position and generates only a ship intention. |
| Held-input transitions | Enter while walking, exit while requesting a pilot direction, and repeat; residual walking velocity and old ship requests are cleared at the right transition. |
| Unpowered ordinary scene | A registered pilot intention applies no thrust and cannot move the ship or create resources. |
| Runtime failure semantics | New checks exercise actual runtime ownership and fail meaningfully; an unchecked or failed branch cannot emit the final success result. |

Use T2 evidence to establish these integration boundaries. Do not add a testing framework or repeat multiple independent builds. P3 prepares a native observation path; it does not certify visual quality or real keyboard/focus behavior.

## P4 — Native checkpoint and sole closeout

The final closeout prompt is deliberately manual. P4 uses the repository's historical `Browser required: yes` field for the native Godot handoff, so it remains stopped even with the automatic-closeout option. Use the normal command without `--closeout`; the additional `GUI required` description is not a substitute for that canonical field. Actual native desktop tools or owner observations are required.

Observe two distinctly labeled runs on the same relevant source candidate:

1. **Normal play:** walk the boundaries, approach the helm from outside/inside range, enter/exit while directions are held, verify instructions/reason, and confirm pilot input supplies no ship motion.
2. **Explicit fixture:** observe actual ship translation relative to the stationary landmark, then walk and use the helm at the translated location without offset/drift.

Record actual inputs and before/after state or images; a screenshot alone cannot prove interaction range, movement, or transition cleanup. Native automation may perform the steps when available. Otherwise hand the owner the exact actions and retain NOT OBSERVED until results are available. Do not invent installed capture utilities or count a headless check as native observation.

P4 uses `./tools/dev run` and the newly implemented `./tools/dev p1-demo`; these wrappers build as part of launch. Avoid a separate duplicate build/check on an unchanged candidate. If a repair changes relevant source, rerun only the invalidated focused/integration/native checks and preserve the failure history.

Write the source-bound native result and final closeout, then reconcile only the selected Gate statuses plus actual module/BOOT/task routing. Both Gates need their applicable native evidence before M1-P1 can pass. Passing this stack does not qualify factory production, full broader Phase 0/1, or powered flight. Advance to M1-P2 only when this scope is supported; otherwise route to the concrete missing observation or bounded repair.
