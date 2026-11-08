using Godot;
using System;
using System.Threading.Tasks;

namespace SpaceFactory;

public partial class Main : Node2D
{
    private static readonly Vector2 DemoOffset = new(-60, 0);
    private const float DemoDurationSeconds = 1.25f;
    private Ship _ship = null!;
    private Label _mode = null!;
    private Label _help = null!;
    private Label _feedback = null!;
    private Label _demoLabel = null!;
    private bool _demoEnabled;
    private bool _demoRunning;
    private float _demoElapsed;
    private Vector2 _demoOrigin;

    public override async void _Ready()
    {
        _ship = GetNode<Ship>("Ship");
        _mode = GetNode<Label>("Overlay/Mode");
        _help = GetNode<Label>("Overlay/Help");
        _feedback = GetNode<Label>("Overlay/Feedback");
        _demoLabel = GetNode<Label>("Overlay/DemoLabel");
        _demoEnabled = Array.Exists(OS.GetCmdlineUserArgs(), arg => arg == "--p1-spatial-demo");
        _demoOrigin = _ship.Position;
        _demoLabel.Visible = _demoEnabled;
        RefreshHud();

        if (!Array.Exists(OS.GetCmdlineUserArgs(), arg => arg == "--smoke"))
        {
            _demoRunning = _demoEnabled;
            return;
        }

        await ToSignal(GetTree(), SceneTree.SignalName.PhysicsFrame);

        bool valid;
        try
        {
            CheckSmokeScene();
            await CheckFrameIntegration();
            if (_demoEnabled)
                await CheckDemoFixture();
            else
                Require(!_demoLabel.Visible && Near(_ship.Position, _demoOrigin), "ordinary scene has no fixture movement");
            valid = true;
            GD.Print("SPACE_FACTORY_SMOKE_OK main scene and C# scripts executed");
        }
        catch (Exception error)
        {
            valid = false;
            GD.PushError($"SPACE_FACTORY_SMOKE_FAILED {error.Message}");
        }

        GetTree().Quit(valid ? 0 : 1);
    }

    public override void _Process(double delta)
    {
        if (_demoRunning)
            AdvanceDemo((float)delta);
        RefreshHud();
    }

    private void AdvanceDemo(float delta)
    {
        _demoElapsed = Mathf.Min(_demoElapsed + delta, DemoDurationSeconds);
        _ship.Position = _demoOrigin + DemoOffset * (_demoElapsed / DemoDurationSeconds);
        _demoLabel.Text = _demoElapsed < DemoDurationSeconds
            ? "DEV SPATIAL FIXTURE — translating ship"
            : "DEV SPATIAL FIXTURE — translated ship held";
    }

    private void RefreshHud()
    {
        _mode.Text = $"Mode: {_ship.Mode}";
        _help.Text = _ship.Mode == Ship.ControlMode.Piloting
            ? "WASD / arrows: request thrust   •   E: leave helm"
            : _ship.IsEngineerNearHelm
                ? "WASD / arrows: walk   •   E: use helm"
                : "WASD / arrows: walk   •   Approach helm to interact";
        _feedback.Text = _ship.Mode == Ship.ControlMode.Piloting && _ship.ThrustRequest != Vector2.Zero
            ? $"{_ship.PropulsionUnavailableReason}. Ship remains stationary."
            : "";
    }

