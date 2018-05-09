using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour {

	public float planeHeight;
	public float leftMax;
	public float rightMax;
	private float speed;
	// Use this for initialization
	void Start () {
		speed = Random.Range (.1f, .5f);
		this.gameObject.transform.localPosition = new Vector3 (Random.Range(leftMax, rightMax), planeHeight, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPos = this.gameObject.transform.localPosition;
		this.gameObject.transform.localPosition = new Vector3 (currentPos.x - speed, currentPos.y, currentPos.z);
		if (this.gameObject.transform.localPosition.x <= leftMax) {
			this.gameObject.transform.localPosition = new Vector3(rightMax, currentPos.y, currentPos.z);
		}
	}
}
