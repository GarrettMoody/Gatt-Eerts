using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningHelper : MonoBehaviour {
	private Transform startPosition;
	private Transform endPosition;
	private float speed;
	private float startTime;
	private float panningLength;
	private bool panning;

	void Start() {
		panning = false;
	}

	public void InitializePanningHelper (Transform pStartPosition, Transform pEndPosition, float pSpeed) {
		startPosition = pStartPosition;
		endPosition = pEndPosition;
		speed = pSpeed;

		panningLength = CalculatePanningLength (startPosition, endPosition);
	}

	public float CalculatePanningLength(Transform pStartPosition, Transform pEndPosition) {
		return Vector3.Distance (pStartPosition.position, pEndPosition.position);
	}

	public void PanningUpdate() {
		if (panning) {
			float distTraveled = (Time.time - startTime) * speed;
			float percentCompleted = distTraveled / panningLength;
			transform.position = Vector3.Lerp (startPosition.position, endPosition.position, percentCompleted);

			if (CalculatePanningLength(startPosition, endPosition) < 0.1f) {
				panning = false;
			}
		}
			
	}

	public void StartPanning() {
		startTime = Time.time;
		panning = true;
	}

	public void StopPanning() {
		panning = false;
	}

	public bool isPanning() {
		return panning;
	}
}
