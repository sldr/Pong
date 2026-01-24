using Godot;
using System;

public partial class Ball : CharacterBody2D
{

    private float _BallRadious = 5f;
    private bool _NeedsApplyBallRadious = false;

    [Export(PropertyHint.Range, "1,50")]
    public float BallRadious
    {
        get => _BallRadious;
        set
        {
            if (!Mathf.IsEqualApprox(_BallRadious, value)) {
                _BallRadious = value;
                // IMPORTANT: guard against scene not being ready yet
                if (!IsInsideTree()) {
                    this._NeedsApplyBallRadious = true;
                    return;
                }
                ApplyBallRadious();
            }
        }
    }

    public override void _Ready()
    {
        base._Ready();
        if (_NeedsApplyBallRadious) {
            ApplyBallRadious();
        }
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        //this.GetChild<CircleVisualNode2D>(1).QueueRedraw();
    }

    public override void _Draw()
    {
        base._Draw();
        //this.GetChild<CircleVisualNode2D>(1).QueueRedraw();
    }

    private void ApplyBallRadious()
    {
        CircleShape2D c = this.GetChild<CollisionShape2D>(0).Shape as CircleShape2D;
        c.Radius = _BallRadious;
        this.GetChild<CollisionShape2D>(0).Shape = c;
        this.GetChild<CircleVisualNode2D>(1).BallRadious = _BallRadious;
        this.QueueRedraw();
    }

}
