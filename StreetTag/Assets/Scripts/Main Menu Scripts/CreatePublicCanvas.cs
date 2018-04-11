using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePublicCanvas : MonoBehaviour {

	public InputField month;
	public InputField day;
	public InputField year;
	public InputField hour;
	public InputField minute;

	// Use this for initialization
	void Start () {
		month.text = System.DateTime.Now.Month.ToString();
		day.text = System.DateTime.Now.Day.ToString();
		year.text = System.DateTime.Now.Year.ToString();
		hour.text = System.DateTime.Now.Hour.ToString();
		minute.text = System.DateTime.Now.Minute.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
