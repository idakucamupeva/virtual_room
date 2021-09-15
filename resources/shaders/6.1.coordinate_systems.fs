#version 330 core
out vec4 FragColor;

in vec2 TexCoord;
in float h;
in vec3 Normal;

// texture samplers
uniform sampler2D texture1;
uniform sampler2D texture2;

void main()
{		
	if(Normal.y > -0.9)
		FragColor = texture(texture1, TexCoord);
	else
		FragColor = texture(texture2, TexCoord);	
	// FragColor = texture(texture1, TexCoord);
}