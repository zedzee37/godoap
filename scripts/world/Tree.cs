using Godot;
using Godot.Collections;

public partial class Tree : Node2D, ISceneTracker<Tree>
{
	private InteractionArea interactionArea;

	private static Array<Tree> trees = new Array<Tree>();

	public override void _EnterTree()
	{
		trees.Add(this);
	}

	public override void _ExitTree()
	{
		trees.Remove(this);
	}

	public override void _Ready()
	{
		interactionArea = GetNode<InteractionArea>("InteractionArea");
		interactionArea.SetCallback(this, () => {
					interactionArea.CanInteract = false;
					GD.Print("gug i got called");
					return new InteractionResult();
				});
	}

	public static Array<Tree> GetInstances()
	{
		return trees;
	}
}
