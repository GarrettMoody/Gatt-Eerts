using UnityEngine;
using UnityEngine.Networking;

public class StreetTagMain : MonoBehaviour {

	public GameObject prefab;

	private OnlineMapsMarker3D playerMarker;
	private OnlineMapsControlBase3D control;
	private OnlineMapsLocationService ls;

	private int defaultZoom = 17;

	void Start () {

		OnlineMaps.instance.OnChangeZoom += OnChangeZoom;
		// Get instance of OnlineMapsControlBase3D (Texture or Tileset)
		control = OnlineMapsControlBase3D.instance;
		ls = OnlineMapsLocationService.instance;

		ls.position = new Vector2 (-88.0197f, 44.457f);
		ls.OnLocationChanged += OnLocationChanged;
		playerMarker = control.AddMarker3D (Vector2.zero, prefab);
		playerMarker.enabled = true;

		OnChangeZoom ();
	}

	private void OnChangeZoom() {
		int zoom = OnlineMaps.instance.zoom;
		float originalScale = 1 << defaultZoom;
		float currentScale = 1 << OnlineMaps.instance.zoom;
		foreach (OnlineMapsMarker3D marker in control.markers3D) {
			marker.scale = currentScale / originalScale;
		}
	}

	private void OnLocationChanged(Vector2 position) {
		playerMarker.position = position;
	}

	public Vector3 GetPlayerLocation() {
		return playerMarker.transform.localPosition;
	}

	public float GetPlayerScale() {
		return playerMarker.scale;
	}

	private void OnGUI()
	{
		float changeValue = 0.0001f;
		if (GUI.Button(new Rect(55, 10, 100, 80), "UP"))
		{
			// Change the marker coordinates.
			Vector2 mPos = playerMarker.position;
			mPos.y += changeValue;
			playerMarker.position = mPos;
			OnlineMaps.instance.SetPosition (OnlineMaps.instance.position.x, OnlineMaps.instance.position.y + changeValue);
			ls.emulatorPosition.y += changeValue;
		}
		if (GUI.Button(new Rect(55, 170, 100, 80), "DOWN"))
		{
			// Change the marker coordinates.
			Vector2 mPos = playerMarker.position;
			mPos.y -= changeValue;
			playerMarker.position = mPos;
			OnlineMaps.instance.SetPosition (OnlineMaps.instance.position.x, OnlineMaps.instance.position.y - changeValue);
			ls.emulatorPosition.y -= changeValue;
		}
		if (GUI.Button(new Rect(10, 90, 100, 80), "LEFT"))
		{
			// Change the marker coordinates.
			Vector2 mPos = playerMarker.position;
			mPos.x -= changeValue;
			playerMarker.position = mPos;
			OnlineMaps.instance.SetPosition (OnlineMaps.instance.position.x - changeValue, OnlineMaps.instance.position.y);
			ls.emulatorPosition.x -= changeValue;
		}
		if (GUI.Button(new Rect(110, 90, 100, 80), "RIGHT"))
		{
			// Change the marker coordinates.
			Vector2 mPos = playerMarker.position;
			mPos.x += changeValue;
			playerMarker.position = mPos;
			OnlineMaps.instance.SetPosition (OnlineMaps.instance.position.x + changeValue, OnlineMaps.instance.position.y);
			ls.emulatorPosition.x += changeValue;
		}
	}
}
