using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	private Vector3 dragStart;
	public float dragSpeed = 2;
	bool isPressed = false;

	// Update is called once per frame
	void Update () {
		/*if (Input.GetMouseButtonDown (0)) {
			dragStart = Input.mousePosition;
			return;
		}

		if (!Input.GetMouseButton (0)) {
			return;
		}

		Vector3 pos = Camera.main.WorldToViewportPoint (Input.mousePosition - dragStart);
		Vector3 move = new Vector3 (pos.x * dragSpeed, 0, 0);

		if (this.transform.position.x >= -2.5f || move.x > 0) {
			transform.Translate (move, Space.World);
		}*/

		if (isPressed) {
			Debug.Log ("PRESSED"); 
		}
	}

	public void OnPointerDown(PointerEventData pointerData) {
		isPressed = true;
		Debug.Log ("PRESSED");
		return; 
	}

	public void OnPointerUp(PointerEventData pointerData) {
		isPressed = false;
		return;
	}
}
