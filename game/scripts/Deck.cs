using Godot;

namespace SpaceFactory;

public partial class Deck : Node2D
{
    public override void _Draw()
    {
        var bounds = new Rect2(-360, -210, 720, 420);
        DrawRect(new Rect2(-390, -240, 780, 480), new Color("172c3c"));
        DrawRect(bounds, new Color("253f50"));
        for (int x = -360; x <= 360; x += 40)
            DrawLine(new Vector2(x, -210), new Vector2(x, 210), new Color("355b68"), 1);
        for (int y = -210; y <= 210; y += 40)
            DrawLine(new Vector2(-360, y), new Vector2(360, y), new Color("355b68"), 1);
        DrawRect(bounds, new Color("80b1ad"), false, 4);
        DrawRect(new Rect2(-345, -195, 90, 50), new Color("756b4d"));
        DrawRect(new Rect2(250, 145, 95, 50), new Color("596a82"));
    }
}

