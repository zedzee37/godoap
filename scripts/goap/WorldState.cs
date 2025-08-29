#nullable enable
public interface IWorldState<W> where W : struct
{
	bool Matches(W state);
}