    private void CheckSmokeScene()
    {
        Require(SceneFilePath == "res://scenes/main.tscn", "main scene path");
        var ship = GetNode<Ship>("Ship");
        var deck = GetNode<Deck>("Ship/Deck");
        var engineer = GetNode<Engineer>("Ship/Engineer");
        var helm = GetNode<Node2D>("Ship/Helm");
        var landmark = GetNode<Node2D>("Landmark");
        Require(GetNodeOrNull<Polygon2D>("Landmark/Beacon") is not null, "world beacon");
        Require(GetNodeOrNull<Camera2D>("Camera2D") is not null, "world camera");
        Require(GetNodeOrNull<Label>("Overlay/Title")?.Text == "Space Factory — Development Sandbox", "overlay title");
        Require(deck.GetParent() == ship && engineer.GetParent() == ship && helm.GetParent() == ship, "ship-local ownership");
        Require(landmark.GetParent() == this, "stationary world ownership");
        Require(ship.Position == new Vector2(480, 300), "initial ship origin");
        Require(deck.Position == Vector2.Zero && engineer.Position == Vector2.Zero, "initial local positions");
        Require(helm.Position == new Vector2(0, -95), "helm local position");
        Require(GetNodeOrNull<Polygon2D>("Ship/Helm/Console") is not null, "visible helm console");

        var collision = engineer.GetNode<CollisionShape2D>("CollisionShape2D").Shape as CircleShape2D;
        Require(collision is not null && collision.Radius <= Engineer.BodyInset, "body inset covers collision");
        CheckBodyInsideDeck(deck, engineer);
        CheckDeckBoundaries(deck, engineer);

        var shipStart = ship.Position;
        var deckLocal = deck.Position;
        var engineerLocal = engineer.Position;
        var helmLocal = helm.Position;
        var deckWorld = deck.GlobalPosition;
        var engineerWorld = engineer.GlobalPosition;
        var helmWorld = helm.GlobalPosition;
        var landmarkLocal = landmark.Position;
        var landmarkWorld = landmark.GlobalPosition;
        var shift = new Vector2(37, -24);
        ship.Position += shift;
        Require(deck.Position == deckLocal && engineer.Position == engineerLocal && helm.Position == helmLocal, "translation preserves interior local positions");
        Require(Near(deck.GlobalPosition, deckWorld + shift) && Near(engineer.GlobalPosition, engineerWorld + shift)
            && Near(helm.GlobalPosition, helmWorld + shift), "translation carries interior");
        Require(landmark.Position == landmarkLocal && Near(landmark.GlobalPosition, landmarkWorld), "landmark stays fixed");

        CheckDeckBoundaries(deck, engineer);

        ship.Position = shipStart;
        engineer.Position = engineerLocal;
        Require(Near(landmark.GlobalPosition, landmarkWorld), "landmark remains fixed after reset");
        CheckHelmControls(ship, engineer, helm);
    }

    private async Task CheckFrameIntegration()
    {
        var engineer = GetNode<Engineer>("Ship/Engineer");
        var start = engineer.Position;
        var shipStart = _ship.Position;
        var press = new InputEventAction { Action = "interact", Pressed = true };
        var release = new InputEventAction { Action = "interact", Pressed = false };

        Input.ActionPress("move_right");
        try
        {
            await WaitPhysicsSteps(2);
            Require(_ship.Mode == Ship.ControlMode.Walking && engineer.Position.X > start.X
                && _ship.ThrustRequest == Vector2.Zero && _ship.Position == shipStart, "frame-based walking owns direction");
            var walkingPosition = engineer.Position;

            _ship._Input(press);
            Require(_ship.Mode == Ship.ControlMode.Piloting && engineer.Velocity == Vector2.Zero
                && _ship.WalkingDirection == Vector2.Zero && _ship.ThrustRequest == Vector2.Zero
                && engineer.Position == walkingPosition, "held-direction entry clears walking immediately");
            _ship._Input(release);
            Require(_ship.Mode == Ship.ControlMode.Piloting, "interaction release is not an edge");
            await WaitPhysicsSteps(2);
            Require(_ship.ThrustRequest == Vector2.Right && _ship.WalkingDirection == Vector2.Zero
                && engineer.Position == walkingPosition && _ship.Position == shipStart, "held direction pilots without ship motion");

            _ship._Input(press);
            Require(_ship.Mode == Ship.ControlMode.Walking && _ship.ThrustRequest == Vector2.Zero
                && _ship.WalkingDirection == Vector2.Zero && engineer.Velocity == Vector2.Zero
                && engineer.Position == walkingPosition, "held-direction exit clears thrust immediately");
            await WaitPhysicsSteps(2);
            Require(engineer.Position.X > walkingPosition.X && _ship.ThrustRequest == Vector2.Zero
                && _ship.Position == shipStart, "held direction resumes walking only");
            GD.Print($"SPACE_FACTORY_P3_FRAMES_OK walk={walkingPosition} pilot_request={Vector2.Right} exit_request={Vector2.Zero}");
        }
        finally
        {
            Input.ActionRelease("move_right");
            _ship.RouteDirection(Vector2.Zero);
            engineer.Velocity = Vector2.Zero;
            engineer.Position = start;
        }
    }

