using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class inputnumberelement : MonoBehaviour {
	RectTransform Main;
void Start(){
		
	if(GetComponent<BoxCollider2D>() == null){
	this.gameObject.AddComponent<BoxCollider2D>();
	}
	GetComponent<BoxCollider2D>().size = GetComponent<RectTransform>().sizeDelta;
		GetComponent<BoxCollider2D>().offset = new Vector2(((0.5f-GetComponent<RectTransform>().pivot.x)*GetComponent<RectTransform>().sizeDelta.x)
		,((0.5f-GetComponent<RectTransform>().pivot.y)*GetComponent<RectTransform>().sizeDelta.y));

		Main = inputnumber.instans.Main;
		if (GetComponent<EventTrigger> () == null) {
			this.gameObject.AddComponent<EventTrigger> ();
		}

		EventTrigger trigger =		this.GetComponent<EventTrigger> ();
			EventTrigger.Entry entry = new EventTrigger.Entry ();
		//	entry.eventID = EventTriggerType.PointerUp;
		//entry.callback.AddListener ((eventData)=>PointerUp());
		//	trigger.triggers.Add (entry);
	//	entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.PointerDown;
		entry.callback.AddListener ((eventData)=>PointerDown());
		trigger.triggers.Add (entry);
		/*
		entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener ((eventData)=>PointerEnter());
		trigger.triggers.Add (entry);
		entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.PointerExit;
		entry.callback.AddListener ((eventData)=>PointerExit());
		trigger.triggers.Add (entry);
		*/

	

}
	public void PointerEnter(){
		inputnumber.instans.Target  = this.gameObject;
	}
		public void PointerExit(){
		if(inputnumber.instans.Target  == this.gameObject){
		inputnumber.instans.Target  = null;
		}
	}

	public void PointerDown(){
		if (inputnumber.instans.Using != null) {
			inputnumber.instans.Using.GetComponent<Image> ().color = new Color (1f,1f,1f,1);
		}
		Main.anchoredPosition = new Vector2 (0,1000f);
		inputnumber.instans.OpenKeyboard_hard ();
		inputnumber.instans.Using = this.gameObject;
		GetComponent<Image> ().color = new Color (0.8f,0.8f,0.8f,1);
	}
	public void PointerUp(){
		//Main.anchoredPosition = new Vector2 (0,675);
		//inputnumber.instans.CloseKeyboard_hard ();
	//	inputnumber.instans.Using = GetComponent<Text>();
	}

}
