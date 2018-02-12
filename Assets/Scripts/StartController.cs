using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour {

	public GameObject fx;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("main");
		}
		
	}

	void OnMouseDown() {

		UnityEngine.SceneManagement.SceneManager.LoadScene ("main");

	}

	void OnMouseOver() {

		fx.SetActive (true);

	}

	void OnMouseExit() {

		fx.SetActive (false);
	}
}
