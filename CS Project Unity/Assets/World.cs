using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public bool autoUpdate = true;

    [Header("Chunk Settings")]
    public float chunkSize;
    [SerializeField] float chunkDensity;
    [SerializeField] float surfaceHeight;
    [SerializeField] bool interpolate;

    public ShapeSettings shapeSettings;
    public ColorSettings colorSettings;
    [HideInInspector] public bool shapeSettingsFoldout;
    [HideInInspector] public bool colorSettingsFoldout;

    /*[Header("Noise Settings")]
    [SerializeField] Vector3 noiseOffset;
    [SerializeField] float noiseScale;
    [SerializeField] bool weightY;
    [SerializeField] float noiseWeight;*/

    ShapeGenerator shapeGenerator;


    public void GenerateWorld()
    {
        UpdateTerrainChunksMesh();
        UpdateTerrainChunksColour();
    }

    void UpdateTerrainChunksMesh()
    {
        shapeGenerator = new ShapeGenerator(shapeSettings);

        TerrainChunk[] chunks = FindObjectsOfType<TerrainChunk>();
        foreach (TerrainChunk chunk in chunks)
        {
            chunk.GenerateMesh(shapeGenerator, chunkSize, chunkDensity, surfaceHeight, interpolate);
        }
    }

    public void UpdateTerrainChunksColour()
    {
        TerrainChunk[] chunks = FindObjectsOfType<TerrainChunk>();
        foreach (TerrainChunk chunk in chunks)
        {
            chunk.GenerateColors(colorSettings);
        }
    }

    public void UpdateTerrainChunk(TerrainChunk chunk)
    {
        shapeGenerator = new ShapeGenerator(shapeSettings);
        chunk.GenerateMesh(shapeGenerator, chunkSize, chunkDensity, surfaceHeight, interpolate);
        chunk.GenerateColors(colorSettings);
    }

    public void OnShapeSettingsUpdated()
    {
        if (autoUpdate)
            UpdateTerrainChunksMesh();
    }

    public void OnColorSettingsUpdated()
    {
        if (autoUpdate)
            UpdateTerrainChunksColour();
    }
}
