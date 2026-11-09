"""Export generated source art to registered native-size Godot sprites.

Run from the repository root with python3 art/source/starter-pack/export.py.
The source images are retained beside this script; the output is deterministic.
"""

from pathlib import Path
from PIL import Image

ROOT = Path(__file__).resolve().parents[3]
SOURCE = Path(__file__).resolve().parent
OUT = ROOT / "game/assets/pixel"

# source name: (output relative path, native canvas, maximum occupied area)
ASSETS = {
    "engineer_source.png": ("engineer/engineer_idle_down.png", (32, 32), (27, 29)),
    "processor_source.png": ("factory/processor_idle.png", (80, 80), (74, 74)),
    "helm_source.png": ("ship/helm.png", (80, 48), (74, 42)),
    "cargo_source.png": ("factory/cargo_crate.png", (80, 40), (74, 35)),
    "solar_source.png": ("factory/solar_panel.png", (80, 40), (74, 35)),
    "tank_source.png": ("factory/propellant_tank.png", (80, 80), (74, 74)),
    "engine_source.png": ("ship/engine.png", (80, 80), (74, 74)),
    "hull_edge_source.png": ("ship/hull_edge.png", (40, 40), (38, 18)),
    "hull_corner_source.png": ("ship/hull_corner.png", (40, 40), (38, 38)),
    "pipe_source.png": ("factory/pipe_connected.png", (40, 40), (40, 22)),
    "exhaust_source.png": ("effects/exhaust_01.png", (40, 80), (34, 72)),
    "ice_source.png": ("factory/ice_icon.png", (24, 24), (21, 21)),
    "propellant_source.png": ("factory/propellant_icon.png", (24, 24), (21, 21)),
}


def save(image, relative):
    target = OUT / relative
    target.parent.mkdir(parents=True, exist_ok=True)
    image.save(target)


def native(source, size, occupied):
    image = Image.open(SOURCE / source).convert("RGBA")
    alpha = image.getchannel("A").point(lambda value: 255 if value >= 96 else 0)
    bounds = alpha.getbbox()
    if not bounds:
        raise ValueError(f"empty source: {source}")
    image = image.crop(bounds)
    scale = min(occupied[0] / image.width, occupied[1] / image.height)
    scaled = (max(1, round(image.width * scale)), max(1, round(image.height * scale)))
    if source == "engineer_source.png":
        # The generated top-down suit is tall; give its shoulders enough width
        # to read beside 40 px deck cells at the game's fixed 1× camera.
        scaled = (24, 29)
    # Generated source has oversized pixel clusters. BOX reduction keeps their
    # coverage, and the final alpha threshold restores hard sprite edges.
    image = image.resize(scaled, Image.Resampling.BOX)
    alpha = image.getchannel("A").point(lambda value: 255 if value >= 128 else 0)
    image.putalpha(alpha)
    canvas = Image.new("RGBA", size)
    canvas.alpha_composite(image, ((size[0] - scaled[0]) // 2, (size[1] - scaled[1]) // 2))
    return canvas


for source, (relative, size, occupied) in ASSETS.items():
    save(native(source, size, occupied), relative)

# Join the generated structural vocabulary on the same 40 px baseline. The
# source edge has a one-pixel transparent margin and sits lower than the
# generated corner, so register it to the corner's upper arm and bridge the
# corner into the exact edge-column colors.
edge = Image.open(OUT / "ship/hull_edge.png").convert("RGBA")
shifted = Image.new("RGBA", (40, 40))
shifted.alpha_composite(edge, (0, -8))
for yy in range(8, 16):
    shifted.putpixel((0, yy), shifted.getpixel((1, yy)))
    shifted.putpixel((39, yy), shifted.getpixel((0, yy)))
save(shifted, "ship/hull_edge.png")
corner = Image.open(OUT / "ship/hull_corner.png").convert("RGBA")
for yy in range(8, 16):
    for xx in range(15, 40):
        if corner.getpixel((xx, yy))[3] == 0:
            corner.putpixel((xx, yy), shifted.getpixel((0, yy)))
    corner.putpixel((39, yy), shifted.getpixel((0, yy)))
save(corner, "ship/hull_corner.png")

# Quiet tile made from the generated floor plate. Reserve a uniform two-pixel
# perimeter so opposite edges match exactly in both directions.
floor = Image.open(SOURCE / "deck_source.png").convert("RGB")
side = min(floor.size)
x = (floor.width - side) // 2
y = (floor.height - side) // 2
floor = floor.crop((x, y, x + side, y + side)).resize((36, 36), Image.Resampling.BOX)
floor = Image.blend(Image.new("RGB", (36, 36), (33, 39, 47)), floor, 0.24)
tile = Image.new("RGB", (40, 40), (33, 39, 47))
tile.paste(floor.crop((2, 2, 34, 34)), (4, 4))
save(tile.convert("RGBA"), "ship/deck_tile.png")

# Working frame is color-only: exact processor registration is retained.
idle = Image.open(OUT / "factory/processor_idle.png").convert("RGBA")
active = idle.copy()
pixels = active.load()
for yy in range(active.height):
    for xx in range(active.width):
        r, g, b, a = pixels[xx, yy]
        if a and b > r * 1.25 and b > g * 0.95 and g > r * 1.05:
            pixels[xx, yy] = (min(255, r + 30), min(255, g + 58), min(255, b + 40), a)
save(active, "factory/processor_active.png")

# The one missing connection is a pair of the generated pipe's end stubs.
pipe = Image.open(OUT / "factory/pipe_connected.png").convert("RGBA")
for yy in range(pipe.height):
    if pipe.getpixel((0, yy))[3] or pipe.getpixel((39, yy))[3]:
        pipe.putpixel((39, yy), pipe.getpixel((0, yy)))
save(pipe, "factory/pipe_connected.png")
gap = pipe.copy()
gap.paste((0, 0, 0, 0), (15, 0, 25, 40))
save(gap, "factory/pipe_gap.png")

# A second exhaust frame changes brightness without changing registration.
exhaust = Image.open(OUT / "effects/exhaust_01.png").convert("RGBA")
bright = exhaust.copy()
px = bright.load()
for yy in range(bright.height):
    for xx in range(bright.width):
        r, g, b, a = px[xx, yy]
        if a:
            px[xx, yy] = (min(255, int(r * 1.06 + 8)), min(255, int(g * 1.06 + 8)), min(255, int(b * 1.04 + 6)), a)
save(bright, "effects/exhaust_02.png")
