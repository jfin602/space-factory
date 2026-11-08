# M1-P1 implementation evidence

## P1 — Ship-local ownership (2026-11-08)

**Source identity:** `main` at `4ec4b625b7948f02ba6df938263eea7e763dc579`, with a clean working tree before implementation. This is uncommitted work against that revision. The checked gameplay source is identified by SHA-256: `main.tscn` `ae6e7a2c5a572deedfca43f41d3fb3f9da9aac3af84a0cf6434b42d8eba7e1db`, `Deck.cs` `e2f80fc5b42117fd8a181bdbcd21e4b251b011b9778cfa4329f423dc8ec1d540`, `Engineer.cs` `f3aba7cbe7c20fcd61913a8a6fec6656a11ade0539b7519a143666ad8a6ce6ec`, and `Main.cs` `2cf64e66e28c83d01ebfee49ff54be9c11499e4fdbe07fa24294c1cd6ad032b0`.

**Changed files:** `game/scenes/main.tscn`, `game/scripts/Deck.cs`, `game/scripts/Engineer.cs`, `game/scripts/Main.cs`, this evidence file, and the root `package.json` version only (`0.1.0` → `0.1.1`). Existing Godot and .NET pins, named movement actions, camera, and HUD remain in place. No new script or UID sidecar was needed.

**Implemented state:** `Ship` owns `Deck` and `Engineer`; its initial world position is `(480, 300)`, while both children start at local `(0, 0)`. The camera stays at world `(480, 300)` under `Main`, the HUD stays under `Main/Overlay`, and the beacon `Landmark` stays under `Main` at world `(930, 300)`. The deck interior is `Rect2(-360, -210, 720, 420)`. Drawing and containment use that same definition. The engineer's 20-pixel inset gives center limits X `[-340, 340]`, Y `[-190, 190]`, containing the radius-13 collision and drawn body/shadow. Walking still uses the existing WASD/arrow actions; normal play has no ship movement command.

**Actual commands and results:**

| Command | Result |
| --- | --- |
| `./tools/dev doctor` | PASS: Godot 4.7.2 .NET and .NET SDK 10.0.403 available. |
| `./tools/dev check` | PASS, once on the gameplay candidate: import; C# build with 0 warnings and 0 errors; real `main.tscn` smoke marker and exit; scene automation; expected missing-scene failure. |
| `git diff --check` | PASS before the version/evidence edit. |

The real-scene C# smoke checks initial ownership and positions, translates `Ship` by `(37, -24)` to `(517, 276)`, and confirms deck/engineer world positions move by that delta while their local positions and both landmark positions stay fixed. It also sends the engineer beyond all four deck corners, invokes the gameplay containment path, and checks the resulting body inset. Any failed invariant prevents the success marker and exits with failure. These are headless runtime results; native appearance and keyboard input are **NOT OBSERVED** for this step.

**Remaining gaps and P2 handoff:** M1-G1.1 remains unqualified pending native observation in P4. P2 adds the nearby helm interaction, exclusive Walking/Piloting control, transition cleanup, and truthful unavailable-propulsion feedback. P3 owns the deliberately visible translation fixture and integrated control checks. Do not infer powered flight or mark M1 Gates PASS from this P1 smoke.

## P2 — Helm control modes (2026-11-08)

**Source identity and prerequisite:** Continued from the uncommitted P1 source above on `main` at `4ec4b625b7948f02ba6df938263eea7e763dc579`; root version was `0.1.1` and P1's `./tools/dev check` had passed. P1 files and evidence were preserved. The passing P2 gameplay source has SHA-256 `main.tscn` `dc5e348ea225bde356eb88b1357df4d553feae415e3f41eb240304260196e0c4`, `Engineer.cs` `556b2551ca2195a7cdf5d431c104554d624d3629371348a06418c1d8542bc6d9`, `Main.cs` `1d229b7ed41a80d1edc20c7036056cdafb30808e6e932eab3f635db57d53d6cc`, `Ship.cs` `31a39a6b93ab8e7cf82e744463f1811c32a979c21f1ce27903f071727e92ecd2`, and `project.godot` `1a7284872d8b7d0056d811ffc03119fa99ddc6f97fe7f19848bbfc70b7ebb35f`.

