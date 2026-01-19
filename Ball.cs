using Godot;
using System;

public partial class Ball : CharacterBody2D
{
    [Export(PropertyHint.Range, "1,50")]
    public float BallRadious = 5f;

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        this.GetChild<CircleVisualNode2D>(1).BallRadious = BallRadious; // Maybe adjust to do only when changes...
        CircleShape2D c = this.GetChild<CollisionShape2D>(0).Shape as CircleShape2D;
        c.Radius = BallRadious;
        this.GetChild<CollisionShape2D>(0).Shape = c;
    }

}
