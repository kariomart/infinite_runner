using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public static MapGenerator me;
	public GameObject baseTile;
	public GameObject wallTile;
	public GameObject trapTile;
	public GameObject moveTile;
	public GameObject goldTile;
	public GameObject visionTile;
	public GameObject attackTile;
	public GameObject wallBreakTile;
	public GameObject teleportTile;

	public GameObject heart;

	public int mapWidth;
	public int mapHeight;
	public int totalHeight;
	public GameObject map;
	public GameObject enemy;

	int offset = 1;
	List<GameObject> tileTypes = new List<GameObject>();


	// Use this for initialization
	void Start () {

		if (me == null) {
			me = this;
		} else {
			Destroy (this);
		}

		map = new GameObject ("Map");
		Master.me.map = new TileController[mapWidth, mapHeight];
		AddTileTypes ();
		GenerateMap ();
		PlayerMovement.me.MovePlayer (new Vector2 (mapWidth / 2, 1));
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

				GameObject tile = DecideWhatToSpawn (x, y);
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

		if (pos == PlayerMovement.me.pos) {
			return false;
		}

		foreach (EnemyController e in Master.me.enemies) {

			if (pos == e.pos) {

				return false;

			}

		}
	
		return true;

	}

	public void CheckIfBadTile(Vector2 pos) {

		//		Debug.Log (pos);

		if (GetTile (pos).gameObject.tag == "Wall") {
			PlayerMovement.me.health = 0;
		}
			
		foreach (EnemyController e in Master.me.enemies) {

			if (pos == e.pos) {

				//Debug.Log ("squashed enemy");
				PlayerMovement.me.health --;
				Destroy (e.gameObject);

			}

		}
			
	}



	public void RevealTiles() {

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

		if (Master.me.tiles.ContainsKey (pos)) {
			GameObject tile = Master.me.tiles [pos];
			return tile.GetComponent<TileController> ();
			
		} else {
			return Master.me.tiles [PlayerMovement.me.pos].GetComponent<TileController> ();
		}

	}

	GameObject DecideWhatToSpawn(int x, int y) {
		float r = Random.value;

		if (r <= .6f) {

			// spawn default

			if (Random.value >= .95f) {
				SpawnHeart (x, y);
			}
			return baseTile;

		} else if (r <= .75f) {
			
			return PickObstruction ();

		} else if (r <= .85) {

			// spawn special tile
			return PickCardTile ();

		} else {
			
			return baseTile;
		}

	}

	GameObject PickCardTile() {

		return tileTypes[Random.Range(0, tileTypes.Count)];

	}

	GameObject PickObstruction() {
		float r = Random.value;

		if (r <= 0.95f) {
			return wallTile;

		} else {
			return trapTile;
		}



	}

	void SpawnHeart(int x, int y) {

		Instantiate (heart, new Vector3 (x, y, -0.2f), Quaternion.identity);
//		Debug.Log("heart spawned at " + x + "," + y);
	}

	void AddTileTypes() {

		tileTypes.Add (moveTile);
		tileTypes.Add (goldTile);
		tileTypes.Add (visionTile);
		tileTypes.Add (attackTile);
		tileTypes.Add (wallBreakTile);
		tileTypes.Add (teleportTile);

	}


//
//		if (r > .8f /*&& (x != 0 && x != mapWidth)*/) {
//			Debug.Log (x);
//			return wallTile;
//		} else {
//
//
//			int rand = Random.Range (0, 1000);
//
//			if (rand <= 800) {
//
//				return baseTile;
//
//			} else if (rand <= 900) {
//
//				return moveTile;
//			} else if (rand <= 1000) {
//
//				return goldTile;
//			} else {
//
//				return baseTile;
//
//			}
//		}
//
//
//	}

}
