using Godot;
using Godot.Collections;

#nullable enable
public static class RngExtensions
{
    public static T? Choice<[MustBeVariant] T>(this RandomNumberGenerator rng, Array<T> array)
    {
        if (array == null || array.Count == 0)
			return default;

        int index = rng.RandiRange(0, array.Count - 1);
        return array[index];
    }
}
