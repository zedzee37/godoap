using System.Collections.Generic;

#nullable enable
public class ActionNode<T>
{
	public WorldState state;
	public Action<T>? action;
	private List<ActionNode<T>> children;

	public ActionNode(WorldState state)
	{
		this.state = state;
		this.action = null;
		this.children = new List<ActionNode<T>>();
	}

	public ActionNode(Action<T> action, WorldState state)
	{
		this.state = state;
		this.action = action;
		this.children = new List<ActionNode<T>>();
	}

	public float Cost(WorldState state, T self)
	{
		return this.action == null ? 0 : this.action.Cost(state, self);
	}

	public void AddChild(ActionNode<T> node)
	{
		this.children.Add(node);
	}

	public ActionNode<T>? GetChild(int i)
	{
		if (i >= children.Count || i < 0)
		{
			return null;
		}

		return children[i];
	}
}
