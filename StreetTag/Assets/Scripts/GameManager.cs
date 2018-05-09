using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private int defaultZoom = 10;
	private int stormMarkerIndex = 3;
	private OnlineMapsMarker stormMarker;

	void Start () {
		OnlineMaps.instance.OnChangeZoom += OnChangeZoom;
		stormMarker = OnlineMaps.instance.markers [stormMarkerIndex];
	}

	private void OnChangeZoom() {
		int zoom = OnlineMaps.instance.zoom;
		float originalScale = 1 << defaultZoom;
		float currentScale = 1 << OnlineMaps.instance.zoom;
		stormMarker.scale = currentScale / originalScale;

		//playingFieldMarker.scale = currentScale / originalScale;
	}
}
