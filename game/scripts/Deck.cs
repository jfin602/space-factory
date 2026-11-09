using Godot;

namespace SpaceFactory;

public partial class Deck : Node2D
{
    public static readonly Rect2 InteriorBounds = new(-360, -210, 720, 420);
    private readonly Texture2D _tile = GD.Load<Texture2D>("res://assets/pixel/ship/deck_tile.png");

    public override void _Draw()
    {
        var hull = new Vector2[]
        {
            new(-390, -240), new(320, -240), new(390, -175),
            new(390, 175), new(320, 240), new(-390, 240)
        };
        DrawColoredPolygon(hull, new Color("18232d"));
        DrawPolyline(new Vector2[]
        {
            hull[0], hull[1], hull[2], hull[3], hull[4], hull[5], hull[0]
        }, new Color("b2a99a"), 3);

        var bounds = InteriorBounds;
        for (float y = bounds.Position.Y; y < bounds.End.Y; y += 40)
        for (float x = bounds.Position.X; x < bounds.End.X; x += 40)
        {
            float width = Mathf.Min(40, bounds.End.X - x);
            float height = Mathf.Min(40, bounds.End.Y - y);
            DrawTextureRectRegion(_tile, new Rect2(x, y, width, height), new Rect2(0, 0, width, height));
        }
        DrawRect(bounds, new Color("8d877e"), false, 3);
    }
}
