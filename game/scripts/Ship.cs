using Godot;

namespace SpaceFactory;

public partial class Ship : Node2D
{
    public enum ControlMode { Walking, Piloting }

    public const float HelmInteractionRange = 100f;
    public ControlMode Mode { get; private set; } = ControlMode.Walking;
    public Vector2 WalkingDirection { get; private set; }
    public Vector2 ThrustRequest { get; private set; }
    public string PropulsionUnavailableReason => "No propellant supply available";
    public bool IsEngineerNearHelm => _engineer.GlobalPosition.DistanceTo(_helm.GlobalPosition) <= HelmInteractionRange;

    private Engineer _engineer = null!;
    private Node2D _helm = null!;

    public override void _Ready()
    {
        _engineer = GetNode<Engineer>("Engineer");
        _helm = GetNode<Node2D>("Helm");
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("interact"))
            HandleInteractionEdge();
    }

    public override void _PhysicsProcess(double delta)
    {
        RouteDirection(Input.GetVector("move_left", "move_right", "move_up", "move_down"));
        // The starter ship has no propellant supply or applied propulsion.
    }

    internal bool HandleInteractionEdge()
    {
        if (Mode == ControlMode.Walking)
        {
            if (!IsEngineerNearHelm)
                return false;
            Mode = ControlMode.Piloting;
        }
        else
        {
            Mode = ControlMode.Walking;
        }

        WalkingDirection = Vector2.Zero;
        ThrustRequest = Vector2.Zero;
        _engineer.Velocity = Vector2.Zero;
        return true;
    }

    internal void RouteDirection(Vector2 direction)
    {
        if (Mode == ControlMode.Walking)
        {
            WalkingDirection = direction;
            ThrustRequest = Vector2.Zero;
        }
        else
        {
            WalkingDirection = Vector2.Zero;
            ThrustRequest = direction;
        }
    }
}
