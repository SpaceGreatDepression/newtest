using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class midcont : MonoBehaviour {
	RectTransform Main;
	public List<InputField> IFs = new List<InputField>();
	// Use this for initialization
	public delegate void asd(string sf);
	void Start () {
		Main = GameObject.Find ("Canvas").transform.FindChild ("Main").GetComponent<RectTransform> ();
		for (int i = 0; i < IFs.Count; i++) {
			IFs [i].gameObject.AddComponent<EventTrigger> ();
	
			EventTrigger trigger =	IFs [i].GetComponent<EventTrigger> ();
			EventTrigger.Entry entry = new EventTrigger.Entry ();
			entry.eventID = EventTriggerType.PointerUp;
			entry.callback.AddListener ((eventData)=>Up());
			trigger.triggers.Add (entry);

			IFs [i].onEndEdit.AddListener ((s)=>Down());
		}
	}
	
	// Update is called once per frame
	void Up () {
		Main.anchoredPosition = new Vector2 (0,675);
	}
	void Down () {
		Main.anchoredPosition = new Vector2 (0,0);
	}
}
