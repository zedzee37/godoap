using Godot;
using Godot.Collections;

public partial class Goob : Node2D, IStateProvider<GoobState>
{
	[Export] private float speed;
	[Export] private float distanceThreshold = 2.0f;

	private NavigationAgent2D navAgent;
	private Sprite2D sprite;
	private AnimationPlayer animPlayer;
	private InteractorArea interactorArea;

	public override void _Ready()
	{
		navAgent = GetNode<NavigationAgent2D>("NavigationAgent2D");
		sprite = GetNode<Sprite2D>("GooberSprite");
		animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		interactorArea = GetNode<InteractorArea>("InteractorArea");
	}

	public override void _Process(double delta)
	{
		Array<Tree> trees = Tree.GetInstances();

		float closestDistance = 100000000.0f;
		Tree closestTree = null;
		foreach (Tree tree in trees)
		{
			float distance = GlobalPosition.DistanceTo(tree.GlobalPosition);
			
			if (distance < closestDistance)
			{
				closestDistance = distance;
				closestTree = tree;
			}
		}

		if (closestTree != null)
		{
			navAgent.TargetPosition = closestTree.GlobalPosition;
		}

		if (Position.DistanceTo(navAgent.TargetPosition) > distanceThreshold)
		{
			Vector2 dir = Position.DirectionTo(navAgent.GetNextPathPosition());
			Position += dir * speed * (float)delta;

			sprite.FlipH = dir.X < 0;
			animPlayer.Play("move");
		}
		else
		{
			animPlayer.Stop();
		}

		if (interactorArea.GetTarget() is Tree) 
		{
			interactorArea.Interact();
		}
	}

	public GoobState GetState()
	{
		return new GoobState();
	}
}
