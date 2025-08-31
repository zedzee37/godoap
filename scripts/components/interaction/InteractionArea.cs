using Godot;

#nullable enable
[GlobalClass]
public partial class InteractionArea : Area2D
{
	[Export] public bool CanInteract { get; set; }

    public delegate InteractionResult InteractedEventHandler();
	private Callback<InteractedEventHandler> interactedCallback = new Callback<InteractedEventHandler>();

	public object? GetTarget()
	{
		if (interactedCallback.GetOwner() == null)
		{
			return null;
		}
		
		return interactedCallback.GetOwner();
	}

    public InteractionResult? Interact()
    {
		if (interactedCallback.GetCallback() == null || !CanInteract)
		{
			return null;
		}

		return interactedCallback.GetCallback().Invoke();
    }

	public void SetCallback(object owner, InteractedEventHandler handler)
	{
		interactedCallback.SetCallback(owner, handler);
	}
}
