# Vision

## The game

Space Factory is a 2D, top-down survival and automation game. The player directly controls a single engineer aboard a spaceship whose internal factories keep it operational. The engineer repairs, builds, explores, plans missions, lands on other bodies, and establishes surface facilities that supply the ship on future visits.

The run begins aboard a small stranded ship. Restoring it is the tutorial. Engineer death permanently ends the run, including death caused by catastrophic ship damage or irrecoverable resource exhaustion and stranding. Exact crash-survival and terminal rules remain open.

The ship is the player's mobile home and working machine. Its factory determines what expeditions it can support. Surface outposts extend that capability across space without removing the need to operate and protect the ship.

These foundations are confirmed requirements. Their provenance and the status of proposed details are recorded in [decisions and open questions](decisions-and-questions.md).

## Player fantasy

Start with a vessel that barely works. Learn how its parts depend on one another, restore its propulsion, and gradually make it capable of journeys that initially seemed impossible.

The player should recognize their own history in the ship and surrounding world: a cramped early processing line, a recovered machine that changed its layout, a new engineering section, the first asteroid facility, and the defended planet that became a dependable supply stop.

The player acts as both engineer and expedition planner. Building is connected to an intended outcome: reaching a destination, surviving a hazardous landing, carrying a useful payload, or making a return trip possible.

## Design priorities

The following are working design principles for realizing that fantasy.

### 1. Capability comes from a functioning factory

Major ship actions should depend on resources, production, storage, and connected equipment. An engine upgrade creates a useful capability only when the ship can support its requirements. Systems should expose why they are operating, limited, or stopped.

### 2. Preparation changes the outcome

Scouting, route selection, reserves, defensive supplies, and landing placement should affect what happens. A risky expedition may be worth attempting, but the game should communicate known constraints and uncertainty well enough for the risk to be understood.

### 3. Engineering can solve routine problems

A reliable supply line should remain reliable under the conditions it was designed for. New destinations and equipment introduce new demands. Avoid replacing progress with constant arbitrary failures that require the same manual chore forever.

### 4. The ship and its outposts form one connected economy

The ship carries essential capability with it. Surface factories offer more space, extraction, processing, and stockpiles. Physical visits and connections move resources between them. Dependence on an outpost is useful, but its exhaustion or failure can change the viability of a route.

### 5. Failure has understandable causes

Permanent loss is part of the game. Players should be able to identify the chain of decisions and system failures that caused it. A stalled engine may still be repairable; the game should allow resourceful recovery while a valid option remains.

### 6. Personal scale remains visible

The engineer walks through the machine they built, leaves it through an entrance, and works around its landed exterior. Larger production and supply networks should remain connected to places and equipment the player can understand.

## Intended experience

The early mood is vulnerability and discovery: identify a broken dependency, find a finite source of materials, and restore an essential function. Successful departure establishes the connection between factory work and movement.

The middle experience is capability and commitment: redesign the ship, select a mission, land prepared, construct a facility, and decide what to leave operating while away.

The longer-term experience is managing ambition and dependence. A better ship and several reliable outposts allow longer journeys, but an expedition can still exceed what the system can support.

Run duration, ultimate objective, and the balance between open-ended exploration and a defined destination remain open. A run may contain many expeditions; those terms are not interchangeable.

## Example player story

The engineer restores a damaged starter ship and reaches an accessible asteroid. A small extraction facility helps fund an expansion. Later, a scouting report identifies a richer but inhabited world. The engineer manufactures equipment and ammunition, chooses a defensible landing site, and establishes a second outpost.

During a later journey, an old supply stop reports a fault. The ship may carry enough reserve to divert, enough components to repair the outpost, or too little of either. Its preparation and factory design determine the available choices.

This is an illustrative sequence, not a scripted campaign or a guarantee of rescue.

## Scope boundaries

The core is single-engineer factory survival, travel, landings, and persistent outposts. Crew management, multiplayer, detailed orbital physics, multiple playable characters, and a broad faction economy have not been selected as requirements. Ship-to-ship combat is also unresolved; hostile surface inhabitants are confirmed.

The first playable work should prove a small version of the connected loop before expanding content or simulation detail. See [game design](game-design.md), [tutorial](tutorial.md), and [roadmap](roadmap.md).
