using UnityEngine;

[ExecuteAlways]
public class GreenTextureCreator : MonoBehaviour
{
    public Terrain terrain;
    public Color greenColor = new Color(0.31f, 0.55f, 0.25f); // Verde estándar

    void Start()
    {
        if (terrain == null) terrain = GetComponent<Terrain>();

        // Crear nueva textura
        Texture2D greenTexture = new Texture2D(512, 512);
        Color[] pixels = greenTexture.GetPixels();

        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = greenColor;
        }

        greenTexture.SetPixels(pixels);
        greenTexture.Apply();

        // Crear y asignar Terrain Layer
        TerrainLayer greenLayer = new TerrainLayer();
        greenLayer.diffuseTexture = greenTexture;
        greenLayer.tileSize = new Vector2(50, 50);

        terrain.terrainData.terrainLayers = new TerrainLayer[] { greenLayer };
    }
}
