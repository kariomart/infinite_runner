using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCard : Card {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


		

	public override void Played() {


		PlayerMovement.me.gold++;
		Master.me.DiscardCard (this);
		PlayerMovement.me.energy--;


	}
}