**Changed for P2:** `game/scripts/Ship.cs` (new control/capability owner) and its generated `Ship.cs.uid`, `game/scripts/Engineer.cs` (walk from ship-routed direction), `game/scenes/main.tscn` (ship-local helm and mode/help/feedback labels), `game/project.godot` (named `interact` action bound to physical **E**), `game/scripts/Main.cs` (state-derived HUD and focused real-scene checks), this evidence file, and only the root `package.json` version (`0.1.1` → `0.1.2`). WASD and arrow actions remain mapped as before.

The helm starts at ship-local `(0, -95)` and accepts Walking interaction within 100 world units, measured between the engineer and helm global positions. `Ship` alone owns Walking/Piloting, routes each direction to either `WalkingDirection` or `ThrustRequest`, and handles one `interact` press event per transition. Entry/exit clear both requests and engineer velocity without changing positions. `Ship.PropulsionUnavailableReason` is `No propellant supply available`; no supply or applied propulsion exists. The HUD reads the ship's mode, range, request, and reason; it holds no separate capability state.

**Commands, failure, repair, and observed results:**

| Command | Result |
| --- | --- |
| First `./tools/dev check` | FAIL at `walking moves only engineer`: the smoke invoked movement during `_Ready`, before a physics frame elapsed. Import/build passed; no success marker was printed. |
| Repair | Wait one actual `PhysicsFrame` before the existing scene smoke; keep the walking assertion on the real engineer physics path. |
| Second `./tools/dev check` | PASS: import, C# build (0 warnings, 0 errors), real-scene smoke, scene automation, and expected missing-scene failure. |
| Final `./tools/dev check` after adding result diagnostics | PASS with the same components and printed P2 state values below. |
| `git diff --check` | PASS on the passing gameplay candidate. |

The passing smoke refused a press from engineer local `(200, 0)` while Walking, accepted one press near the helm, ignored release as a transition, and repeated entry/exit without position changes. It repeated range refusal and acceptance after ship translation by `(37, -24)`. Walking right moved the engineer to `(3.6666565, 0)` with velocity `(220, 0)` and no ship motion. Entry while right was held left engineer velocity and both requests `(0, 0)`. Piloting right recorded `ThrustRequest=(1, 0)` with engineer velocity `(0, 0)`, unchanged engineer position, and unchanged ship position; the HUD showed the ship owner's missing-supply reason. Exiting while right was requested immediately set thrust request and velocity to `(0, 0)`. A subsequent Walking right input moved only the engineer and did not revive thrust. These values came from `SPACE_FACTORY_P2_CONTROL_OK` in the final smoke log. A failed invariant still prevents `SPACE_FACTORY_SMOKE_OK` and returns failure.

**Remaining risks and P3/P4 handoff:** Native E and direction-key behavior, focus, helm readability, and HUD readability remain **NOT OBSERVED** until P4. M1-G1.1 and M1-G1.2 remain unqualified. P3 should use `Ship` and its real scene nodes for the explicit visible translation fixture and broader frame-based integration checks; P4 should observe native controls and appearance. This manual, uncommitted P1→P2 continuation has versions `0.1.1`→`0.1.2` in the working tree but no runner checkpoint commits. The runner's Git-history resume rules will need reconciliation before resuming this stack through the runner; no checkpoint commit is fabricated here.

## P3 — Spatial fixture and integration (2026-11-08)

**Source identity and prerequisites:** Continued the passing, uncommitted P1/P2 work on `main` at `4ec4b625b7948f02ba6df938263eea7e763dc579`, starting from root version `0.1.2`. P1/P2 evidence and source were preserved. The checked P3 source has SHA-256 `main.tscn` `5857009ef77d1aa5a499fa013cb1de965593d8690e2593bbd677aae8edd83fc3`, `Main.cs` `88287edb5df677f7730ede8c29cd760eecaa2f8bc926877611a268495d2ba6d2`, and `tools/dev` `14ccf099b5700b06a79ed316baef9ac53d33a76e610bcbf3dcedd3f3cb3a34cb`. Unchanged P2 `Ship.cs`, `Engineer.cs`, and `project.godot` retain their P2 hashes above.

**Changed for P3:** `tools/dev` gained `p1-demo` and a second, flagged smoke in `check`; `game/scripts/Main.cs` gained the flag-gated fixture and frame-based integration checks; `game/scenes/main.tscn` gained its normally hidden development label; `docs/development.md` documents the verified command and check scope; this evidence file was appended; only the root `package.json` version advanced (`0.1.2` → `0.1.3`). The fixture uses the existing real ship root and never creates resources or applies thrust.

**Commands and results:**

