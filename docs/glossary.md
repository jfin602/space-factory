# Glossary

| Term | Meaning in this project |
| --- | --- |
| Engineer | The single directly controlled player character. Their death ends the current run. |
| Run | One engineer's attempt to survive and progress, potentially containing many expeditions. Its intended duration is undecided. |
| Session | One period of playing the application. Under the proposed save-and-quit policy, several sessions can belong to the same run. |
| Expedition | A planned trip or mission undertaken during a run. Returning from one does not start a new run. |
| Ship | The persistent mobile vessel and its onboard systems, inventory, and factory. |
| Hull | The physical ship structure and footprint. Expansion and construction rules remain a working design. |
| Interior | The engineer-accessible space and machinery within the hull. |
| Exterior | The visible outside of the landed ship in relation to the surface and nearby structures. |
| Landable body | A planet, asteroid, or other sufficiently large object that supports the landing and surface-play rules. |
| Outpost | A persistent surface facility the engineer establishes and can later revisit. It may be a small temporary operation or an independent base. |
| Deposit | A location's remaining extractable resource supply. Finite depletion is a working design. |
| Inventory | Material currently owned by a specific container, machine, character, ship, or outpost. |
| Buffer | Storage between production or transfer stages that holds reserve or absorbs uneven throughput. |
| Throughput | The rate at which a connected system actually produces or transfers material under its current limits. |
| Reserve | Stored supply available to cover future demand or interruption. |
| Port | A physical ship interface. Personnel access and material, fluid, or power connections are proposed distinct types. |
| Airlock | A proposed controlled entrance for the engineer; detailed pressure simulation is not implied. |
| Docking connection | A local link between a landed ship and surface infrastructure. It ends when the ship departs. |
| Telemetry | Information received about a remote facility; a last known report may differ from its current state. |
| Breakdown | A stopped or damaged function with a recovery path still available. |
| Critical shortage | A recoverable deficit whose solution competes with a finite survival or operational reserve. |
| Stranded | Unable to depart or continue travel. Stranding may be recoverable or irreversible depending on actual resources and capabilities. |
| Terminal loss | An end to the current run, such as engineer death. It cannot be undone through an ordinary in-run respawn. |
| Phase | A coherent development milestone in the roadmap. |
| Gate | An observable acceptance boundary within a Phase. Passing requires evidence for its criteria. |
| Vertical slice | A small playable sequence demonstrating the connected experience across multiple systems. |
| Working design | A proposed behavior retained for implementation planning and testing, distinct from a confirmed owner requirement. |

See [the decision register](decisions-and-questions.md) for requirement status and [the documentation index](README.md) for the owning system documents.
