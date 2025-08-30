using Godot;

#nullable enable
[GlobalClass]
public partial class InteractionArea : Area2D
{
    public delegate InteractionResult InteractedEventHandler();
	private InteractedEventHandler? handler;

	public object? GetTarget()
	{
		if (handler == null)
		{
			return null;
		}

		return handler.Target;
	}

    public InteractionResult? Interact()
    {
		if (handler == null)
		{
			return null;
		}

		return handler.Invoke();
    }

	public void SetCallback(InteractedEventHandler handler)
	{
		this.handler = handler;
	}
}
