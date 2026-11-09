using Godot;

namespace SpaceFactory;

public partial class Engineer : CharacterBody2D
{
    private const float Speed = 220f;
    // Covers the 32-pixel art canvas and the existing collision circle.
    public const float BodyInset = 20f;
    private readonly Texture2D _idle = GD.Load<Texture2D>("res://assets/pixel/engineer/engineer_idle_down.png");
    private Deck _deck = null!;
    private Ship _ship = null!;

    public override void _Ready()
    {
        _deck = GetNode<Deck>("../Deck");
        _ship = (Ship)GetParent();
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = _ship.WalkingDirection * Speed;
        MoveAndSlide();
        ConstrainToDeck();
    }

    internal void ConstrainToDeck()
    {
        var safe = Deck.InteriorBounds.Grow(-BodyInset);
        var deckPosition = _deck.ToLocal(GlobalPosition);
        deckPosition.X = Mathf.Clamp(deckPosition.X, safe.Position.X, safe.End.X);
        deckPosition.Y = Mathf.Clamp(deckPosition.Y, safe.Position.Y, safe.End.Y);
        GlobalPosition = _deck.ToGlobal(deckPosition);
    }

    public override void _Draw()
    {
        DrawTexture(_idle, new Vector2(-16, -16));
    }
}
