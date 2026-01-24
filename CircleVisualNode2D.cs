using Godot;
using System;

public partial class CircleVisualNode2D : Node2D
{

    private float _BallRadious = 5f;
    private bool _NeedsApplyBallRadious = false;

    [Export(PropertyHint.Range, "1,50")]
    public float BallRadious
    {
        get => _BallRadious;
        set
        {
            _BallRadious = value;
            // IMPORTANT: guard against scene not being ready yet
            if (!IsInsideTree()) {
                this._NeedsApplyBallRadious = true;
                return;
            }
            ApplyBallRadious();
        }
    }

    public override void _Ready()
    {
        base._Ready();
        if (_NeedsApplyBallRadious) {
            ApplyBallRadious();
        }
    }

    public override void _Draw()
    {
        base._Draw();
        DrawCircle(Vector2.Zero, _BallRadious, Colors.White, true);
    }

    private void ApplyBallRadious()
    {
        this.QueueRedraw();
    }

}
