#version 330 core
out vec4 FragColor;

in vec2 TexCoord;
in vec3 Normal;
in vec3 FragPos;

struct DirectionalLight {
    vec3 direction;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

struct Material {
    sampler2D texture_diffuse1;
    sampler2D texture_specular1;

    float shininess;
};
uniform Material material;

uniform sampler2D texture_diffuse1;
uniform sampler2D texture_specular1;
uniform DirectionalLight directionalLight;
uniform vec3 viewPosition;

vec3 CalcDirLight(DirectionalLight light, vec3 normal, vec3 viewDir)
{
    vec3 lightDir = normalize(-light.direction);
    float diff = max(dot(normal, lightDir), 0.0);

    vec3 reflectDir = reflect(-lightDir, normal);

    float spec = pow(max(dot(viewDir, reflectDir), 0.0), 0.3f);

    vec3 ambient = light.ambient * vec3(texture(texture_diffuse1, TexCoord));

    vec3 diffuse = light.diffuse * vec3(texture(texture_diffuse1, TexCoord));

    vec3 specular = light.specular * vec3(texture(texture_specular1, TexCoord));

    return (ambient + diffuse + specular);
}

void main()
{

    vec3 normal = normalize(Normal);
    vec3 viewDir = normalize(viewPosition - FragPos);
    vec3 result = CalcDirLight(directionalLight, normal, viewDir);

    //FragColor = texture(texture_diffuse1, TexCoord);
    FragColor = vec4(result, 1.0);
}