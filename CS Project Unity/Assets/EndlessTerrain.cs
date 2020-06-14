using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTerrain : MonoBehaviour
{
    public const float maxViewDst = 200;
    [SerializeField] Transform viewer;
    [SerializeField] GameObject terrainChunkPrefab;

    float chunkSize;
    int chunksVisibleInViewDst;

    Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();
    List<TerrainChunk> terrainChunksVisibleLastFrame = new List<TerrainChunk>();

    void Start()
    {
        chunkSize = GetComponent<World>().chunkSize;
        chunksVisibleInViewDst = Mathf.RoundToInt(maxViewDst / chunkSize);
    }

    private void Update()
    {
        UpdateVisibleChunks();
    }

    void UpdateVisibleChunks()
    {
        foreach (TerrainChunk chunk in terrainChunksVisibleLastFrame)
        {
            chunk.gameObject.SetActive(false);
        }
        terrainChunksVisibleLastFrame.Clear();

        int currentChunkCoordX = Mathf.RoundToInt(viewer.position.x / chunkSize);
        int currentChunkCoordZ = Mathf.RoundToInt(viewer.position.z / chunkSize);

        for (int offsetX = -chunksVisibleInViewDst; offsetX <= chunksVisibleInViewDst; offsetX++)
        {
            for (int offsetZ = -chunksVisibleInViewDst; offsetZ <= chunksVisibleInViewDst; offsetZ++)
            {
                Vector2 chunkCoord = new Vector2(currentChunkCoordX + offsetX, currentChunkCoordZ + offsetZ);

                if (terrainChunkDictionary.ContainsKey(chunkCoord))
                {
                    Bounds chunkBounds = new Bounds(chunkCoord * chunkSize, Vector2.one * chunkSize);
                    float viewerDistanceFromNearestEdge = Mathf.Sqrt(chunkBounds.SqrDistance(new Vector2(viewer.position.x, viewer.position.z)));
                    bool visible = viewerDistanceFromNearestEdge <= maxViewDst;
                    terrainChunkDictionary[chunkCoord].gameObject.SetActive(visible);
                } else
                {
                    GameObject instance = Instantiate(terrainChunkPrefab, new Vector3(chunkCoord.x * chunkSize, 0f, chunkCoord.y * chunkSize), Quaternion.identity);
                    GetComponent<World>().UpdateTerrainChunk(instance.GetComponent<TerrainChunk>());
                    terrainChunkDictionary.Add(chunkCoord, instance.GetComponent<TerrainChunk>());
                }
                terrainChunksVisibleLastFrame.Add(terrainChunkDictionary[chunkCoord]);
            }
        }
    }
}
