using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class leght : MonoBehaviour {
	public GameObject l,m,r;
	public static GameObject L,M,R;
	public static int statues = 2;

	// Use this for initialization
	void Start () {
		L = l;
		M = m;
		R = r;
		if (L.GetComponent<EventTrigger> () == null) {
			L.AddComponent<EventTrigger> ();
		}
		EventTrigger trigger =		L.GetComponent<EventTrigger> ();

		EventTrigger.Entry entry = new EventTrigger.Entry ();
		//	entry.eventID = EventTriggerType.PointerUp;
		//entry.callback.AddListener ((eventData)=>PointerUp());
		//	trigger.triggers.Add (entry);
		//	entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.PointerDown;
		entry.callback.AddListener ((eventData)=>PointerDown(true));
		trigger.triggers.Add (entry);

		if (R.GetComponent<EventTrigger> () == null) {
			R.AddComponent<EventTrigger> ();
		}
		trigger =		R.GetComponent<EventTrigger> ();

		entry = new EventTrigger.Entry ();
		//	entry.eventID = EventTriggerType.PointerUp;
		//entry.callback.AddListener ((eventData)=>PointerUp());
		//	trigger.triggers.Add (entry);
		//	entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.PointerDown;
		entry.callback.AddListener ((eventData)=>PointerDown(false));
		trigger.triggers.Add (entry);
		M.GetComponent<Toggle> ().onValueChanged.AddListener ((b)=>ChangeToggle(b));

	}


	
	// Update is called once per frame
	void PointerDown (bool b) {
		M.GetComponent<Toggle> ().isOn = false;
		PlayerPrefs.SetInt ("Toggle8",2);
		if (b) {
			statues = 1;
			PlayerPrefs.SetInt ("status8", statues);
			PlayerPrefs.SetString ("82", "");
			R.transform.GetChild (0).GetComponent<Text> ().text = "";
		} else {
			statues = 3;
			PlayerPrefs.SetString ("81", "");
			PlayerPrefs.SetInt ("status8", statues);
			L.transform.GetChild (0).GetComponent<Text> ().text = "";
	
		}
	}
	void ChangeToggle (bool b) {
		if (b) {
			PlayerPrefs.SetInt ("Toggle8",1);
			PlayerPrefs.SetString ("81", "");
			PlayerPrefs.SetString ("82", "");
			statues = 2;
			PlayerPrefs.SetInt ("status8", statues);
			L.transform.GetChild (0).GetComponent<Text> ().text = "";
			R.transform.GetChild (0).GetComponent<Text> ().text = "";
		} else {
			PlayerPrefs.SetInt ("Toggle8",2);
		}
	}
}
