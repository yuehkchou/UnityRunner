using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {

	private Transform playerTransform;

	// Z value where the tile spawn
	private float spawnZ= 0.0f;

	// Length of tile on Screen
	private float tileLength = 8.0f;

	// Number of Tiles on screen
	private int numTileOnScreen = 4;

	public GameObject[] tilePrefabs;
	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		for(int i = 0; i < numTileOnScreen; i++) {
			SpawnTile();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(playerTransform.position.z > (spawnZ - numTileOnScreen * tileLength)) {
			SpawnTile();
		}
	}

	void SpawnTile(int prefabInd = -1) {
		GameObject tileset;
		tileset = Instantiate(tilePrefabs[0]) as GameObject;
		tileset.transform.SetParent(this.transform);
		tileset.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
	}
}