    private async Task CheckDemoFixture()
    {
        var deck = GetNode<Deck>("Ship/Deck");
        var engineer = GetNode<Engineer>("Ship/Engineer");
        var helm = GetNode<Node2D>("Ship/Helm");
        var landmark = GetNode<Node2D>("Landmark");
        var landmarkStart = landmark.GlobalPosition;
        var deckLocal = deck.Position;
        var engineerLocal = engineer.Position;
        var helmLocal = helm.Position;
        Require(_demoLabel.Visible && _demoElapsed == 0 && _ship.Position == _demoOrigin, "fixture flag starts at ship origin");

        _demoRunning = true;
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        Require(_demoElapsed > 0 && _demoElapsed <= DemoDurationSeconds, "fixture starts bounded translation");
        var startTicks = Time.GetTicksMsec();
        while (_demoElapsed < DemoDurationSeconds)
        {
            await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
            Require(Time.GetTicksMsec() - startTicks < 5000, "fixture reaches held offset within five seconds");
        }

        var heldPosition = _demoOrigin + DemoOffset;
        Require(Near(_ship.Position, heldPosition) && _demoLabel.Text.Contains("translated ship held"), "fixture holds labeled offset");
        Require(deck.Position == deckLocal && engineer.Position == engineerLocal && helm.Position == helmLocal, "fixture preserves local positions");
        Require(Near(deck.GlobalPosition, heldPosition + deckLocal)
            && Near(engineer.GlobalPosition, heldPosition + engineerLocal)
            && Near(helm.GlobalPosition, heldPosition + helmLocal), "fixture translates all interior nodes");
        Require(Near(landmark.GlobalPosition, landmarkStart), "fixture landmark remains stationary");
        CheckDeckBoundaries(deck, engineer);
        Require(_ship.IsEngineerNearHelm, "translated fixture retains nearby helm range");
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        Require(Near(_ship.Position, heldPosition) && Near(landmark.GlobalPosition, landmarkStart), "fixture holds after completion");
        GD.Print($"SPACE_FACTORY_P1_DEMO_OK origin={_demoOrigin} held={heldPosition} landmark={landmarkStart}");
    }

    private async Task WaitPhysicsSteps(int count)
    {
        for (int i = 0; i < count; i++)
            await ToSignal(GetTree(), SceneTree.SignalName.PhysicsFrame);
    }

    private static void CheckDeckBoundaries(Deck deck, Engineer engineer)
    {
        var originalPosition = engineer.Position;
        var safe = Deck.InteriorBounds.Grow(-Engineer.BodyInset);
        CheckCorner(deck, engineer, new Vector2(-1000, -1000), safe.Position);
        CheckCorner(deck, engineer, new Vector2(1000, -1000), new Vector2(safe.End.X, safe.Position.Y));
        CheckCorner(deck, engineer, new Vector2(-1000, 1000), new Vector2(safe.Position.X, safe.End.Y));
        CheckCorner(deck, engineer, new Vector2(1000, 1000), safe.End);
        CheckCorner(deck, engineer, new Vector2(-1000, 0), new Vector2(safe.Position.X, 0));
        CheckCorner(deck, engineer, new Vector2(1000, 0), new Vector2(safe.End.X, 0));
        CheckCorner(deck, engineer, new Vector2(0, -1000), new Vector2(0, safe.Position.Y));
        CheckCorner(deck, engineer, new Vector2(0, 1000), new Vector2(0, safe.End.Y));
        engineer.Position = originalPosition;
    }

