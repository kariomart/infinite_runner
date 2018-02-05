using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	int size;
	string[,] map;
	string[,] mapGen1;
	string[,] mapGen2;




	// Use this for initialization
	void Start () {

		size = 5;
		map = new string[size, size];
		mapGen1 = new string[size, size];
		mapGen2 = new string[size, size];


		FillMap ();
		DisplayMapToConsole ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FillMap() {

		for (int x = 0; x < size; x++) {
			for (int y = 0; y < size; y++) {
				map [x, y] = "O";
				//Debug.Log (map [x, y]);
			}
		}

		for (int x = 0; x < size; x++) {
			for (int y = 0; y < size; y++) {
				mapGen1 [x, y] = "X";
				//Debug.Log (map [x, y]);
			}
		}

		for (int x = 0; x < size; x++) {
			for (int y = 0; y < size; y++) {
				mapGen2 [x, y] = "O";
				//Debug.Log (map [x, y]);
			}
		}



	}

	void DisplayMapToConsole() {
		
		string finalString = "";

		for (int x = 0; x < size; x++) {
			string rowString = "";
			for (int y = 0; y < size; y++) {

				rowString += map [x, y];

			}

			finalString += "\n" + rowString;
		}

		Debug.Log (finalString);
	}
}
