using Godot;
using System;

public partial class Game : Node2D
{
    private Player player;

    public override void _Ready()
    {
        base._Ready();
        GetViewport().SizeChanged += Game_SizeChanged;
        var centerLine2D = this.GetNode<Line2D>("CanvasLayer/CenterContainer3/CenterLine2D");
        centerLine2D.SetPointPosition(1, new Vector2(centerLine2D.GetPointPosition(1).X, GetViewport().GetVisibleRect().Size.Y));
        this.player = GetNode<Player>("PlayerSprite2D");
        //var t = this.player.Transform;
        //t.Y = GetViewport().GetVisibleRect().Size.Y / 2;
        //    Transform.Y = GetViewport().GetVisibleRect().Size.Y / 2;
        var t = this.player.Transform;
        player.GlobalPosition = this.GetNode<Node2D>("CanvasLayer/LeftCenterContainer/SpawnLeftNode2D").GlobalPosition;
        //player.GlobalPosition.X = this.GetNode<Node2D>("CanvasLayer/CenterContainer4/SpawnLeftNode2D").GlobalPosition.X;
        //this.player.Transform. = this.GetNode<Node2D>("CanvasLayer/CenterContainer4/SpawnLeftNode2D").Transform;
    }

    private void Game_SizeChanged()
    {
        var centerLine2D = this.GetNode<Line2D>("CanvasLayer/CenterContainer3/CenterLine2D");
        centerLine2D.SetPointPosition(1, new Vector2(centerLine2D.GetPointPosition(1).X, GetViewport().GetVisibleRect().Size.Y));
    }
}
