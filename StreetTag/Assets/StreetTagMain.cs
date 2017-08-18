using UnityEngine;

public class StreetTagMain : MonoBehaviour {

	public GameObject [] players = new GameObject[3];
	public GameObject playingField; 
	public GameObject coin;

	private OnlineMapsMarker3D [] markers = new OnlineMapsMarker3D[3];
	private OnlineMapsMarker3D playingFieldMarker;
	private OnlineMapsMarker3D coinMarker;
	private OnlineMapsMarker3D playerMarker;

	private OnlineMapsControlBase3D control;
	private OnlineMapsLocationService ls;

	private int defaultZoom = 17;

	public int coins; 

	void Start () {
		coins = 0;
		OnlineMaps.instance.OnChangeZoom += OnChangeZoom;
		// Get instance of OnlineMapsControlBase3D (Texture or Tileset)
		control = OnlineMapsControlBase3D.instance;

		if (control == null)
		{
			Debug.LogError("You must use the 3D control (Texture or Tileset).");
			return;
		}

		ls = OnlineMapsLocationService.instance;

		if (ls == null) {
			Debug.LogError ("You must have a location service control");
			return;
		}

		ls.position = new Vector2 (-88.0197f, 44.457f);
		ls.OnLocationChanged += OnLocationChanged;
		playerMarker = control.AddMarker3D (Vector2.zero, players [0]);
		markers [1] = GenerateMarker(new Vector2(-88.0197f, 44.4575f), players[1]);
		markers [2] = GenerateMarker (new Vector2 (-88.0199f, 44.4575f), players [2]);

		//Vector2 playingFieldLocation = new Vector2 (-88.019f, 44.457f);
		//playingFieldMarker = control.AddMarker3D (playingFieldLocation, playingField);
		//playingFieldMarker.range = new OnlineMapsRange (1, 20);

		OnChangeZoom ();
		GenerateCoins ();
	}

	private void OnChangeZoom() {
		int zoom = OnlineMaps.instance.zoom;
		float originalScale = 1 << defaultZoom;
		float currentScale = 1 << OnlineMaps.instance.zoom;
		foreach (OnlineMapsMarker3D marker in control.markers3D) {
			marker.scale = currentScale / originalScale;
		}
		//playingFieldMarker.scale = currentScale / originalScale;
	}

	private void GenerateCoins() {
		for (int i = 0; i < 10; i++) {
			float y = Random.Range (44.456f, 44.459f);
			float x = Random.Range (-88.021f, -88.018f);
			OnlineMapsMarker3D coinMark = control.AddMarker3D (new Vector2 (x, y), coin);
			coinMark.scale = 3;
		}
	}

	private OnlineMapsMarker3D GenerateMarker(Vector2 location, GameObject prefab) {
		OnlineMapsMarker3D newMarker = control.AddMarker3D (location, prefab);
		newMarker.range = new OnlineMapsRange (1, 20);
		return newMarker;
	}

	private void OnLocationChanged(Vector2 position) {
		playerMarker.position = position;
	}

	private void OnTriggerStay(Collider other) {
		if (this.gameObject.name != "Map") {
			Debug.Log ("TriggerEnter: " + other.name);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (this.gameObject.name != "Map") {
			Debug.Log ("TriggerExit: " + other.name);
		}
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

		GUIStyle style = new GUIStyle ();
		style.fontSize = 64;
		style.normal.textColor = Color.red;
		GUI.Label (new Rect (10, 250, 100, 50), "Score: " + coins, style);
	}

	public void AddCoin() {
		coins += 1;
	}
}
