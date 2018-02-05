using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (transform.position.x, PlayerMovement.me.transform.position.y, -10);
		
	}
}
