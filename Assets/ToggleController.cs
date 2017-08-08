using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour {

	public TS PowerToggle;
	public List<TS> NomalToggle = new List<TS>();
	public List<TS> maker = new List<TS> ();

	// Use this for initialization

	
	// Update is called once per frame
	GameObject saveT;
	public void Togglecheck(GameObject T){
		saveTb = true;
		//if (T == PowerToggle.T) {
			//saveT = null;
		//	ToggleCallback (PowerToggle);
	//	} else {

				for (int i = 0; i < NomalToggle.Count; i++) {
					//Debug.Log (T.GetInstanceID());
					//Debug.Log (NomalToggle [i].T.GetInstanceID());
					if (NomalToggle [i].T == T) {
						
						ToggleCallback (NomalToggle [i]);
		
						break;
					}
				}


	//	}
	}
	bool saveTb = true;
	public void ToggleCallback(TS ts){
		if (ts == PowerToggle) {
			if (PowerToggle.T.transform.GetChild (0).gameObject.activeSelf) {
				PowerToggle.T.transform.GetChild (0).gameObject.SetActive (false);
			} else {
				PowerToggle.T.transform.GetChild (0).gameObject.SetActive (true);
			}
		} else {
		
for(int i = 0 ; i < maker.Count;i++){
	if(ts.T == maker[i].T){
		saveTb = false;
					maker [i].T.transform.GetChild (0).gameObject.SetActive (false);
				maker.RemoveAt (i);
		break;
	}
}

	
			
	if (saveTb) {
				ts.T.transform.GetChild (0).gameObject.SetActive (true);
				;
				if (maker.Count < 2) {
					maker.Add (ts);
				} else {
					maker [0].T.transform.GetChild (0).gameObject.SetActive (false);
					maker.RemoveAt (0);

					maker.Add (ts);
				}
			}
		}
	}
	[System.Serializable]
	public class TS{
		public GameObject T;
		public Text S;

		public TS(GameObject t,Text s){
			T = t;
			S = s;
		}
	}
}
