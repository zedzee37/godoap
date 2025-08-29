using Godot;

public partial class Goal<T> : Node 
{
	public WorldState desiredState;
	private float basePriority;

	public Goal(WorldState desiredState, float basePriority) 
	{
		this.desiredState = desiredState; 
		this.basePriority = basePriority;
	}

	public virtual float GetPriority(WorldState state, T self)
	{
		return basePriority;		
	}
}

