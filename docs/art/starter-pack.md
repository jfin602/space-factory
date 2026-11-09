# M1 starter asset pack

**Source inspection:** `main.tscn`, `Deck.cs`, `Engineer.cs`, `Ship.cs`, and `Main.cs` at `f274c89630a6033ccd79ad98b7fee6369dd5778a`; clean `main` working tree before this task. M1-P1 is the current playable state. M1-P2–P5 and their factory/flight rules are planned. Camera zoom is 1; visible deck grid is 40 px. No prior raster asset or import convention exists.

Final PNGs live under `game/assets/pixel/`. Unscaled generated source artwork lives under `art/source/starter-pack/`. The independent visual assembly is `game/scenes/asset_preview.tscn`. Each filename below is relative to `game/assets/pixel/`. Dimensions are native pixels. Center pivots are at the canvas center unless noted; deck tile origin is its top left. `P` means generated and preview only; `G` means generated and connected to current game. These statuses describe art wiring, not gameplay readiness.

| Asset | Intended use | File / native size | Art-cell footprint | States / anchor / tiling | Status |
| --- | --- | --- | --- | --- | --- |
| Engineer | Current walking character | `engineer/engineer_idle_down.png` 32×32 | within 1×1 | idle, center; no tiling | G |
| Deck | Quiet repeating interior floor | `ship/deck_tile.png` 40×40 | 1×1 | idle, top-left; seamless x/y | G |
| Hull | Ship edge and corner vocabulary | `ship/hull_{edge,corner}.png` 40×40 | 1×1 | idle, center; edge joins | P |
| Helm | Current interaction point | `ship/helm.png` 80×48 | 2×1 visual | idle, center; no tiling | G |
| Cargo crate | M1 finite ice storage | `factory/cargo_crate.png` 80×40 | 2×1 | idle, center; no tiling | P |
| Processor | M1 ice-to-propellant machine | `factory/processor_idle.png`, `factory/processor_active.png` 80×80 | 2×2 | idle/working, center; no tiling | P |
| Solar supply | M1 installed startup power | `factory/solar_panel.png` 80×40 | 2×1 | idle, center; no tiling | P |
| Tank | M1 bounded propellant storage | `factory/propellant_tank.png` 80×80 | 2×2 | idle, center; no tiling | P |
| Pipe | M1 single missing socket and installed connection | `factory/pipe_gap.png`, `factory/pipe_connected.png` 40×40 | 1×1 | gap/connected, center; joins horizontally | P |
| Engine | M1 installed propulsion | `ship/engine.png` 80×80 | 2×2 | idle, center; no tiling | P |
| Exhaust | Actual-thrust visual for M1-P4 | `effects/exhaust_01.png`, `effects/exhaust_02.png` 40×80 | 1×2 visual | two registered frames, center; no tiling | P |
| Ice / propellant | M1 resource cues | `factory/ice_icon.png`, `factory/propellant_icon.png` 24×24 | UI only | idle, center; no tiling | P |

No walking animation is required by the current controller. No arbitrary machine placement, exterior whole-ship sprite, terrain, combat, or expanded resource library is part of this pack. The existing hull polygon remains the structural game boundary; hull art in the preview establishes a modular vocabulary for later replacement.

## Generation relationships

The built-in image generation tool produced the source images. The representative engineer, processor, and deck established the palette, followed by the remaining objects with those source images as style references. The exact subject prompts, reference chain, and deterministic native export are in [prompts.md](../../art/source/starter-pack/prompts.md) and [export.py](../../art/source/starter-pack/export.py).

Godot uses nearest canvas-item texture filtering in the main and preview scenes. Imported PNGs use lossless mode and no mipmaps. The rendered [preview screenshot](images/preview-godot.png), [2× integer enlargement](images/preview-godot-2x.png), and [main-scene screenshot](images/main-godot.png) show the exported sprites in Godot 4.7.2 at the actual 960×600 viewport. Factory and propulsion objects remain preview-only until their state owners and interactions exist.

## Verification on 2026-11-08

- `./tools/dev doctor`: Godot 4.7.2 .NET, .NET 10.0.403, and a native Linux display available.
- `./tools/dev check`: PASS after the scene and script integration; imported textures, zero-warning C# build, ordinary and spatial-fixture smokes, and saved-scene automation.
- `./tools/dev inspect-scene scenes/asset_preview.tscn`: PASS; all exported sprites instantiated at their native dimensions and intended relative positions.
- `python3 art/source/starter-pack/verify.py`: PASS for all 17 PNG dimensions, hard alpha, deck and connector edge equality, and identical alpha registration across active frames.
- Native Godot OpenGL captures of the actual preview and main scenes were inspected at 1×; the preview was also inspected at 2× nearest scale. The engineer and machines separate from the subdued floor; edges, alpha, and canvas bounds are visually clean. The active processor's brighter chamber and the two exhaust brightness frames remain registered. The preview shows the gap and connected pipe as separate alternatives.

These are art and static-scene observations. The existing P1 movement/control smokes passed, but this task did not repeat a manual input playtest or implement the M1 factory, power, fuel, or thrust logic. The engine body and exhaust are deliberately separate; the active exhaust must later be driven by actual applied thrust.
