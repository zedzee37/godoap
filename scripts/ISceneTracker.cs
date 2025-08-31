using Godot;
using System.Collections.Generic;

public interface ISceneTracker<[MustBeVariant] T> where T : Node
{
	static abstract HashSet<T> GetInstances();
}
