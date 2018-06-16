using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCard : Card {


	// Use this for initialization
	// void Start () {

	// 	cardName = "scarab";
	// 	cardDescription = "grants 1 gold";
	// 	sprite = (Sprite)Master.me.sprites[0];
		
	// }

	void Start() {

		cardName = "scarab";
		cardDescription = "grants 1 gold";
		//sprite = (Sprite)Master.me.sprites[0];

	}
	
	// Update is called once per frame
	// void Update () {

	// 	Played ();
		
	// }


		

	public override void Played() {

		if (isSelected && transform.position.y >= 0.012) {
			
			PlayerMovement.me.gold++;
			Master.me.DiscardCard (this);
			PlayerMovement.me.energy--;
			base.Played ();
		}


	}
}
