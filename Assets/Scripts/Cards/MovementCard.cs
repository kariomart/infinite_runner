﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCard : Card {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	public override void Played() {

		PlayerMovement.me.moves++;
		Master.me.DiscardCard (this);


	}
}
