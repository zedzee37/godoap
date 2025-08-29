shader_type canvas_item;

uniform vec4 temp_main_color : source_color;
uniform vec4 temp_shadow_color : source_color;

uniform vec4 main_color : source_color;
uniform vec4 shadow_color : source_color;

const float threshold = 0.01;

void fragment() {
	vec4 tex_color = texture(TEXTURE, UV);

	if (distance(tex_color, temp_main_color) < threshold) {
		COLOR = main_color;
	} else if (distance(tex_color, temp_shadow_color) < threshold) {
		COLOR = shadow_color;
	} else {
		COLOR = tex_color;
	}
}

//void light() {
//	// Called for every pixel for every light affecting the CanvasItem.
//	// Uncomment to replace the default light processing function with this one.
//}
