# Tutorial: restart the stranded ship

## Confirmed opening

Restarting a small stranded spaceship introduces the game through its actual factory, resources, and repair systems.

The engineer is alone; death permanently ends a run. The scoped M1 opening below selects a first-flight test arrangement. The fuller tutorial's location, damage, inventory balance, lesson order, and survival timer remain open. Being stranded does not imply a particular crash, planetary location, or enemy attack.

This opening should establish the promise described in [game design](game-design.md): the player builds the systems that make their ship capable of traveling and surviving.

## Accepted M1 opening

**Scope: First Factory-Powered Flight, accepted for implementation planning on 2026-11-08; gameplay is not yet implemented or qualified.** The [milestone plan](planning/p1/first-flight.md) gives the bounded scenario; the [roadmap](roadmap.md#milestone-m1-first-factory-powered-flight) owns Phase/Gate progress.

Start aboard one fixed ship in a simple space scene. The propellant tank is empty, the processor-to-tank pipe is incomplete, and a finite cargo supply contains ice and one spare pipe segment. The processor, tank, engine connection, and solar supply are installed. Machinery does not need a general damage/repair system for this first restoration task.

The player completes this sequence through nearby interactions:

1. Inspect the empty propulsion reserve and observe that a thrust request cannot accelerate the ship.
2. Retrieve ice from the crate and load it into the processor, with quantities transferred through the engineer's inventory.
3. Install the supplied pipe segment to complete the actual processor-to-tank connection.
4. Start the solar-powered processor and observe a timed recipe producing propellant and filling the tank.
5. Enter the helm and fly toward a visible beacon while production continues.
6. Leave the helm to tend the factory when needed, then resume piloting without resetting state.

Keep the next useful objective visible and derive its completion from world conditions. Recognize valid actions performed early; do not require a ceremonial click order or reset a working system. A full mission framework and alternate ship layouts are outside this milestone.

The recovery playtest stops processing, uses the stored reserve until powered acceleration is unavailable, then manufactures more propellant from remaining ice and regains thrust. Coasting continues according to the [M1 flight rules](systems/ship-and-navigation.md#accepted-m1-ship-and-flight-rules); zero fuel alone is not death.

An explicit **Restart playtest** action restores the defined fresh scenario for development. It is not an in-world rescue or engineer respawn, and it does not implement or qualify durable permanent-run failure. The broader permanent-death requirement remains in force for the later survival work.

## A solvable starting problem

Begin from a verifiably solvable state with finite, reachable recovery resources. M1 uses the installed solar supply to manufacture the first propellant without requiring propellant first. Other tutorial variants may use an available tool, repairable power source, or recoverable component; those methods remain undecided.

Avoid recipes requiring a machine that can only manufacture itself. Explain irreversible consumption before asking the player to spend scarce material. A solvable start does not guarantee success after every choice; destroying the remaining recovery path follows normal consequences.

No hidden resource refill or automatic rescue should repair a failed opening. Whether the first run has extra warnings, a relaxed timer, or optional guidance is an open teaching decision. Restarting after a loss begins a new run; it does not revive the dead engineer.

## Suggested fuller tutorial sequence

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

The accepted M1 scope is recorded in [decisions and questions](decisions-and-questions.md). Record later opening, recipe, prompt, and guidance choices there before treating them as settled beyond this prototype.