| Command | Result |
| --- | --- |
| `bash -n tools/dev` | PASS: shell syntax. |
| `./tools/dev help` | PASS: `p1-demo` appears in dispatch help. |
| `./tools/dev check` | PASS, once on the final gameplay candidate: import; C# build with 0 warnings/0 errors; ordinary and flagged real-main-scene smokes; scene automation; expected missing-scene failure. |
| `git diff --check` | PASS on the checked candidate. |

The ordinary smoke confirmed P1 ownership and world/ship-local transforms, tested all four corners and all four edges of the 20-pixel body-inset deck at both the initial and a translated ship position, then retained P2's nearby/distant helm and mode checks. Its additional actual physics-frame sequence held `move_right`: Walking moved the engineer to `(7.333313, 0)` without ship motion; entering Piloting cleared walking velocity/request; subsequent frames recorded pilot request `(1, 0)` while the engineer and ship stayed fixed; exiting cleared the thrust request immediately to `(0, 0)` and subsequent frames resumed only Walking. Injected `move_right` was released in a `finally` path.

The flagged smoke passed the same integration checks, then ran the real `_Process` fixture path. `--p1-spatial-demo` enabled a visible development label and translated the actual ship from `(480, 300)` to `(420, 280)` over 1.25 seconds, then held it through further frames. Deck, engineer, and helm local positions remained fixed; their world positions followed the ship; the beacon stayed at world `(930, 300)`. The headless check asserted the label/flag, bounded progress, final offset, hold, preserved body bounds, and translated nearby helm range before printing `SPACE_FACTORY_P1_DEMO_OK`. The ordinary smoke asserted its fixture label was hidden and its ship origin unchanged. Any failed or timed-out assertion prevents the general success marker.

**P4 handoff and unobserved cases:** Launch normal play with `./tools/dev run` and the explicit fixture with `./tools/dev p1-demo`. Use WASD/arrows to walk and **E** near the helm to enter/leave Piloting; directional input while piloting should show the unavailable-propellant reason and no ship motion. In the fixture, expect the labeled ship to translate once and hold while the beacon stays put, then repeat walking/bounds and helm checks at the translated origin. Native window opening, appearance, label readability, focus, keyboard behavior, and player-visible translation remain **NOT OBSERVED**. M1-G1.1 and M1-G1.2 remain unqualified; P4 owns native observation and closeout. P1–P3 remain uncommitted manual work, so the runner's Git-history resume contract still needs reconciliation before runner use. No self-commit or push was made.

## P4 applicability and bounded native repair (2026-11-08)

The P3 values and hashes above identify the source checked at P3; they remain historical evidence. P4 began on the same uncommitted `main` HEAD `4ec4b625b7948f02ba6df938263eea7e763dc579` with root version `0.1.3`. The first real fixture launch exposed a presentation failure: the `(-60, -20)` fixture offset placed the upper hull border across the title/mode, and the development label crossed the lower hull line. [The pre-repair frame](images/pre-repair-fixture-held.png) preserves that observation. The gameplay ownership, controls, and normal-play origin were retained.

The bounded repair changed the fixture offset to `(-60, 0)` in `Main.cs`, so the ship now moves from `(480, 300)` to `(420, 300)` while the beacon remains at `(930, 300)`. It moved and shortened the development label into the upper-right space in `main.tscn` and `Main.cs`; the native held frame now reads `DEV SPATIAL FIXTURE — translated ship held` without crossing the hull or title. `docs/development.md` was corrected to the new fixture coordinates. No P3 historical result was silently rewritten.

The final P4 gameplay source hashes are `main.tscn` SHA-256 `0a7d8876ba554d71571d68229c7898ba828beb24fe70562d2410266a24df768b` and `Main.cs` `57fa3e671f37fa7a9458451b84e21e1112ba3abd2924f712da216ade4d466814`. Unchanged `Ship.cs`, `Engineer.cs`, `Deck.cs`, `project.godot`, and `tools/dev` retain the hashes recorded above. After the repair, `./tools/dev check` passed import, a 0-warning/0-error C# build, both actual-main-scene smokes, scene automation, and expected missing-scene failure. The flagged smoke printed `SPACE_FACTORY_P1_DEMO_OK origin=(480, 300) held=(420, 300) landmark=(930, 300)` and then `SPACE_FACTORY_SMOKE_OK`. A final `./tools/dev p1-demo` native launch, repeated fixture interaction/corner route, and clean window close confirmed the readable layout. [Native results](native-playtest.md) and the [closeout](../closeout.md) own the resulting qualification.
