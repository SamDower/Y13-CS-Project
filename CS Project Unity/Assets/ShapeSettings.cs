using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShapeSettings : ScriptableObject
{
    public Vector3 noiseOffset;
    public float noiseScale = 20f;
    public bool weightY = false;
    public float noiseWeight = 50f;
}
