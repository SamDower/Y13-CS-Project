using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSettings settings;

    public ShapeGenerator(ShapeSettings settings)
    {
        this.settings = settings;
    }

    public float EvaluateNoise(Vector3 worldPoint)
    {
        float n = Noise.Perlin3D(worldPoint, settings.noiseOffset, settings.noiseScale) * settings.noiseWeight;
        if (settings.weightY)
        {
            n = -worldPoint.y + n;
        }
        return (n);
    }
}
