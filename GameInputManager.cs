using Godot;
using System;

public partial class GameInputManager : Node
{
    // Singleton reference
    public static GameInputManager Instance { get; private set; }
    // Signals for subscribers
    public event Action<Vector2> OnMove;    // Continuous movement
    public event Action Serve;              // Discrete action

    // You can adjust these in the inspector if needed
    [Export] public string MoveLeft = "gi_moveleft";
    [Export] public string MoveRight = "gi_moveright";
    [Export] public string MoveUp = "gi_moveup";
    [Export] public string MoveDown = "gi_movedown";
    [Export] public string ServeAction = "gi_serve";

    public override void _Ready()
    {
        // Set singleton instance
        Instance = this;
    }

    public override void _Process(double delta)
    {
        // Compute a 2D movement vector from input map actions
        Vector2 moveVector = Input.GetVector(MoveLeft, MoveRight, MoveUp, MoveDown);
        // Only emit if there is movement
        if (moveVector != Vector2.Zero)
            OnMove?.Invoke(moveVector);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        // Discrete serve
        if (Input.IsActionJustPressed(ServeAction))
            Serve?.Invoke();
        // Mouse wheel
        if (@event is InputEventMouseButton mbe && mbe.Pressed) {
            Vector2 wheelMove = Vector2.Zero;
            if (mbe.ButtonIndex == MouseButton.WheelUp) {
                wheelMove.Y = -1;
            } else if (mbe.ButtonIndex == MouseButton.WheelDown) {
                wheelMove.Y = 1;
            }
            if (wheelMove != Vector2.Zero) {
                OnMove?.Invoke(wheelMove);
            }
        }
    }
}
