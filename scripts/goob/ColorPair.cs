using Godot;

[GlobalClass]
public partial class ColorPair : Resource
{
	[Export] public Color mainColor;
	[Export] public Color shadowColor;
}
