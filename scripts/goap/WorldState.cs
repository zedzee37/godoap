#nullable enable
public struct WorldState
{

	public bool Matches(WorldState other) {
		// if (other.goobCount.HasValue && this.goobCount != other.goobCount) {
		// 	return false;
		// }

		// if (other.treeCount.HasValue && this.treeCount != other.treeCount) {
		// 	return false;
		// }
		
		return true;
	}

	public class Builder 
	{
		private WorldState _currentState;

		public Builder() 
		{
			_currentState = new WorldState();
		}

		// public Builder GoobCount(int goobCount) {
		// 	_currentState.goobCount = goobCount;
		// 	return this;
		// }

		// public Builder TreeCount(int treeCount) 
		// {
		// 	_currentState.treeCount = treeCount;
		// 	return this;
		// }

		public WorldState Build() 
		{
			return _currentState;
		}
	}
}
