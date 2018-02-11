using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : TileController {

	public override void TileEntered ()
	{

		PlayerMovement.me.health = 0;


	}


}
