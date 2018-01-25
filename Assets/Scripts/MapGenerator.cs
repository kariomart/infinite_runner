using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public GameObject baseTile;
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

		for (int x = 0; x < mapWidth; x++) {
			for (int y = 0; y < mapHeight; y++) {

				DecideWhatToSpawn ();
				GameObject tempTile = Instantiate (baseTile, new Vector3 (x, y, 0), Quaternion.identity);
				tempTile.transform.parent = map.transform;
				tempTile.GetComponentInChildren<SpriteRenderer> ().sortingOrder = -1;
				Master.me.tiles.Add (tempTile);

			}
		}

	}

	void DecideWhatToSpawn() {



	}
}
