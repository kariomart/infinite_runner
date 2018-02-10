using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public static MapGenerator me;
	public GameObject baseTile;
	public GameObject wallTile;
	public GameObject moveTile;
	public GameObject goldTile;

	public int mapWidth;
	public int mapHeight;
	public int totalHeight;
	public GameObject map;
	public GameObject enemy;

	int offset = 1;
	//public int mapsGenerated;


	// Use this for initialization
	void Start () {

		if (me == null) {
			me = this;
		} else {
			Destroy (this);
		}

		map = new GameObject ("Map");
		Master.me.map = new TileController[mapWidth, mapHeight];

		GenerateMap ();
		//CheckPlayer ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GenerateMap() {

		Debug.Log ("new map generated");

		for (int x = 0; x < mapWidth; x++) {
			for (int y = (int)(PlayerMovement.me.pos.y) + offset; y < PlayerMovement.me.pos.y + mapHeight; y++) {

//				Debug.Log (x + " " + y);

				GameObject tile = DecideWhatToSpawn ();
				GameObject tempTile = Instantiate (tile, new Vector3 (x, y, 0), Quaternion.identity);
				tempTile.transform.parent = map.transform;
				//tempTile.GetComponentInChildren<SpriteRenderer> ().sortingOrder = -1;
				Master.me.tiles.Add (new Vector2(tempTile.transform.position.x, tempTile.transform.position.y), tempTile);
//				Master.me.map[x, y] = tempTile.GetComponent<TileController> ();
				TileController t = tempTile.GetComponent<TileController> ();
				t.pos = new Vector2 (x, y);
				Master.me.tileControllers.Add (tempTile.GetComponent<TileController> ());

			}
		}

		totalHeight += mapHeight;
			
	}

	public void CheckPlayer() {

//		Debug.Log ((int)PlayerMovement.me.pos.y % (mapHeight - offset));
		if ((int)PlayerMovement.me.pos.y % (mapHeight - offset) == 0 && !Master.me.tiles.ContainsKey(PlayerMovement.me.pos + Vector2.up)) {

			GenerateMap ();

		}

		GetTile (PlayerMovement.me.pos).TileEntered ();
		RevealTiles ();

	}

	public bool CheckTile(Vector2 pos) {

//		Debug.Log (pos);

		if (GetTile (pos).gameObject.tag == "Wall") {
			return false;
		}

		foreach (EnemyController e in Master.me.enemies) {

			if (pos == e.pos) {

				return false;

			}

		}
	
		return true;

	}

	void RevealTiles() {

		Vector2 pos = PlayerMovement.me.pos;

		GetTile (pos).RevealTile ();
		GetTile (new Vector2 (pos.x + 1, pos.y)).RevealTile ();
		GetTile (new Vector2 (pos.x - 1, pos.y)).RevealTile ();
		GetTile (new Vector2 (pos.x, pos.y + 1)).RevealTile ();
		GetTile (new Vector2 (pos.x, pos.y - 1)).RevealTile ();


	}

	public void RevealTiles(Vector2 pos) {

		GetTile (pos).RevealTile ();
		GetTile (new Vector2 (pos.x + 1, pos.y)).RevealTile ();
		GetTile (new Vector2 (pos.x - 1, pos.y)).RevealTile ();
		GetTile (new Vector2 (pos.x, pos.y + 1)).RevealTile ();
		GetTile (new Vector2 (pos.x, pos.y - 1)).RevealTile ();


	}

	public TileController GetTile(Vector2 pos) {

		return Master.me.tiles [pos].GetComponent<TileController> ();

	}

	GameObject DecideWhatToSpawn() {
		float r = Random.value;

		if (r > .8f) {
			return wallTile;
		} else {


			int rand = Random.Range (0, 1000);

			if (rand <= 800) {

				return baseTile;

			} else if (rand <= 900) {

				return moveTile;
			} else if (rand <= 1000) {

				return goldTile;
			} else {

				return baseTile;

			}
		}


	}

}
