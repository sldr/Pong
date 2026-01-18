using Godot;
using System;

public partial class Wall : Line2D
{
    public override void _Ready()
    {
        base._Ready();
        this.Width = GetViewport().GetVisibleRect().Size.X;
        //CollisionShape2D collisionShape2D = this.GetChild<StaticBody2D>(0).GetChild<CollisionShape2D>(0);
        //RectangleShape2D rectangleShape2D = collisionShape2D.Shape as RectangleShape2D;
        //Vector2 v = rectangleShape2D.Size;
        //v.X = GetViewport().GetVisibleRect().Size.X;
        //v.Y = GetViewport().GetVisibleRect().Size.Y;
        //nce = GetViewport().GetVisibleRect().Size.X;
        //this.
        GetViewport().SizeChanged += Wall_SizeChanged;
    }

    private void Wall_SizeChanged()
    {
        this.Width = GetViewport().GetVisibleRect().Size.X;
        //CollisionShape2D collisionShape2D = this.GetChild<StaticBody2D>(0).GetChild<CollisionShape2D>(0);
        //RectangleShape2D rectangleShape2D = collisionShape2D.Shape as RectangleShape2D;
        //Vector2 v = rectangleShape2D.Size;
        //v.X = GetViewport().GetVisibleRect().Size.X;
        //v.Y = GetViewport().GetVisibleRect().Size.Y;
    }
}
