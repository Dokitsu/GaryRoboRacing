using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilespawner : MonoBehaviour {

    public GameObject[] tilefabs;

    public Transform Sptarget;
    private float Zloc = -30;
    private float tileLength = 40f;
    private int dropoff = 6;

    private float inzone = 60f;
    private int lastfab = 0;

    private List<GameObject> actiles;

    // Use this for initialization
    void Start()
    {
        actiles = new List<GameObject>();


        for (int i = 0; i < dropoff; i++)
        {
            SPtile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Sptarget.position.z - inzone > (Zloc - dropoff * tileLength))
        {
            SPtile();
            Deletile();
        }
    }

    private void SPtile(int tiles = -1)
    {
        GameObject Tile;

        if (tiles == -1)
        {
            Tile = Instantiate(tilefabs[Randomfab()]) as GameObject;
        }
        else
        {
            Tile = Instantiate(tilefabs[tiles]) as GameObject;
        }

        //Tile = Instantiate(tilefabs[0]) as GameObject;
        Tile.transform.SetParent(transform);
        Tile.transform.position = Vector3.forward * Zloc;
        Zloc += tileLength;

        actiles.Add(Tile);
    }

    private void Deletile()
    {
        Destroy(actiles[0]);
        actiles.RemoveAt(0);
    }

    private int Randomfab()
    {
        if (tilefabs.Length <= 1)
            return 0;

        int random = lastfab;
        //while (random == lastfab)
        //{
            random = Random.Range(0, tilefabs.Length);
        //}

        lastfab = random;
        return random;
    }
}


