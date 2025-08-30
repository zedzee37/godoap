using Godot;
using Godot.Collections;

public interface ISceneTracker<T> where T : Node
{
	Array<T> GetInstances();
}
