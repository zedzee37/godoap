using Godot;

[GlobalClass]
public partial class InteractionArea : Area2D
{
    [Signal]
    public delegate void InteractedEventHandler();

    public void Interact()
    {
        EmitSignal(SignalName.Interacted);
    }
}
