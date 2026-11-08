# Survival and runs

## Confirmed stakes

The player is one engineer. There is no respawning within a run. The ship can be permanently lost in a crash, or its resource situation can become irrecoverable, leaving the engineer stranded until death. These are genuine lose states, not temporary setbacks followed by a free replacement ship.

These stakes apply to exploration, landings, and possible hostiles. See [game design](../game-design.md) and [decisions and questions](../decisions-and-questions.md).

“Roguelike features” currently confirms permanent failure. It does not yet settle procedural generation, run duration, a victory condition, starting variation, persistent unlocks, or the fate of outposts between runs.

## Distinguish trouble from death

These recommended categories describe situations, not required implementation states.

| Situation | Meaning | Expected response |
| --- | --- | --- |
| Operational | The ship supports its current activity. | Continue, improve the factory, or choose a new objective. |
| Breakdown | A capability has failed, with a physically available recovery path. | Diagnose and repair using current resources or reachable opportunities. |
| Critical shortage | A finite reserve constrains the remaining recovery window. | Prioritize systems, sacrifice equipment, change plans, or accept the consequences. |
| Terminal loss | The engineer is dead or the ship has suffered an explicitly unsurvivable event. | End the run permanently. |

Zero propellant alone is not proof of death. There may be raw material aboard, accessible surface production, or equipment that can be dismantled. Equally, a resource icon existing somewhere on the map does not make it reachable. Recovery must satisfy the actual requirements for access, extraction, processing, transport, and survival.

Do not declare recovery impossible merely because one meter reaches zero. The damage model must distinguish repairable collisions from unsurvivable crashes; exact thresholds remain unapproved.

## Irrecoverable stranding

A proposed life-support model consumes a finite survival reserve during recovery attempts. Without successful recovery, supplies eventually run out. Oxygen, suit reserves, food, and thermal survival are possible implementations, not confirmed requirements.

Whichever model is chosen must support the owner's intended outcome: truly exhausted resources can mean permanent stranding and death. It must also explain why survival ends. Do not silently add resources, teleport the ship, spawn a guaranteed rescue, or replenish depleted sites to rescue a failed run.

A voluntary end-run action or time acceleration could avoid an empty wait. Both remain proposals and must not force premature loss while recovery remains possible.

## Legible danger

Before a voyage, show reserves, expected demand, known accessible supplies, and uncertainty. During shortages, explain causes and consequences: for example, power diversion stopped processing, so fuel production no longer covers engine demand.

Warnings should escalate with evidence. Survival forecasts must acknowledge variable consumption. Prioritizing essential systems can buy time only through reduced real consumption, not hidden immunity.

Potential hostiles do not prescribe combat mechanics. Hazards need information appropriate to the eventual difficulty. Record chosen warning, damage, and repair rules in [validation](../validation.md).

## Run persistence: recommended policy

Save-and-quit should preserve a living run so a player can stop playing without abandoning it. This is a recommendation, not an approved save specification. Permadeath should survive normal reloads; closing the application after a recorded death should not restore the engineer.

A software crash, device interruption, or failed save is different from a spaceship crash inside the simulation. Application failure should not itself be treated as an in-world death. Recovery should restore a consistent committed state with matching inventories, world objects, production jobs, and survival status. Avoid applying elapsed time or consuming supplies twice after recovery.

The durability format, save timing, pause behavior, offline progression, and policy for corrupted saves need explicit decisions. Persistent surface factories must survive revisits during a living run. Whether a later run shares those factories remains open; do not assume that world persistence grants an inheritance after death.

## Protect the value of learning

Long factory-building investment and permanent loss create a deliberate tension. Run length and rebuilding pace should be tested together. Potential non-power rewards include a voyage record and player-created blueprints, but both remain proposals. Blueprints would still require the new engineer to obtain materials and build equipment normally.

Candidate acceptance scenarios:

1. An empty fuel tank with usable raw material aboard permits an actual recovery attempt.
2. A truly exhausted survival reserve kills the engineer and remains terminal after reload.
3. A repairable collision and an unsurvivable crash produce different, understandable outcomes.
4. An application interruption restores consistent state without manufacturing a death, extra supplies, or duplicated production.
5. Revisiting an outpost preserves its actual state; starting another run follows an explicitly selected inheritance policy.

The [tutorial](../tutorial.md) introduces recovery using these same rules. It should teach the stakes before the player depends on assumptions the game has never explained.
