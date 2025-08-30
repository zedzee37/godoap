#nullable enable
public struct GoobState : IWorldState<GoobState>
{
	bool foundTree;

	public GoobState(bool foundTree)
	{
		this.foundTree = foundTree;
	}

	public bool Matches(GoobState other)
	{
		return foundTree == other.foundTree;					
	}
}
