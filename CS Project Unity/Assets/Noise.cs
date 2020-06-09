using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise 
{
    public static float Perlin3D(float x, float y, float z, Vector3 offset, float scale)
    {
        float ab = Mathf.PerlinNoise((x + offset.x) / scale, (y + offset.y) / scale);
        float bc = Mathf.PerlinNoise((y + offset.y) / scale, (z + offset.z) / scale);
        float ac = Mathf.PerlinNoise((x + offset.x) / scale, (z + offset.z) / scale);

        float ba = Mathf.PerlinNoise((y + offset.y) / scale, (x + offset.x) / scale);
        float cb = Mathf.PerlinNoise((z + offset.z) / scale, (y + offset.y) / scale);
        float ca = Mathf.PerlinNoise((z + offset.z) / scale, (x + offset.x) / scale);

        float abc = ab + bc + ac + ba + cb + ca;
        return abc / 6f;
    }
}
