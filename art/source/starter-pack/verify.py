"""Focused native-pixel checks for the exported M1 pack."""

from pathlib import Path
from PIL import Image

ROOT = Path(__file__).resolve().parents[3]
ART = ROOT / "game/assets/pixel"

EXPECTED = {
    "engineer/engineer_idle_down.png": (32, 32),
    "ship/deck_tile.png": (40, 40),
    "ship/hull_edge.png": (40, 40),
    "ship/hull_corner.png": (40, 40),
    "ship/helm.png": (80, 48),
    "factory/cargo_crate.png": (80, 40),
    "factory/processor_idle.png": (80, 80),
    "factory/processor_active.png": (80, 80),
    "factory/solar_panel.png": (80, 40),
    "factory/propellant_tank.png": (80, 80),
    "factory/pipe_gap.png": (40, 40),
    "factory/pipe_connected.png": (40, 40),
    "ship/engine.png": (80, 80),
    "effects/exhaust_01.png": (40, 80),
    "effects/exhaust_02.png": (40, 80),
    "factory/ice_icon.png": (24, 24),
    "factory/propellant_icon.png": (24, 24),
}

for name, size in EXPECTED.items():
    image = Image.open(ART / name).convert("RGBA")
    assert image.size == size, (name, image.size)
    alpha = image.getchannel("A")
    assert alpha.getbbox(), f"blank sprite: {name}"
    assert set(alpha.getdata()) <= {0, 255}, f"soft alpha: {name}"
    if name != "ship/deck_tile.png" and name not in {"factory/pipe_connected.png", "factory/pipe_gap.png"}:
        assert image.getpixel((0, 0))[3] == 0, f"clipped corner: {name}"

tile = Image.open(ART / "ship/deck_tile.png").convert("RGBA")
for yy in range(40):
    assert tile.getpixel((0, yy)) == tile.getpixel((39, yy)), "deck x seam"
for xx in range(40):
    assert tile.getpixel((xx, 0)) == tile.getpixel((xx, 39)), "deck y seam"

for name in ("ship/hull_edge.png", "factory/pipe_connected.png"):
    image = Image.open(ART / name).convert("RGBA")
    for yy in range(40):
        assert image.getpixel((0, yy)) == image.getpixel((39, yy)), f"join seam: {name} y={yy}"

for first, second in (("factory/processor_idle.png", "factory/processor_active.png"),
                      ("effects/exhaust_01.png", "effects/exhaust_02.png")):
    assert Image.open(ART / first).getchannel("A").tobytes() == Image.open(ART / second).getchannel("A").tobytes(), f"frame registration: {first}"

print(f"ART_VERIFY_OK {len(EXPECTED)} native PNGs; hard alpha; deck/connector seams; registered frames")
