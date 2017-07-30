using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class midcont : MonoBehaviour {

	public List<GameObject> IFs = new List<GameObject>();
	// Use this for initialization


	void Start () {

		for (int i = 0; i < IFs.Count; i++) {
			IFs [i].gameObject.AddComponent<inputnumberelement> ();
	
		
		}
	}
	

}
