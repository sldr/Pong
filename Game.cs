using Godot;
using System;

public partial class Game : Node2D
{
    public override void _Ready()
    {
        base._Ready();
        GetViewport().SizeChanged += Game_SizeChanged;
        var centerLine2D = this.GetNode<Line2D>("CanvasLayer/CenterContainer3/CenterLine2D");
        centerLine2D.SetPointPosition(1, new Vector2(centerLine2D.GetPointPosition(1).X, GetViewport().GetVisibleRect().Size.Y));
    }

    private void Game_SizeChanged()
    {
        var centerLine2D = this.GetNode<Line2D>("CanvasLayer/CenterContainer3/CenterLine2D");
        centerLine2D.SetPointPosition(1, new Vector2(centerLine2D.GetPointPosition(1).X, GetViewport().GetVisibleRect().Size.Y));
    }
}
