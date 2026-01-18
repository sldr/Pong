using Godot;
using System;

public partial class WallCollisionShape2D : CollisionShape2D
{
    private int _WallThickness = 10;

    [Export(PropertyHint.Range, "1,50")]
    public int WallThickness
    {
        get => _WallThickness;
        set
        {
            _WallThickness = value;
            (this.Shape as WorldBoundaryShape2D).Distance = value;
        }
    }

}
