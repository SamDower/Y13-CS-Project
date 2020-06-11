using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    [Header("Chunk Settings")]
    [SerializeField] float chunkSize;
    [SerializeField] float chunkDensity;
    [SerializeField] float surfaceHeight;
    [SerializeField] bool interpolate;

    [Header("Noise Settings")]
    [SerializeField] Vector3 noiseOffset;
    [SerializeField] float noiseScale;
    [SerializeField] bool weightY;
    [SerializeField] float noiseWeight;

    ShapeGenerator shapeGenerator;


    // Updates the chunks whenever a value is changed in the inspector
    private void OnValidate()
    {
        UpdateTerrainChunks();
    }

    void UpdateTerrainChunks()
    {
        shapeGenerator = new ShapeGenerator(noiseOffset, noiseScale, weightY, noiseWeight);

        TerrainChunk[] chunks = FindObjectsOfType<TerrainChunk>();
        foreach (TerrainChunk chunk in chunks)
        {
            chunk.GenerateMesh(shapeGenerator, chunkSize, chunkDensity, surfaceHeight, interpolate);
        }
    }
}
