using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public GameObject prefab;
	private GameObject map;
	// Use this for initialization
	void Start () {
		map = GameObject.Find ("Map");
	}
}
