public abstract class Action<T>
{
	public WorldState PreConditions { get; set; }
	public WorldState DesiredOutcome { get; set; }

	public Action(WorldState preConditons, WorldState desiredOutcome)
	{
		PreConditions = preConditons;
		DesiredOutcome = desiredOutcome;
	}

	public abstract void Run(WorldState state, double delta, T self);
	public abstract bool IsActionComplete(WorldState state, double delta, T self);
}
