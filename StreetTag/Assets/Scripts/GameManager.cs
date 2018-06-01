using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private int defaultZoom = 10;
	private int stormMarkerIndex = 3;
	private int mikeMarkerIndex = 2;
	private int garrettMarkerIndex = 1;
	private int jeffMarkerIndex = 0;
	private OnlineMapsMarker stormMarker;
	private OnlineMapsMarker garrettMarker;
	private OnlineMapsMarker jeffMarker;
	private OnlineMapsMarker mikeMarker;


	void Start () {
		OnlineMaps.instance.OnChangeZoom += OnChangeZoom;
		stormMarker = OnlineMaps.instance.markers [stormMarkerIndex];
		jeffMarker = OnlineMaps.instance.markers [jeffMarkerIndex];
		mikeMarker = OnlineMaps.instance.markers [mikeMarkerIndex];
		garrettMarker = OnlineMaps.instance.markers [garrettMarkerIndex];
		
	}

	void Update() {
		stormMarker.scale = stormMarker.scale - (stormMarker.scale * .001f);
		OnlineMaps.instance.RedrawImmediately ();
	}

	private void OnChangeZoom() {
		int zoom = OnlineMaps.instance.zoom;
		float originalScale = 1 << defaultZoom;
		float currentScale = 1 << OnlineMaps.instance.zoom;
		stormMarker.scale = currentScale / originalScale;

		//playingFieldMarker.scale = currentScale / originalScale;
	}
}
