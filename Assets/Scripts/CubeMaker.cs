using UnityEngine;

public class CubeMaker : MonoBehaviour
{
    public Material cubeMaterial;

    float width = 1f;
    float height = 1f;
    float thick = 1f;

    void Start()
    {
        Mesh mesh = new Mesh();
        var vertices = new Vector3[24];
        var uvs = new Vector2[vertices.Length];

        // Load Texture
        Texture myTexture = Resources.Load<Texture>("Textures/Week04-Tutorial");

        // Set Texture to Material
        cubeMaterial.mainTexture = myTexture;

        // First surface towards X-positive (Wood texture)
        vertices[0] = new Vector3(width, height, thick);
        vertices[1] = new Vector3(width, -height, thick);
        vertices[2] = new Vector3(width, height, -thick);
        vertices[3] = new Vector3(width, -height, -thick);

        uvs[0] = new Vector2(0.5f, 1.0f);
        uvs[1] = new Vector2(0.5f, 0.5f);
        uvs[2] = new Vector2(0.75f, 1.0f);
        uvs[3] = new Vector2(0.75f, 0.5f);

        // Second surface towards Y-positive (White grid texture)
        vertices[4] = new Vector3(-width, height, -thick);
        vertices[5] = new Vector3(-width, height, thick);
        vertices[6] = new Vector3(width, height, -thick);
        vertices[7] = new Vector3(width, height, thick);

        uvs[4] = new Vector2(0.75f, 0.5f);
        uvs[5] = new Vector2(1.0f, 0.5f);
        uvs[6] = new Vector2(0.75f, 0.25f);
        uvs[7] = new Vector2(1.0f, 0.25f);

        // Third surface towards Z-positive (Metal sheet texture)
        vertices[8] = new Vector3(width, height, thick);
        vertices[9] = new Vector3(-width, height, thick);
        vertices[10] = new Vector3(width, -height, thick);
        vertices[11] = new Vector3(-width, -height, thick);

        uvs[8] = new Vector2(0f, 1.0f);
        uvs[9] = new Vector2(0.25f, 1.0f);
        uvs[10] = new Vector2(0f, 0.5f);
        uvs[11] = new Vector2(0.25f, 0.5f);

        // Fourth surface towards X-negative (Brick texture)
        vertices[12] = new Vector3(-width, height, thick);
        vertices[13] = new Vector3(-width, -height, thick);
        vertices[14] = new Vector3(-width, height, -thick);
        vertices[15] = new Vector3(-width, -height, -thick);

        uvs[12] = new Vector2(0.25f, 1.0f);
        uvs[13] = new Vector2(0.25f, 0.5f);
        uvs[14] = new Vector2(0.5f, 1.0f);
        uvs[15] = new Vector2(0.5f, 0.5f);

        // Fifth surface towards Y-negative (Stone texture)
        vertices[16] = new Vector3(width, -height, thick);
        vertices[17] = new Vector3(-width, -height, thick);
        vertices[18] = new Vector3(width, -height, -thick);
        vertices[19] = new Vector3(-width, -height, -thick);

        uvs[16] = new Vector2(0.25f, 0.5f);
        uvs[17] = new Vector2(0.5f, 0.5f);
        uvs[18] = new Vector2(0.25f, 0.25f);
        uvs[19] = new Vector2(0.5f, 0.25f);

        // Sixth surface towards Z-negative (Ice texture)
        vertices[20] = new Vector3(width, height, -thick);
        vertices[21] = new Vector3(-width, height, -thick);
        vertices[22] = new Vector3(width, -height, -thick);
        vertices[23] = new Vector3(-width, -height, -thick);

        uvs[20] = new Vector2(0.5f, 0.5f);
        uvs[21] = new Vector2(0.75f, 0.5f);
        uvs[22] = new Vector2(0.5f, 0.25f);
        uvs[23] = new Vector2(0.75f, 0.25f);

        mesh.vertices = vertices;
        mesh.uv = uvs;

        mesh.triangles = new int[] {
            0,1,2, 1,3,2, // First Surface towards X Positive 
            4,5,6, 6,5,7, // Second Surface towards Y Positive 
            8,9,10, 10,9,11, // Third Surface towards Z Positive 
            13,12,15, 15,12,14, // Fourth Surface towards X Negative 
            16,17,18, 18,17,19, // Fifth Surface towards Y Negative 
            20,23,21, 20,22,23 // Sixth Surface towards Z Negative
        };
        
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material = cubeMaterial;
    }
}