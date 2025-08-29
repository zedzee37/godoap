using Godot;
using Godot.Collections;

#nullable enable
public partial class GoobSprite : Sprite2D
{
	[Export] Array<ColorPair> colors = new Godot.Collections.Array<ColorPair>();
	
	public override void _Ready() 
	{
		Material material = this.Material;	
		if (material is ShaderMaterial shaderMaterial)
		{
			RandomNumberGenerator rng = new RandomNumberGenerator();
			rng.Randomize();
			
			ColorPair? pair = rng.Choice(colors);
			if (pair == null) 
			{
				return;
			}

			shaderMaterial.SetShaderParameter("main_color", pair.mainColor);
			shaderMaterial.SetShaderParameter("shadow_color", pair.shadowColor);
		}
	}
}
