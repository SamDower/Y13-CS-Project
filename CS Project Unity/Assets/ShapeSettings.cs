using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShapeSettings : ScriptableObject
{
    public Vector3 noiseOffset;
    public float noiseScale = 20f;
    public bool weightY = false;
    public float yOffset = 0f;
    public bool lockSeaLevel = false;
    public float seaLevel = 0f;
    public float noiseWeight = 50f;
    public int octaves = 2;
    public float persistance = 0.7f;
    public float lacunarity = 2f;
}
