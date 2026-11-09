# Starter-pack generation record

Generated with the built-in `image_gen` tool on 2026-11-08. The original tool outputs are copied here as `*_source.png`; `export.py` produces the native PNGs used by Godot. Do not generate over these sources when extending the pack.

To reproduce the native exports, install Pillow for Python 3, then run `python3 art/source/starter-pack/export.py` and `python3 art/source/starter-pack/verify.py` from the repository root.

## Reference chain

1. `engineer_source.png` established the off-white suit, copper pack, dark frame, orange and cyan accents, stepped shading, and upper-left light. Its prompt asked for one isolated, downward-facing overhead engineer, strong silhouette for 32×32, genuine transparent alpha, and no floor/text/checkerboard.
2. `processor_source.png` used the engineer as a **style reference only**. Its prompt asked for one overhead ice-to-propellant processor with left intake, right outlet, central chamber, 80×80 readability, transparent alpha, and the same palette and lighting.
3. `deck_source.png` used engineer and processor as **style references only**. Its prompt asked for one quiet overhead 40×40 repeatable steel deck plate, inner access panel, low contrast, opaque square, and matching opposite edges. The generated square itself was not seamless; `export.py` corrects its edges.
4. Every later source used the engineer, processor, and deck as **style references only**. No reference subject should be copied into another sprite. The pipe, exhaust, and icons used processor and engine source images as style references.

## Reusable prompt prefix

> Use case: stylized-concept. Asset type: original overhead pixel-art sprite source for Space Factory, designed for a 40 px construction art grid. Input images are style references only. Match dark gunmetal, worn off-white, muted copper, small safety orange and cyan/amber palette, intentional hard pixel clusters, upper-left light, dark lower-right shade. Directly overhead orthographic. ONE isolated object centered with padding on genuine transparent alpha; no floor, shadow outside the silhouette, text, logo, checkerboard, or soft gradients. Maintain a strong silhouette at the stated native size.

| Source file | Subject clause appended to the prefix | Final export |
| --- | --- | --- |
| `helm_source.png` | Compact wide industrial control desk, off-white cowl, gunmetal base, central cyan display, two orange guards; 80×48; interaction point, no chair. | `ship/helm.png` |
| `cargo_source.png` | Reinforced finite-ice crate with off-white hinged lid, gunmetal ribs, copper latch, small cyan ice pictogram; 80×40. | `factory/cargo_crate.png` |
| `solar_source.png` | Low-profile horizontal dark-blue photovoltaic array, worn gunmetal frame, copper coupler, tiny amber lamp; 80×40. | `factory/solar_panel.png` |
| `tank_source.png` | Round pressure vessel in 2×2 gunmetal frame, off-white service plates, left/right copper couplers, cyan level window, orange warning; 80×80. | `factory/propellant_tank.png` |
| `engine_source.png` | Heavy propulsion engine body with copper feed at top and round nozzle at bottom, hazard stripes; 80×80; **no flame**. | `ship/engine.png` |
| `hull_edge_source.png` | Straight horizontal hull wall strip with gunmetal casing, off-white armor lip, bolts, orange stripe; joins left/right in a 40×40 canvas. | `ship/hull_edge.png` |
| `hull_corner_source.png` | Ninety-degree hull wall corner turning from top horizontal to left vertical, same material vocabulary; 40×40. | `ship/hull_corner.png` |
| `pipe_source.png` | Straight copper pipe between exact left/right edges with gunmetal couplers and off-white central valve; 40×40. | `factory/pipe_connected.png`, `factory/pipe_gap.png` |
| `exhaust_source.png` | Separate downward cyan-white hot-core thruster plume with restrained orange tip; 40×80; **no engine body**. | `effects/exhaust_01.png`, `effects/exhaust_02.png` |
| `ice_source.png` | Angular pale-cyan ice chunk with dark rim/shadow and one white facet; 24×24. | `factory/ice_icon.png` |
| `propellant_source.png` | Compact sealed fuel canister with gunmetal case, copper cap, cyan contents window; 24×24. | `factory/propellant_icon.png` |

`processor_active.png` and `exhaust_02.png` are registered color-state exports of their generated idle/first frame; `pipe_gap.png` removes the single center segment from the generated connected pipe. The source originals remain separate from all final sprites. `export.py` fixes alpha to hard edges, centers each sprite in its native canvas, darkens the floor, and registers the hull join. This postprocessing is intentional; use the original sources for new variants instead of repeatedly resizing existing final PNGs.
