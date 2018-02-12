using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : Card {

	// Use this for initialization
	void Start () {

		cardName = "khopesh";
		cardDescription = "attack enemies directly adjacent to you.";

	}
	
	// Update is called once per frame
	void Update () {

		Played ();

	}

	public override void Played() {


		//Debug.Log ("trying to play " + gameObject.name);

		if (isSelected && Master.me.selectedTile != null) {
			
			EnemyController enemy = Master.me.CheckEnemies (Master.me.selectedTile.pos);

			if (enemy != null) {

//				Debug.Log (Master.me.selectedTile.pos + " " + enemy.pos);
				int dis = (int)(Master.me.selectedTile.pos - PlayerMovement.me.pos).magnitude;
				Debug.Log ("attack dis " + dis);

				if (dis <= 1) {
					enemy.health--;
					ScoreController.me.enemiesKilled++;
					PlayerMovement.me.energy--;
					Master.me.selectedTile = null;
					base.Played ();
					Master.me.DiscardCard (this);

				} else {
					Debug.Log ("not in range"); 
					base.Played ();
				}

			} else {
				Debug.Log ("no enemy on space");
				base.Played ();
			}


		} else {
			//play sound effect
			//Debug.Log("need to select a tile first!");
		}
	}
}
