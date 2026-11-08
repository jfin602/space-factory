# Development setup

This is a Godot 4.7.2 .NET and C# desktop sandbox using the Compatibility renderer. The game project is in `game/`; the command entry point is `tools/dev`; generated logs and exports are in ignored `artifacts/`. Gameplay systems in the roadmap remain planned.

## Local installation and fresh checkout

The Linux Mint Applications launcher at `~/.local/share/applications/org.godotengine.Godot.desktop` points through `~/.local/bin/godot` to a standard Godot 4.7.2 x86_64 editor. No Godot Flatpak appeared in the installed-app list. The standard editor remains installed. This project uses the matching official 4.7.2 .NET x86_64 editor alongside it. The chosen .NET SDK is 10.0.403 (x64), pinned by `game/global.json`; `game/SpaceFactory.csproj` pins `Godot.NET.Sdk/4.7.2`. The .NET SDK must be installed separately from Godot.

On this machine the ignored `tools/local.env` sets the local executable paths. On another machine, install the [official Godot 4.7.2 .NET editor and matching .NET export templates](https://godotengine.org/download/archive/4.7.2-stable/) and the [official .NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0). Use the exact pinned SDK version or deliberately update `global.json` after checking compatibility.

For a Linux x86_64 fresh checkout, the official downloads can be installed without changing the system editor:

```bash
mkdir -p "$HOME/.local/opt/godot/4.7.2-dotnet" "$HOME/.local/opt/dotnet"
curl -fL 'https://downloads.godotengine.org/?version=4.7.2&flavor=stable&platform=linux.64&slug=mono_linux_x86_64.zip' -o /tmp/godot-dotnet.zip
unzip /tmp/godot-dotnet.zip -d "$HOME/.local/opt/godot/4.7.2-dotnet"
curl -fsSL https://dot.net/v1/dotnet-install.sh -o /tmp/dotnet-install.sh
bash /tmp/dotnet-install.sh --version 10.0.403 --install-dir "$HOME/.local/opt/dotnet" --architecture x64 --os linux
```

Create `tools/local.env` with quoted Bash assignments:

```bash
GODOT_CMD=("$HOME/.local/opt/godot/4.7.2-dotnet/Godot_v4.7.2-stable_mono_linux_x86_64/Godot_v4.7.2-stable_mono_linux.x86_64")
DOTNET_BIN="$HOME/.local/opt/dotnet/dotnet"
```

`GODOT_CMD` is an array so a launcher such as `GODOT_CMD=(flatpak run application.id)` can have several arguments safely. The script does not evaluate a command string. A single-executable `GODOT_BIN` environment override is also supported. Install matching .NET export templates through Godot's **Editor → Manage Export Templates** before exporting, then run `./tools/dev doctor`. It reports the actual editor version, .NET capability, selected SDK, display variables, and template location.

## Commands

All paths below are relative to the repository root. `tools/dev` resolves the project from its own path, so it can be called from another working directory.

| Command | Result |
| --- | --- |
| `./tools/dev doctor` | Show local tool and export readiness. |
| `./tools/dev import` | Wait for asset imports to finish. |
| `./tools/dev build` | Compile the C# project. |
| `./tools/dev check` | Import, build, run the real main-scene C# smoke mode, and verify scene automation. |
| `./tools/dev run` | Build and launch the sandbox in the foreground. |
| `./tools/dev editor` | Open the project in the Godot editor. |
| `./tools/dev inspect-scene scenes/main.tscn` | Print a saved scene hierarchy and useful properties. A `res://` path also works. |
| `./tools/dev automation-smoke` | Create, edit, save, reload, assert, and remove a disposable scene. |
| `./tools/dev export Linux` | Build a Linux x86_64 release in `artifacts/exports/Linux/`. |
| `./tools/dev export Windows` | Build a Windows x86_64 release in `artifacts/exports/Windows/`. |
| `./tools/dev export macOS` | Build a macOS universal ZIP in `artifacts/exports/macOS/`. |

The exact preset names are `Linux`, `Windows`, and `macOS`. Install the matching 4.7.2 .NET templates before exporting. Windows and macOS builds are configured here; running, signing, notarizing, and packaging them on their target operating systems is separate validation.

## Editing and automation

Edit gameplay in `game/scripts/*.cs`, saved scenes in `game/scenes/*.tscn`, and future resources in `.tres` files. Godot serializes scene changes through its editor; close or reload an open scene before an external tool writes that same file, to avoid conflicting saves. Generated `.godot/`, `bin/`, `obj/`, logs, and exports are ignored.

`game/dev/scene_tool.gd` is a small standalone `SceneTree` script for Godot's `--script` workflow. It is isolated from C# gameplay and excluded from exports. Its `inspect` operation loads and walks a saved scene. Its automation operation creates a root and owned child, changes the child's position and text, packs and saves the scene, reloads with cache bypass, asserts the serialized values, and removes the fixture. To add a future operation, add a command to its match statement and a corresponding `tools/dev` branch; use Godot's scene/resource APIs and a fresh load when validating persistence. A missing `inspect-scene` path must return a nonzero result.

`./tools/dev check` requires the exact `SPACE_FACTORY_SMOKE_OK` marker from `Main.cs`. It also treats timeouts and engine/script errors as failures. The log for each operation is in `artifacts/logs/`. Clean generated outputs by deleting `artifacts/`, `game/.godot/`, `game/bin/`, and `game/obj/` after closing the editor; all can be recreated.

## Verification record

Verified on Linux Mint x86_64 with Godot `4.7.2.stable.mono.official.ed1daf0bf` and .NET SDK `10.0.403` on 2026-11-08:

| Area | Result |
| --- | --- |
| Build | `./tools/dev build` passed with zero warnings and errors. |
| Runtime | `./tools/dev check` ran the real `scenes/main.tscn`; `Main.cs` emitted `SPACE_FACTORY_SMOKE_OK` and exited within the 30-second limit. The check also passed after removing the generated Godot cache. |
| Scene automation | `inspect-scene` printed the main hierarchy. `automation-smoke` serialized and reloaded the owned child with its changed position and text. A missing scene returned status 1 and `SCENE_TOOL_FAILED`. |
| Repeatability | A repeated normal check left tracked and untracked source-file hashes unchanged. The temporary fixture was removed. |
| Visual and input | The editor opened the project. The rendered game showed the deck, engineer, and title; injected `D` and right-arrow keypresses each moved the engineer from the center to the right. Closing the game and editor windows exited cleanly. Screenshots are in local `artifacts/`. |
| Linux export | `./tools/dev export Linux` produced `SpaceFactory.x86_64` plus the adjacent `data_SpaceFactory_linuxbsd_x86_64/` .NET runtime directory. The exported game passed the headless C# smoke, launched visibly, and closed cleanly. Keep both paths together. |

The initial export attempt identified Godot's required `.sln` file, which was added before the successful export. The initial import attempt aborted inside Godot, but subsequent imports, including a cold import after deleting the generated cache, passed. These earlier failures are recorded here and do not qualify as current blockers.

The matching Linux debug and release .NET templates are installed in `~/.local/share/godot/export_templates/4.7.2.stable.mono/`. Windows and macOS presets are configured, but their matching templates are not installed here and those exports and target-OS runs were not performed. macOS distribution also needs platform-specific signing/notarization decisions; Windows distribution needs packaging and target-OS validation. The [roadmap](roadmap.md) Gate G0.1 remains in progress because the sandbox is a foundation rather than the complete ship-sized gameplay criterion.
