using Godot;
using System;

public partial class Player : CharacterBody2D
{

    [Export] public float _Speed = 300f;
    private bool _WaitingForServe = false;
    private Ball _WaitingToServeBall;
    private Vector2 _WaitingToServeBallPosition;

    public override void _Ready()
    {
        base._Ready();
        GameInputManager.Instance.OnMove += OnMove;
        GameInputManager.Instance.Serve += OnServe;
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

    public override void _PhysicsProcess(double delta)
    {
        Velocity = Velocity.MoveToward(Vector2.Zero, (float)(800.0 * delta));
        MoveAndSlide();
        if (_WaitingForServe) {
            // Keep ball and paddle in the same spot
            if (!Mathf.IsEqualApprox(_WaitingToServeBallPosition.Y, this.Position.Y)) {
                _WaitingToServeBallPosition.Y = this.Position.Y;
                _WaitingToServeBall.Position = _WaitingToServeBallPosition;
                _WaitingToServeBall.QueueRedraw();
            }
        }
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        //InputEventMouseButton.
        //var v = this.Velocity;
        //v.Y = 0;
        //if (Input.IsActionJustPressed("mv_up")) {
        //    v.Y = -5000;
        //}
        //if (Input.IsActionJustPressed("mv_down")) {
        //    v.Y = 5000;
        //}
        //this.Velocity = v;
    }

    public void WaitForServe(Ball ball)
    {
        _WaitingForServe = true;
        _WaitingToServeBall = ball;
        _WaitingToServeBallPosition = ball.Position;
        _WaitingToServeBallPosition.Y =  this.Position.Y;
        _WaitingToServeBall.Position = _WaitingToServeBallPosition;
    }

    private void OnMove(Vector2 direction)
    {
        this.Velocity = direction * _Speed;
    }

    private void OnServe()
    {
        this._WaitingForServe = false;
        Vector2 direction = new Vector2(1f, 1f);
        this._WaitingToServeBall.Velocity = direction * this._WaitingToServeBall._Speed;
        this._WaitingToServeBall.QueueRedraw();
        GD.Print("Served!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    }

}
