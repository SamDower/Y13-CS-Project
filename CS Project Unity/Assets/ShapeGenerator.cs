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
        if (settings.lockSeaLevel)
            if (worldPoint.y <= settings.seaLevel)
                return (10000f);

        float n = Noise.Perlin3D(worldPoint, settings.noiseOffset, settings.noiseScale, settings.octaves, settings.persistance, settings.lacunarity) * settings.noiseWeight;
        if (settings.weightY)
        {
            n = -worldPoint.y + settings.yOffset + n;
        }
        return (n);
    }
}
