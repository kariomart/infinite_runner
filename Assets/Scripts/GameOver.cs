using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Text goldText;
	public Text yPosText;
	public Text enemiesKilledText;

	string gold;
	string yPos;
	string enemiesKilled;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {

		gold = "GOLD:\t\t\t" + ScoreController.me.gold.ToString ();
		yPos = "DISTANCE:\t" + ScoreController.me.playerY.ToString ();
		enemiesKilled = "ENEMIES:\t\t" + ScoreController.me.enemiesKilled.ToString ();

		goldText.text = gold;
		yPosText.text = yPos;
		enemiesKilledText.text = enemiesKilled;
		
	}
}
