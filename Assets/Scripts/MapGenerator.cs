using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public GameObject baseTile;
	public GameObject moveTile;
	public int mapWidth;
	public int mapHeight;


	// Use this for initialization
	void Start () {

		GenerateMap ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GenerateMap() {

		GameObject map = new GameObject ("Map");
		Master.me.map = new TileController[mapWidth, mapHeight];

		for (int x = 0; x < mapWidth; x++) {
			for (int y = 0; y < mapHeight; y++) {

				GameObject tile = DecideWhatToSpawn ();
				GameObject tempTile = Instantiate (tile, new Vector3 (x, y, 0), Quaternion.identity);
				tempTile.transform.parent = map.transform;
				tempTile.GetComponentInChildren<SpriteRenderer> ().sortingOrder = -1;
				Master.me.tiles.Add (tempTile);
				Master.me.map[x, y] = tempTile.GetComponent<TileController> ();
				Master.me.tileControllers.Add (tempTile.GetComponent<TileController> ());

			}
		}

	}

	GameObject DecideWhatToSpawn() {

		int rand = Random.Range (0, 100);

		if (rand <= 80) {

			return baseTile;

		} else {

			return moveTile;
		}


	}
}
