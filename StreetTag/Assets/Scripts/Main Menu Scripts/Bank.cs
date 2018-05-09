using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour {

	public MainMenuCamera camera;

	public void OnButtonClickListener() {
		camera.PanCameraToBankMenu (1);
	}
}
