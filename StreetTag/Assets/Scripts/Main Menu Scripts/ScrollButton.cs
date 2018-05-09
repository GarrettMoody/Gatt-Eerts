using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public Camera mainCamera;
	private Vector3 pos;
	public bool isRightButton = true;
	public float maxPosition;
	public float resetPosition;
	public float moveSpeed = 5;

	private bool isPressed = false;

	
	// Update is called once per frame
	void Update () {
		pos = mainCamera.transform.position;
		if (isPressed && !isRightButton) {
			float newX = pos.x - moveSpeed * .1f;
			mainCamera.transform.position = new Vector3(newX, pos.y, pos.z);
			if (mainCamera.transform.position.x <= maxPosition) {
				mainCamera.transform.position = new Vector3 (resetPosition, pos.y, pos.z);
			}
		} 

		if (isPressed && isRightButton) {
			float newX = pos.x + moveSpeed * .1f;
			mainCamera.transform.position = new Vector3(newX, pos.y, pos.z);
			if (mainCamera.transform.position.x >= maxPosition) {
				mainCamera.transform.position = new Vector3 (resetPosition, pos.y, pos.z);
			}
		}
	}

	public void OnPointerDown(PointerEventData eventData) {
		isPressed = true;
	}

	public void OnPointerUp(PointerEventData eventData) {
		isPressed = false;
	}
}
