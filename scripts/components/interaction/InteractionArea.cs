using Godot;

[GlobalClass]
public partial class InteractionArea : Area2D
{
	[Export]
	public InteractionType type;

    public delegate InteractionResult InteractedEventHandler();
	private InteractedEventHandler handler;

    public InteractionResult Interact()
    {
		return handler.Invoke();
    }

	public void SetCallback(InteractedEventHandler handler)
	{
		this.handler = handler;
	}
}
