using System.Collections.Generic;
using System.Linq;

#nullable enable
public class Planner<W, T> where W : struct, IWorldState<W>
{
	private List<Action<W, T>> actions;
	private List<Goal<W>> goals;
	private Goal<W>? currentGoal;

	private Planner(List<Action<W, T>> actions, List<Goal<W>> goals) 
	{
		this.actions = actions;
		this.goals = goals;
		currentGoal = null;
	}

	private Goal<W>? GetHighestPriorityGoal(W state)
	{
		Goal<W>? goal = currentGoal;
		float currentPriority = currentGoal != null ? currentGoal.GetPriority(state) : 0.0F;

		this.goals.ForEach(newGoal =>
				{
					float priority = newGoal.GetPriority(state);
					if (priority > currentPriority)
					{
						goal = newGoal;
						currentPriority = priority;
					}
				}
		);

		return goal;
	}

	private ActionNode<W, T> PlanActions(W state)
	{
		ActionNode<W, T> head = new ActionNode<W, T>(state);
		BuildActionTree(head);
		return head;
	}

	private void BuildActionTree(ActionNode<W, T> parent)
	{
		List<Action<W, T>> availableActions = GetActionsForState(parent.state);	
		availableActions.ForEach(action => {
				W outcome = action.DesiredOutcome;
				
				if (currentGoal == null)
				{
					return;
				}

				ActionNode<W, T> node = new ActionNode<W, T>(action, outcome);

				parent.AddChild(node);
				if (!currentGoal.GoalComplete(outcome))
				{
					BuildActionTree(node);
				}
		});
	}

	private List<Action<W, T>> GetActionsForState(W state)
	{
		return (from action in actions
				where action.IsAvailable(state)
				select action).ToList();
	}

	public class Builder 
	{
		private List<Action<W, T>> actions;
		private List<Goal<W>> goals;

		public Builder() 
		{
			actions = new List<Action<W, T>>();
			goals = new List<Goal<W>>();
		}

		public Builder Action(Action<W, T> action)
		{
			this.actions.Add(action);
			return this;
		}

		public Builder Goal(Goal<W> goal)
		{
			this.goals.Add(goal);
			return this;
		}

		public Planner<W, T> Build()
		{
			return new Planner<W, T>(this.actions, this.goals);
		}
	}
}
