using Godot;

namespace SpaceFactory;

public partial class Engineer : CharacterBody2D
{
    private const float Speed = 220f;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = Input.GetVector("move_left", "move_right", "move_up", "move_down") * Speed;
        MoveAndSlide();
        Position = new Vector2(Mathf.Clamp(Position.X, 140, 820), Mathf.Clamp(Position.Y, 100, 500));
    }

    public override void _Draw()
    {
        DrawCircle(new Vector2(0, 3), 16, new Color("102534"));
        DrawCircle(Vector2.Zero, 13, new Color("f2bc66"));
        DrawRect(new Rect2(-8, -7, 16, 7), new Color("f8e2a1"));
        DrawCircle(new Vector2(4, -3), 2.5f, new Color("183d4b"));
    }
}
