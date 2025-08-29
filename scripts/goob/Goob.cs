using Godot;

public partial class Goob : Node2D, IStateProvider<GoobState>
{
	[Export] private float speed;
	[Export] private float distanceThreshold = 2.0f;

	private NavigationAgent2D navAgent;
	private Sprite2D sprite;
	private AnimationPlayer animPlayer;

	public override void _Ready()
	{
		navAgent = GetNode<NavigationAgent2D>("NavigationAgent2D");
		sprite = GetNode<Sprite2D>("GooberSprite");
		animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public override void _Process(double delta)
	{
		navAgent.TargetPosition = GetGlobalMousePosition();

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
	}

	public GoobState GetState()
	{
		return new GoobState();
	}

}
