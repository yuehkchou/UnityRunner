using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {

    // Array for injecting new Prefabs
    public GameObject[] tilePrefabs;

    private Transform playerTransform;

    // Z value where the tile spawn
    private float spawnZ= -40.0f;

	// Length of tile on Screen
	private float tileLength = 11.0f;

	// Number of Tiles on screen
	private int numTilesOnScreen = 4;

    // Creating a zone of
    private float safeZone = 25.0f;

    // Store Tileset
    private List<GameObject> activeTiles;


	// Use this for initialization
	void Start () {
        activeTiles = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		for(int i = 0; i < numTilesOnScreen; i++) {
			SpawnTile();
		}
	}

	// Update is called once per frame
	private void Update () {
        if (playerTransform.position.z - safeZone > (spawnZ - numTilesOnScreen * tileLength)) {
			SpawnTile();
            RemoveTile();
		}
	}

	private void SpawnTile(int prefabInd = -1) {
		GameObject tileset;
		tileset = Instantiate(tilePrefabs[0]) as GameObject;
		tileset.transform.SetParent(transform);
		tileset.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
        activeTiles.Add(tileset);
	}

	private void RemoveTile() {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
	}
}