    private void CheckHelmControls(Ship ship, Engineer engineer, Node2D helm)
    {
        Require(InputMap.HasAction("interact"), "interaction action");
        bool boundToE = false;
        foreach (var inputEvent in InputMap.ActionGetEvents("interact"))
            if (inputEvent is InputEventKey key && key.PhysicalKeycode == Key.E)
                boundToE = true;
        Require(boundToE, "E interaction binding");

        var press = new InputEventAction { Action = "interact", Pressed = true };
        var release = new InputEventAction { Action = "interact", Pressed = false };
        var shipStart = ship.Position;
        var helmLocal = helm.Position;
        engineer.Position = new Vector2(200, 0);
        ship._Input(press);
        Require(ship.Mode == Ship.ControlMode.Walking && engineer.Position == new Vector2(200, 0), "distant helm refusal");

        engineer.Position = Vector2.Zero;
        Require(ship.IsEngineerNearHelm, "nearby helm acceptance range");
        ship.RouteDirection(Vector2.Right);
        Require(ship.WalkingDirection == Vector2.Right && ship.ThrustRequest == Vector2.Zero, "walking input exclusivity");
        engineer._PhysicsProcess(1.0 / 60.0);
        Require(engineer.Position.X > 0 && ship.Position == shipStart, "walking moves only engineer");
        var entryPosition = engineer.Position;
        var walkingVelocity = engineer.Velocity;

        ship._Input(press);
        Require(ship.Mode == Ship.ControlMode.Piloting && engineer.Position == entryPosition
            && engineer.Velocity == Vector2.Zero && ship.WalkingDirection == Vector2.Zero
            && ship.ThrustRequest == Vector2.Zero, "entry while walking clears velocity and intent");
        ship._Input(release);
        Require(ship.Mode == Ship.ControlMode.Piloting, "release does not toggle mode");

        ship.RouteDirection(Vector2.Right);
        engineer._PhysicsProcess(1.0 / 60.0);
        Require(ship.ThrustRequest == Vector2.Right && ship.WalkingDirection == Vector2.Zero
            && engineer.Position == entryPosition && ship.Position == shipStart, "pilot request without movement");
        var pilotVelocity = engineer.Velocity;
        RefreshHud();
        Require(_mode.Text == "Mode: Piloting" && _help.Text.Contains("E: leave helm")
            && _feedback.Text.Contains(ship.PropulsionUnavailableReason), "state-derived pilot HUD");

        ship._Input(press);
        Require(ship.Mode == Ship.ControlMode.Walking && ship.ThrustRequest == Vector2.Zero
            && ship.WalkingDirection == Vector2.Zero && engineer.Velocity == Vector2.Zero
            && engineer.Position == entryPosition && ship.Position == shipStart, "exit clears held request immediately");
        var exitVelocity = engineer.Velocity;
        var exitRequest = ship.ThrustRequest;
        ship.RouteDirection(Vector2.Right);
        Require(ship.ThrustRequest == Vector2.Zero && ship.WalkingDirection == Vector2.Right, "walking does not revive thrust");
        engineer._PhysicsProcess(1.0 / 60.0);
        Require(engineer.Position.X > entryPosition.X && ship.Position == shipStart, "walking resumes with current input");

        var repeatedPosition = engineer.Position;
        ship._Input(press);
        ship._Input(release);
        Require(ship.Mode == Ship.ControlMode.Piloting && engineer.Position == repeatedPosition, "repeat entry preserves position");
        ship._Input(press);
        Require(ship.Mode == Ship.ControlMode.Walking && engineer.Position == repeatedPosition
            && ship.ThrustRequest == Vector2.Zero, "repeat exit preserves position");

        var offset = new Vector2(37, -24);
        ship.Position += offset;
        Require(Near(helm.GlobalPosition, shipStart + offset + helmLocal), "translated helm remains local");
        engineer.Position = new Vector2(200, 0);
        ship._Input(press);
        Require(ship.Mode == Ship.ControlMode.Walking, "translated distant helm refusal");
        engineer.Position = Vector2.Zero;
        ship._Input(press);
        Require(ship.Mode == Ship.ControlMode.Piloting, "translated nearby helm acceptance");
        ship._Input(press);
        Require(ship.Mode == Ship.ControlMode.Walking && ship.ThrustRequest == Vector2.Zero, "translated exit");

        ship.Position = shipStart;
        engineer.Position = Vector2.Zero;
        ship.RouteDirection(Vector2.Zero);
        RefreshHud();
        Require(_mode.Text == "Mode: Walking" && _help.Text.Contains("E: use helm")
            && _feedback.Text == "", "walking HUD reflects nearby helm");
        GD.Print($"SPACE_FACTORY_P2_CONTROL_OK far=Walking walk_position={entryPosition} walk_velocity={walkingVelocity} "
            + $"pilot_request={Vector2.Right} pilot_velocity={pilotVelocity} exit_request={exitRequest} exit_velocity={exitVelocity}");
    }

    private static void CheckCorner(Deck deck, Engineer engineer, Vector2 outside, Vector2 expected)
    {
        engineer.GlobalPosition = deck.ToGlobal(outside);
        engineer.ConstrainToDeck();
        Require(Near(deck.ToLocal(engineer.GlobalPosition), expected), "corner containment");
        CheckBodyInsideDeck(deck, engineer);
    }

    private static void CheckBodyInsideDeck(Deck deck, Engineer engineer)
    {
        var center = deck.ToLocal(engineer.GlobalPosition);
        var bounds = Deck.InteriorBounds;
        var inset = Engineer.BodyInset;
        Require(center.X - inset >= bounds.Position.X - 0.01f
            && center.Y - inset >= bounds.Position.Y - 0.01f
            && center.X + inset <= bounds.End.X + 0.01f
            && center.Y + inset <= bounds.End.Y + 0.01f, "whole body within deck");
    }

    private static bool Near(Vector2 actual, Vector2 expected) => actual.DistanceTo(expected) < 0.01f;

    private static void Require(bool condition, string invariant)
    {
        if (!condition)
            throw new InvalidOperationException(invariant);
    }
}
