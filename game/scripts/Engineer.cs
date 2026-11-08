using Godot;

namespace SpaceFactory;

public partial class Engineer : CharacterBody2D
{
    private const float Speed = 220f;
    // Covers the drawn body and its three-pixel shadow offset, with one pixel clearance.
    public const float BodyInset = 20f;
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
        DrawCircle(new Vector2(0, 3), 16, new Color("102534"));
        DrawCircle(Vector2.Zero, 13, new Color("f2bc66"));
        DrawRect(new Rect2(-8, -7, 16, 7), new Color("f8e2a1"));
        DrawCircle(new Vector2(4, -3), 2.5f, new Color("183d4b"));
    }
}
