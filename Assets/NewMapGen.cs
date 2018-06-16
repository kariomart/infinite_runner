using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapGen : MonoBehaviour {

	public GameObject baseTile;
	public Sprite wallSpr;

	public int mapWidth;
	public int mapHeight;
	public int[,] mapData;
	public GameObject[,] mapObjects;

	List<GameObject> tileTypes = new List<GameObject>();

 
	// Use this for initialization
	void Start () {

		mapData = new int[mapWidth, mapHeight];
		mapObjects = new GameObject[mapWidth, mapHeight];

		addTileTypes ();
		generateMapData();
		createMapObjects();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void generateMapData() {

		for (int x = 0; x < mapWidth; x++) {
			for (int y = 0; y < mapHeight; y++) {

				mapData[x,y] = DecideWhatToSpawn(x, y);

			}
		}
	}

	void createMapObjects() {

		for (int x = 0; x < mapWidth; x++) {
			for (int y = 0; y < mapHeight; y++) {

			GameObject tempTile = Instantiate(baseTile, new Vector2(x, y), Quaternion.identity);
			TileController tileData = tempTile.GetComponent<TileController>();


				if ((mapData[x,y]) == 0) {

					//nothing

				}

				else if ((mapData[x,y]) == 1) {

					//wall 
					tileData.spr = wallSpr;

				}

				else if ((mapData[x,y]) == 2) {

					//card
					//tileData.cardData = Master.me.getCardData(Random.Range(0, Master.me.cards.Length + 1));

				}

				tileData.init();
				mapObjects[x,y] = tempTile;
			}
		}
		
	}

	int DecideWhatToSpawn(int x, int y) {
		float r = Random.value;

		if (r <= .6f) {

			// spawn default
			return 0;

		} else if (r <= .75f) {
			
			return PickObstruction ();

		} else if (r <= .85) {

			// spawn special tile
			return 2;

		} else {
			
			return 0;
		}

	}


	int PickObstruction() {

		return 1;

		float r = Random.value;

		if (r <= 0.95f) {
			return 1;

		} else {
			return -1;
		}
	}

	void addTileTypes() {


	}
}
