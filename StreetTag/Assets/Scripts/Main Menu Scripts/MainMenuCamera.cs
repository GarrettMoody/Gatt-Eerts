using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour {

	public PanningHelper panningHelper;

	public Transform cameraPlayMenuTransform;
	public Transform cameraBillboardTransform;
	public Transform cameraBankMenuTransform;
	public Transform cameraBankTransform;


	// Update is called once per frame
	void Update () {
		panningHelper.PanningUpdate ();

	}

	public void PanCamera(Transform endPosition, float speed) {
		panningHelper.InitializePanningHelper (this.gameObject.transform, endPosition, speed);
		panningHelper.StartPanning ();
	}

	public void PanCameraToPlayMenu(float speed) {
		panningHelper.InitializePanningHelper (this.gameObject.transform, cameraPlayMenuTransform, speed);
		panningHelper.StartPanning ();
	}

	public void PanCameraToBillboard(float speed) {
		panningHelper.InitializePanningHelper (this.gameObject.transform, cameraBillboardTransform, speed);
		panningHelper.StartPanning ();
	}

	public void PanCameraToBankMenu(float speed) {
		panningHelper.InitializePanningHelper (this.gameObject.transform, cameraBankMenuTransform, speed);
		panningHelper.StartPanning ();
	}

	public void PanCameraToBank(float speed) {
		panningHelper.InitializePanningHelper (this.gameObject.transform, cameraBankTransform, speed);
		panningHelper.StartPanning ();
	}
}
