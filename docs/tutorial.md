# Tutorial: restart the stranded ship

## Confirmed opening

Restarting a small stranded spaceship introduces the game through its actual factory, resources, and repair systems.

The engineer is alone; death permanently ends a run. Location, damaged equipment, inventory, lesson order, and survival timer remain open. Being stranded does not imply a particular crash, planetary location, or enemy attack.

This opening should establish the promise described in [game design](game-design.md): the player builds the systems that make their ship capable of traveling and surviving.

## A solvable starting problem

Begin from a verifiably solvable state with finite, reachable recovery resources. The first machine needs a bootstrap path: an available tool, repairable power source, or recoverable component. The exact method remains undecided.

Avoid recipes requiring a machine that can only manufacture itself. Explain irreversible consumption before asking the player to spend scarce material. A solvable start does not guarantee success after every choice; destroying the remaining recovery path follows normal consequences.

No hidden resource refill or automatic rescue should repair a failed opening. Whether the first run has extra warnings, a relaxed timer, or optional guidance is an open teaching decision. Restarting after a loss begins a new run; it does not revive the dead engineer.

## Suggested playable sequence

| Step | Player activity | What it teaches |
| --- | --- | --- |
| Inspect | Move through the ship and examine a disabled system. | Character movement, interaction, and the difference between damage and missing supply. |
| Diagnose | Read a short cause-and-effect explanation for why the ship cannot depart. | The ship's operation depends on connected systems. |
| Recover | Gather an available item or dismantle an explicitly identified damaged object. | Finite inventory, salvage, and the cost of sacrificing equipment. |
| Restore power | Repair or reconnect the starting power source. | Machines need a working supply, and connections matter. |
| Build a first chain | Connect storage, processing, and an output destination. | Inputs become useful products through observable production. |
| Prepare propulsion | Produce and route the material or components needed by the engine. | Factory output enables a concrete ship capability. |
| Depart | Inspect the relevant reserves and choose a reachable destination. | Navigation is a commitment supported by the factory. |

These candidate lessons should advance on meaningful world conditions. Recognize already-repaired systems and valid alternative layouts. Never confiscate materials or reset working machines to enforce the expected click sequence.

Departure makes the accomplishment visible: the engine operates, the ship travels, and the factory continues under the selected simulation policy.

## Teach diagnosis without overwhelming the player

Introduce only the systems needed for the current repair. A damaged engine could expose a missing component first, then reveal its normal fuel demand after repair. The interface should distinguish “broken,” “unpowered,” “missing input,” and “output blocked” rather than treating them as the same failure.

Use a small number of visible resource movements to teach accounting. Moving goods between storage and a machine must reduce one inventory and increase the other. Canceling, dismantling, and reconstructing equipment must follow the same rules described in [factory and resources](systems/factory-and-resources.md); the tutorial must not teach a duplication exploit as a recovery technique.

The player should understand why a reserve matters before the first serious commitment. A guided observation of a draining tank or insufficient production rate can teach this without requiring a scripted death.

## Failure and continuation

A stopped engine is an invitation to diagnose. An actually dead engineer is a terminal result. Follow [survival and runs](systems/survival-and-runs.md) rather than assuming that any empty resource meter ends the game immediately.

Teach the player to inspect existing stock, reachable resources, and the consequences of repurposing equipment. These options must be finite and real. When a tutorial run becomes irrecoverable, the loss explanation should identify what failed and the preceding dependency, without inventing a rescue.

A later lesson could introduce a landing and a surface line loading through a ship port. When exterior play begins remains open. See [landings and outposts](systems/landings-and-outposts.md) and [ship and navigation](systems/ship-and-navigation.md).

## Acceptance scenarios

Use these as candidate requirements for [validation](validation.md), not as claims that a prototype already exists:

1. A fresh starting state contains a complete legal path to restored propulsion without resource injection.
2. An alternate valid layout completes the relevant lesson when the system works.
3. A misplaced item can be recovered when the normal rules permit; committed consumption is not silently refunded.
4. A blocked or unpowered machine explains its actual condition.
5. The player can connect the first departure to products they manufactured.
6. Tutorial failure respects permanent death and does not confuse application interruption with an in-world crash.

Record final opening location, recipes, prompts, and guidance choices in [decisions and questions](decisions-and-questions.md) before treating them as settled design.
