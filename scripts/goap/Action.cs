public abstract class Action<W, T> where W : struct, IWorldState<W>
{
	public W PreConditions { get; set; }
	public W DesiredOutcome { get; set; }

	public Action(W preConditions, W desiredOutcome)
	{
		PreConditions = preConditions;
		DesiredOutcome = desiredOutcome;
	}

	public bool IsAvailable(W state)
	{
		return state.Matches(this.PreConditions);
	}

	public abstract void Run(W state, double delta, T self);
	public abstract bool IsActionComplete(W state);
	public abstract float Cost(W state);
}
