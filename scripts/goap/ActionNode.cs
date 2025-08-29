using System.Collections.Generic;

#nullable enable
public class ActionNode<W, T> where W : struct, IWorldState<W>
{
	public W state;
	public Action<W, T>? action;
	private List<ActionNode<W, T>> children;

	public ActionNode(W state)
	{
		this.state = state;
		this.action = null;
		this.children = new List<ActionNode<W, T>>();
	}

	public ActionNode(Action<W, T> action, W state)
	{
		this.state = state;
		this.action = action;
		this.children = new List<ActionNode<W, T>>();
	}

	public float Cost(W state)
	{
		return this.action == null ? 0 : this.action.Cost(state);
	}

	public void AddChild(ActionNode<W, T> node)
	{
		this.children.Add(node);
	}

	public ActionNode<W, T>? GetChild(int i)
	{
		if (i >= children.Count || i < 0)
		{
			return null;
		}

		return children[i];
	}
}
