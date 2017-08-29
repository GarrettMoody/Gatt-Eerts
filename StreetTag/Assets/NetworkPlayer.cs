using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour {

	private GameObject map;
	private StreetTagMain STMain;
	private OnlineMapsTileSetControl control;
	private OnlineMapsMarker3D marker;
	// Use this for initialization
	void Start () {
		if (!isLocalPlayer) {
			Destroy (this);
			return;

			//try creating the marker here. Since the player being recieved from the server is the client player,
			//the marker should be created here since it is not the local player. 

			OnlineMapsMarker3D newPlayer = new OnlineMapsMarker3D (this.gameObject);
			marker = control.AddMarker3D (newPlayer);
			Vector2 currentCoords = control.GetCoordsByWorldPosition (this.gameObject.transform.position);
			marker.SetPosition (currentCoords.x, currentCoords.y);
		}

		map = GameObject.Find ("Map");
		STMain = map.GetComponent<StreetTagMain> ();
		control = map.GetComponent<OnlineMapsTileSetControl> ();
		//OnlineMapsMarker3D newPlayer = new OnlineMapsMarker3D (this.gameObject);
		//marker = control.AddMarker3D (newPlayer);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = STMain.GetPlayerLocation () * 2;
		this.transform.localScale = new Vector3 (STMain.GetPlayerScale (), STMain.GetPlayerScale (), STMain.GetPlayerScale ()) * 2;
		//Vector2 currentCoords = control.GetCoordsByWorldPosition (this.gameObject.transform.position);
		//marker.SetPosition (currentCoords.x, currentCoords.y);
		//Debug.Log (marker.position);
	}
}
