using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	bool isPressed = false;
	
	// Update is called once per frame
	void Update () {
		if (isPressed) {
			Debug.Log ("PRESSED");
		}
	}

	public void OnPointerDown(PointerEventData eventData) {
		isPressed = true;
	}

	public void OnPointerUp(PointerEventData eventData) {
		isPressed = false;
	}
}
