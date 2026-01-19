using Godot;
using System;

public partial class CircleVisualNode2D : Node2D
{

    private float _BallRadious = 5f;

    [Export(PropertyHint.Range, "1,50")]
    public float BallRadious
    {
        get => _BallRadious;
        set
        {
            _BallRadious = value;
            //(this.Shape as WorldBoundaryShape2D).Distance = value;
        }
    }

    public override void _Ready()
    {
        base._Ready();
        this.QueueRedraw();
    }

    public override void _Draw()
    {
        base._Draw();
        DrawCircle(Vector2.Zero, _BallRadious, Colors.White);
    }

}
