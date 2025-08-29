using System.Collections.Generic;

public class Planner<T>
{
	private List<Action<T>> actions;
	private List<Goal<T>> goals;

	private Planner(List<Action<T>> actions, List<Goal<T>> goals) 
	{
		this.actions = actions;
		this.goals = goals;
	}

	public class Builder 
	{
		private List<Action<T>> actions;
		private List<Goal<T>> goals;

		public Builder() 
		{
			actions = new List<Action<T>>();
			goals = new List<Goal<T>>();
		}

		public Builder Action(Action<T> action)
		{
			this.actions.Add(action);
			return this;
		}

		public Builder Goal(Goal<T> goal)
		{
			this.goals.Add(goal);
			return this;
		}

		public Planner<T> Build()
		{
			return new Planner<T>(this.actions, this.goals);
		}
	}
}
