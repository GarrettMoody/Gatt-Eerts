using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public GameObject prefab;
	private GameObject map;
	// Use this for initialization
	void Start () {
		map = GameObject.Find ("Map");
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log (this.prefab.name + " hit " + other.gameObject.name);

		if (other.gameObject.name == "Coin(Clone)") {
			Destroy (other.gameObject);
			OnlineMapsTileSetControl tsc = (OnlineMapsTileSetControl) map.GetComponent<OnlineMapsTileSetControl>();
			foreach (OnlineMapsMarker3D marker in tsc.markers3D) {
				if (marker.instance.gameObject == other.gameObject) {
					tsc.RemoveMarker3D (marker);
					map.GetComponent<StreetTagMain> ().AddCoin ();
				}
			}
		}
	}
}
