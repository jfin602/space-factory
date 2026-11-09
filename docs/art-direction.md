# Starter ship pixel art

**Status:** production direction for the first asset pack. This is presentation work for the accepted M1 scenario; it does not implement the M1-P2–P5 factory or flight rules.

The game uses a fixed, directly overhead 2D camera at zoom 1 in a 960 × 600 viewport. `Deck.InteriorBounds` is 720 × 420 world pixels, and its visible guide lines are 40 pixels apart. Use a 40 px art cell without changing simulation bounds or placement. The engineer fits inside a 32 × 32 canvas centered on the existing body. Machinery can span whole cells; the helm retains its current 70 × 42 visual area. Sprite pixels display at one world pixel at normal zoom, with nearest filtering and integer positions.

The ship should read as a compact work vessel: dark gunmetal frame, worn off-white access panels, muted steel, restrained copper and rust, and sparse safety orange. Cyan indicates power or display light; amber indicates a caution or warm working state. Light falls from the upper left. Use a dark 1–2 px silhouette edge, stepped highlights on upper and left faces, and darker lower and right faces. Wear belongs on edges and service panels, not as uniform noise. The floor is quieter and lower contrast than the engineer and machinery.

Use crisp, deliberate clusters and preserve each object's silhouette at 1×. Keep engines, exhaust, machines, and hull on separate transparent sprites. Keep working indicators small enough to avoid masking neighboring objects. Tile edges must match exactly. Directional engineer frames share a canvas, center pivot, proportions, and pack location; animation frames will use the same registration when walking animation is needed.

The current controller has no facing or walk animation, so one downward facing idle is the game integration target. Other directional idles and factory/propulsion states are prepared for preview or later gameplay wiring. The pack manifest and generation notes are in [starter-pack](art/starter-pack.md).
