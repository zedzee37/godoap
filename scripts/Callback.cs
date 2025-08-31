using System;

// basically a delegate that also stores a ref to the thing that adds the callback
public class Callback<T> where T : Delegate
{
	private T callback;
	private object owner;

	public void SetCallback(object owner, T callback)
	{
		this.owner = owner;
		this.callback = callback;
	}

	public T GetCallback()
	{
		return this.callback;
	}

	public object GetOwner()
	{
		return this.owner;
	}
}
