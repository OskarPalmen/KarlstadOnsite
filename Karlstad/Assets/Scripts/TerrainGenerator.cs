using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject terrainTilePrefab;
    public int numberOfTiles = 20;
    public float tileWidth = 1f;
    public float maxHeight = 2f;
    public float minHeight = 0.5f;

    private float currentHeight = 0f;
    private Vector3 currentPosition = Vector3.zero;

    void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            GameObject tile = Instantiate(terrainTilePrefab);
            tile.transform.position = currentPosition;
            currentHeight += Random.Range(minHeight, maxHeight);
            tile.transform.position += new Vector3(0f, currentHeight, currentPosition.z);
            currentPosition += new Vector3(0f, 0f, tileWidth);
        }
    }
}

