using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

	public MainMenuCamera camera;
	
	public void OnButtonClickListener() {
		camera.PanCameraToPlayMenu (1);
	}
}
