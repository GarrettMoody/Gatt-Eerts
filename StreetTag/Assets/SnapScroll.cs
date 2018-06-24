using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SmoothScrollSnap : MonoBehaviour, IBeginDragHandler, IEndDragHandler {

	public float SnapSpeed = 10;
	public float ScrollVelocity;
	//[ShowInInspector] //I added this outside of my IDE so not sure if it's the right attribute
	private bool isDragging;
	public int Snaps;
	public static bool Dragging;

	private Scrollbar scroll;
	private ScrollRect sRect;

	// Use this for initialization
	void Start () {

		scroll = FindObjectOfType<Scrollbar> ();

		sRect = FindObjectOfType<ScrollRect> ();

	}

	// Update is called once per frame
	void Update () {

		isDragging = Dragging;

		if (!scroll)
			return;

		//ScrollVelocity = sRect.inertia.y;

		if (!Dragging)
			scroll.value = Mathf.Lerp (scroll.value, Mathf.Round (scroll.value * (Snaps - 1)) / (Snaps - 1), SnapSpeed * Time.deltaTime);

	}

	public void OnBeginDrag (PointerEventData eventData) {
		Dragging = true;
	}

	public void OnEndDrag (PointerEventData eventData) {
		Dragging = false;
	}

}