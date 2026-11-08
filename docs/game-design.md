# Game design

## Status and scope

This document organizes the initial design. Confirmed requirements are listed in [decisions and open questions](decisions-and-questions.md); the detailed mechanics and examples below are working designs unless explicitly identified as confirmed. No system is implemented yet.

## Confirmed core

The player directly controls one engineer in a 2D, top-down game. A factory inside a mobile spaceship supports its operation, mission planning, and exploration. The opening is a small stranded ship that the engineer restores as the tutorial.

The ship can land on planets, asteroids, and other large objects. Some destinations have hostile inhabitants, making scouting, preparation, and fighting relevant. The landed ship is visible from outside, with multiple access ports possible as its size increases. Surface factories can connect to it, remain in place, and supply it again on later visits.

The engineer has no respawn within a run. Engineer death ends the run; catastrophic ship damage and irreversible resource stranding can cause that death. Exact rules distinguish repairable incidents from unsurvivable ones.

## Connected gameplay loops

### Immediate engineering loop

Inspect a system, identify what it needs, gather or reclaim available material, build or change a connection, and observe the result. Successful changes must affect a real capability: a machine begins processing, reserves replenish, a defensive system operates, or propulsion becomes available.

### Expedition loop

1. Discover or select an opportunity.
2. Scout what can be learned about the route and destination.
3. Prepare the ship, supplies, equipment, and reserves.
4. Travel while production and resource consumption continue under the selected time rules.
5. Land or carry out the mission, adapting to encountered conditions.
6. Recover resources, equipment, knowledge, or another mission reward.
7. Return to a known facility or continue to another viable destination.
8. Improve the ship and its support network for the next expedition.

### Outpost loop

Choose a site, secure a working area, establish extraction or production, connect to the ship, and load useful supplies. Develop independent power, storage, and protection where long-term operation is worthwhile. Leave, travel elsewhere, and revisit the same facility to collect output, repair it, or expand it.

An outpost can remain temporary. Establishing a fully independent base is an investment decision, not a mandatory outcome of every landing.

## What the player controls

Direct engineer control is confirmed. Candidate actions include walking, inspecting, gathering accessible salvage, placing machines, connecting logistics, repairing, interacting with ship systems, and fighting hostile creatures.

The working navigation approach is to issue destination and travel-priority orders while continuing engineering work. Manual piloting, exact movement physics, and tactical ship control remain open. Avoid building an independent flight game before those choices are resolved.

The proposed presentation has three connected contexts: ship interior, landed surface with the exterior hull, and navigation/scouting information. They describe the same ship and world state. Changing view must not substitute a new inventory or reset a location.

## Meaningful engineering decisions

| Decision | Intended consequence |
| --- | --- |
| Carry supplies or manufacture them underway | Storage gives immediate reserve; machinery gives replenishment when inputs and power are available. |
| Expand the ship or improve its current layout | More room permits more equipment; expansion introduces proposed costs and support demands that need balancing. |
| Spend material on upgrades or keep repair reserves | Increased capability competes with preparedness for damage. |
| Travel faster or preserve supply margin | Candidate engine modes change fuel use, available preparation time, and arrival conditions. |
| Build a general-purpose ship or specialize | An efficient mission configuration may have less flexibility when conditions change. |
| Rely on an outpost or carry independence | A known supply stop frees onboard space but introduces dependence on its continued operation. |
| Land near resources or farther from threats | Convenient extraction can compete with a defensible site and a safe departure. |

Ship mass, cooling, movement costs, and exact capacity limits are candidate mechanisms for these choices, not established formulas.

## Candidate mission families

| Mission | Factory and preparation demands | Possible reward |
| --- | --- | --- |
| Resource expedition | Endurance, collection capacity, processing, cargo space, departure fuel | Material needed to sustain or expand the ship. |
| Salvage operation | Recovery equipment, repair components, available storage | A useful machine, components, or a blueprint. |
| Scientific investigation | Scanning capability and sustained power; environmental preparation | New locations, information, or technology. |
| Delivery | Manufacture or carry a requested payload while preserving survival reserves | Trade supplies, access, or another defined reward. |
| Rescue or assistance | Capacity and equipment appropriate to the scenario | Mission progression or resources; detailed passenger systems are unresolved. |
| Outpost establishment or recovery | Construction supplies, local power, defensive capability, repair parts | A new supply stop or restored route. |

These are options for content development. The existence of missions is confirmed; this list does not commit the project to every mission type or a crew-management system.

## Progression

The intended capability progression is from restoring a small ship to supporting longer, more demanding expeditions and a useful outpost network.

Candidate progression methods include better layouts, added hull space, improved machines, recovered equipment, new recipes, larger reserves, and stronger supply facilities. A new machine should change what the player can build or attempt, while exposing understandable requirements.

Randomized destinations, deposits, hazards, and equipment can produce different runs. Procedural generation scope and cross-run unlocks are still open. Permanent death is confirmed independently of those implementation choices.

## Survival and recovery

An ordinary breakdown, a critical shortage, and a terminal failure are different states. Running out of processed fuel is not proof that recovery is impossible: raw inputs, stored energy, reachable resources, and reclaimable equipment may still matter.

A recovery must use resources and capabilities that exist in the simulation. Repeated free rescue or an unbounded emergency supply would defeat the requested possibility of permanent stranding. The precise life-support model and loss triggers are specified as working designs in [survival and runs](systems/survival-and-runs.md).

Reliable automation should reduce routine demands on the player. Major new pressure should come from understandable hazards, damaged dependencies, depletion, and chosen ambitions.

## First playable scope

Separate the earliest factory-and-departure prototype from the first integrated slice of the full concept. The early prototype proves that an engineer can restore a ship through a production system. The integrated slice must also demonstrate landing, exterior access, a connected surface factory, a relevant threat, leaving the site, revisiting persistent supplies, and a genuine terminal loss path.

Use a small amount of content to prove those relationships. Broad procedural content, elaborate research trees, advanced automation, and a large mission catalog can follow when the loop is enjoyable and understandable. The [roadmap](roadmap.md) owns the detailed sequence and completion criteria.
