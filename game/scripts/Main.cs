using Godot;
using System;

namespace SpaceFactory;

public partial class Main : Node2D
{
    public override void _Ready()
    {
        if (!Array.Exists(OS.GetCmdlineUserArgs(), arg => arg == "--smoke"))
            return;

        bool valid = SceneFilePath == "res://scenes/main.tscn"
            && GetNodeOrNull<Deck>("Deck") is not null
            && GetNodeOrNull<Engineer>("Engineer") is not null
            && GetNodeOrNull<Camera2D>("Camera2D") is not null
            && GetNodeOrNull<Label>("Overlay/Title")?.Text == "Space Factory — Development Sandbox";

        if (valid)
            GD.Print("SPACE_FACTORY_SMOKE_OK main scene and C# scripts executed");
        else
            GD.PushError("SPACE_FACTORY_SMOKE_FAILED required scene content missing");

        GetTree().Quit(valid ? 0 : 1);
    }
}

