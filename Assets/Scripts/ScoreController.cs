using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

	public int playerY;
	public int gold;
	public int enemiesKilled;
	public static ScoreController me;

	// Use this for initialization
	void Start () {
		
		if (me == null) {
			me = this;
		} else {
			Destroy (this);
		}

		//GameObject.FindGameObjectsWithTag ("Score");
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Score")) {

			if (g != this.gameObject) {
				Destroy (g);
			}
		}
			

		DontDestroyOnLoad (this.gameObject);
	}
		
	
	// Update is called once per frame
	void Update () {
		
	}
}
