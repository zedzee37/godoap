using Godot;

public partial class Goal<W> : Node where W : struct, IWorldState<W>
{
	public W desiredState;
	private float basePriority;

	public Goal(W desiredState, float basePriority) 
	{
		this.desiredState = desiredState; 
		this.basePriority = basePriority;
	}

	public virtual float GetPriority(W state)
	{
		return basePriority;		
	}
	
	public bool GoalComplete(W newState)
	{
		return newState.Matches(desiredState);
	}
}

