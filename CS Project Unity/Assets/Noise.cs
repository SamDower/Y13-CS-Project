using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise 
{
    public static float Perlin3D(Vector3 point, Vector3 offset, float scale, int octaves, float persistance, float lacunarity)
    {
        float amplitude = 1f;
        float frequency = 1f;
        float noiseVal = 0;

        for (int i = 0; i < octaves; i++)
        {

            float ab = Mathf.PerlinNoise((point.x + offset.x) / scale * frequency, (point.y + offset.y) / scale * frequency);
            float bc = Mathf.PerlinNoise((point.y + offset.y) / scale * frequency, (point.z + offset.z) / scale * frequency);
            float ac = Mathf.PerlinNoise((point.x + offset.x) / scale * frequency, (point.z + offset.z) / scale * frequency);

            float ba = Mathf.PerlinNoise((point.y + offset.y) / scale * frequency, (point.x + offset.x) / scale * frequency);
            float cb = Mathf.PerlinNoise((point.z + offset.z) / scale * frequency, (point.y + offset.y) / scale * frequency);
            float ca = Mathf.PerlinNoise((point.z + offset.z) / scale * frequency, (point.x + offset.x) / scale * frequency);

            float perlinValue = (ab + bc + ac + ba + cb + ca) / 6f;
            noiseVal += perlinValue * amplitude;

            amplitude *= persistance;
            frequency *= lacunarity;
        }

        return (noiseVal);
    }
}
