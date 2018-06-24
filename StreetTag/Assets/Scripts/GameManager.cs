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
	private double JeffLat = 44.564142;
	private double JeffLong = -88.157449;

	void Start()
	{
		OnlineMaps.instance.OnChangeZoom += OnChangeZoom;
		stormMarker = OnlineMaps.instance.markers[stormMarkerIndex];
		jeffMarker = OnlineMaps.instance.markers[jeffMarkerIndex];
		mikeMarker = OnlineMaps.instance.markers[mikeMarkerIndex];
		garrettMarker = OnlineMaps.instance.markers[garrettMarkerIndex];       
	}

	private void OnChangeZoom() {
		int zoom = OnlineMaps.instance.zoom;
		float originalScale = 1 << defaultZoom;
		float currentScale = 1 << OnlineMaps.instance.zoom;
		stormMarker.scale = currentScale / originalScale;     
	}

	private void MoveGuys(double Lng, double Lat)
	{
		JeffLong = JeffLong + Lng;
		JeffLat = JeffLat + Lat;
		jeffMarker.SetPosition(JeffLong, JeffLat);
		OnlineMaps.instance.Redraw();
	}

	private void OnGUI()
	{
		float changeValue = 0.0001f;
		if (GUI.Button(new Rect(900, 100, 100, 80), "UP"))
		{
			MoveGuys(0.00, 0.01);
		}
		if (GUI.Button(new Rect(900, 300, 100, 80), "DOWN"))
		{
			MoveGuys(0.00, -0.01);
		}
		if (GUI.Button(new Rect(850, 200, 100, 80), "LEFT"))
		{
			MoveGuys(-0.01, 0.00);
		}
		if (GUI.Button(new Rect(950, 200, 100, 80), "RIGHT"))
		{
			MoveGuys(0.01, 0.00);
		}      
	}
}
