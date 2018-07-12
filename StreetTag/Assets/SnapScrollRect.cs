using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrollRect : MonoBehaviour {


	private RectTransform scrollPanel;
	private RectTransform center;
	private Text[] textComponents;
	private float distanceBetweenElements;
	private ScrollRect scrollRect; 

	private bool isScrolling = false;
	private bool isMoving = false;
	// Use this for initialization
	void Start () {
		scrollRect = this.GetComponent<ScrollRect> ();
		scrollPanel = (RectTransform)this.transform.Find("ScrollPanel");
		textComponents = scrollPanel.GetComponentsInChildren<Text> ();
		center = (RectTransform)this.transform.Find ("Center");
	}

	// Update is called once per frame
	void Update () {
		if (isMoving) { //if its not moving there is nothing to update. 
			//Debug.Log ("IS MOVING");
			if (!isScrolling) { //time to stop the scrolling...moving too slow to move on.
				List <float> distancesFromCenter = new List<float> (); 
				float scrollDistance = Mathf.Abs (scrollPanel.transform.localPosition.y) - Mathf.Abs (center.transform.localPosition.y);
				//get all distances from center
				for (int i = 0; i < textComponents.Length; i++) {
					distancesFromCenter.Add (Mathf.Abs(Mathf.Abs(scrollDistance) - Mathf.Abs(textComponents[i].transform.localPosition.y)));
				}

				//get smallest distance from center
				float[] distanceArray = distancesFromCenter.ToArray ();
				float minDistance = Mathf.Min (distanceArray);

				int minIndex = distancesFromCenter.IndexOf (minDistance);

				//Calculating distanceBetweenElements cannot be put in start; the locations are set to 0 in the first frame...distance always results to 0. 
				distanceBetweenElements = (float)Mathf.Abs (textComponents [0].transform.localPosition.y -
					textComponents [1].transform.localPosition.y);
	
				LerpToFinish (minIndex * distanceBetweenElements);

			}
		}
	}

	void LerpToFinish(float pos) {
		float newY = Mathf.Lerp (scrollPanel.transform.localPosition.y,
			pos,
			Time.deltaTime * 5f);

		Vector2 newPosition = new Vector2 (center.anchoredPosition.x, newY);
		scrollPanel.transform.localPosition = newPosition;

	}

	public void OnValueChange() {
		float verticalVelocity = Mathf.Abs (scrollRect.velocity.y);
		//Debug.Log (verticalVelocity);
		if (verticalVelocity > 50f) {
			isScrolling = true;
		} else {
			isScrolling = false;
		}

		if (verticalVelocity < 2f) {
			isMoving = false;
			scrollRect.velocity = Vector2.zero;
		} else {
			isMoving = true;
		}
	}
}
