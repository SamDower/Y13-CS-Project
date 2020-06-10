using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise 
{
    public static float Perlin3D(Vector3 point, Vector3 offset, float scale)
    {
        float ab = Mathf.PerlinNoise((point.x + offset.x) / scale, (point.y + offset.y) / scale);
        float bc = Mathf.PerlinNoise((point.y + offset.y) / scale, (point.z + offset.z) / scale);
        float ac = Mathf.PerlinNoise((point.x + offset.x) / scale, (point.z + offset.z) / scale);

        float ba = Mathf.PerlinNoise((point.y + offset.y) / scale, (point.x + offset.x) / scale);
        float cb = Mathf.PerlinNoise((point.z + offset.z) / scale, (point.y + offset.y) / scale);
        float ca = Mathf.PerlinNoise((point.z + offset.z) / scale, (point.x + offset.x) / scale);

        float abc = ab + bc + ac + ba + cb + ca;
        return abc / 6f;
    }
}
