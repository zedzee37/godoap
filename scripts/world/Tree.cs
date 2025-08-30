using Godot;
using Godot.Collections;

public partial class Tree : Node2D, ISceneTracker<Tree>
{
	private static Array<Tree> trees = new Array<Tree>();

	public override void _EnterTree()
	{
		trees.Add(this);
	}

	public override void _ExitTree()
	{
		trees.Remove(this);
	}

	public Array<Tree> GetInstances()
	{
		return trees;
	}
}
