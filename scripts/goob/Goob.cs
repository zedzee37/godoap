using Godot;

public partial class Goob : Node2D
{
	private static Goal<Goob> testGoal = new Goal<Goob>(
				new WorldState.Builder()
					.Build(),
				0.2f
			);
	private Planner<Goob> planner = new Planner<Goob>.Builder()
		.Goal(testGoal)
		.Build();

	public override void _Ready()
	{
	}
}
