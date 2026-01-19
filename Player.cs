using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public override void _Ready()
    {
        base._Ready();
        //var image = Image.CreateEmpty(1, 1, false, Image.Format.Rgba8);
        //image.Fill(Colors.White); // base pixel color
        //var texture = ImageTexture.CreateFromImage(image);
        //Sprite2D sprite2D = this.GetNode<Sprite2D>("PlayerSprite2D");
        //sprite2D.Texture = texture;
        // Set size via scale
        //sprite2D.Scale = new Vector2(10, 40);
        // Optional tint
        //sprite2D.Modulate = Colors.Red;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        //InputEventMouseButton.
        var v = this.Velocity;
        v.Y = 0;
        if (Input.IsActionJustPressed("mv_up")) {
            v.Y = -5000;
        }
        if (Input.IsActionJustPressed("mv_down")) {
            v.Y = 5000;
        }
        this.Velocity = v;
        MoveAndSlide();
    }

}
