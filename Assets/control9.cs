using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class control9 : MonoBehaviour {
	public static int status9 = 2;
	public List<Toggle> Tlist;
	// Use this for initialization

	void Start(){
		for (int i = 0; i < Tlist.Count; i++) {
			Tlist [i].onValueChanged.AddListener ((b)=>Togglebutton(b));
		}
	}
	// Update is called once per frame
	public void Togglebutton(bool b){
		if (b) {
			for (int i = 0; i < Tlist.Count; i++) {
				if (Tlist [i].isOn) {
					status9 = i + 1;
					PlayerPrefs.SetInt ("status9", status9);
					break;
				}
			}
		}

	}
}
