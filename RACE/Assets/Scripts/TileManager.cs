using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // array of prefabs need spawning
    public GameObject[] TilePrefabs;

    //variables for spawning
    private Transform playerTransform;
    private float spawnZ = 80f;
    private float tileLength = 80.0f;
    private int numOfTiles = 3;

    //spawning random tiles
    private int lastPrefabIndex = 0;
    private List<GameObject> activeTiles;

    // Use this for initialization
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Campos").transform;

        for (int i = 0; i < numOfTiles; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > (spawnZ + 120 - numOfTiles * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }
    //method that spawns the tiles
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(TilePrefabs[RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }
    //method that deletes tiles
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    //method that picks randomly one of the prefabs in the prefabs array
    private int RandomPrefabIndex()
    {
        if (TilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, TilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
