using Godot;

namespace SpaceFactory;

public partial class Deck : Node2D
{
    public static readonly Rect2 InteriorBounds = new(-360, -210, 720, 420);

    public override void _Draw()
    {
        var hull = new Vector2[]
        {
            new(-390, -240), new(320, -240), new(390, -175),
            new(390, 175), new(320, 240), new(-390, 240)
        };
        DrawColoredPolygon(hull, new Color("172c3c"));
        DrawPolyline(new Vector2[]
        {
            hull[0], hull[1], hull[2], hull[3], hull[4], hull[5], hull[0]
        }, new Color("80b1ad"), 4);

        var bounds = InteriorBounds;
        DrawRect(bounds, new Color("253f50"));
        for (float x = bounds.Position.X; x <= bounds.End.X; x += 40)
            DrawLine(new Vector2(x, bounds.Position.Y), new Vector2(x, bounds.End.Y), new Color("355b68"), 1);
        for (float y = bounds.Position.Y; y <= bounds.End.Y; y += 40)
            DrawLine(new Vector2(bounds.Position.X, y), new Vector2(bounds.End.X, y), new Color("355b68"), 1);
        DrawRect(bounds, new Color("80b1ad"), false, 4);
        DrawRect(new Rect2(-345, -195, 90, 50), new Color("756b4d"));
        DrawRect(new Rect2(250, 145, 95, 50), new Color("596a82"));
    }
}
