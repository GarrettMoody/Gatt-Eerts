using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenStartGameCanvas() {
		this.gameObject.SetActive (true);
	}

	public void CloseStartGameCanvas() {
		this.gameObject.SetActive (false);
	}
}
