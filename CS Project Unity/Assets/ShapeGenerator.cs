using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    //float chunkSize;
    //float chunkDensity;
    //float surfaceHeight;
    //bool interpolate;

    Vector3 noiseOffset;
    float noiseScale;
    bool weightY;
    float noiseWeight;

    public ShapeGenerator(Vector3 noiseOffset, float noiseScale, bool weightY, float noiseWeight)
    {
        this.noiseOffset = noiseOffset;
        this.noiseScale = noiseScale;
        this.weightY = weightY;
        this.noiseWeight = noiseWeight;
    }

    public float EvaluateNoise(Vector3 worldPoint)
    {
        float n = Noise.Perlin3D(worldPoint, noiseOffset, noiseScale);
        if (weightY)
        {
            n = -worldPoint.y + n* noiseWeight;
        }
        return (n);
    }
}
