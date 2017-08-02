using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class inputnumber : MonoBehaviour {

public static inputnumber instans;
public GameObject Target,Using;
	public	RectTransform Main;
	/*
 void Update () {
 Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);
 
     for(int i = 0 ; i < hits.Length;i++){
		 Debug.Log(hits[i].transform.name);
	 }
 }
 */
	public void PointerDown()
	{
		Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Ray2D ray = new Ray2D(wp, Vector2.zero);
		RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);

		for(int i = 0 ; i < hits.Length;i++){
			hits [i].transform.GetComponent<inputnumberelement> ().PointerDown ();
		}
		if (hits.Length == 0) {
			CloseKeyboard_hard ();
		
		}
	}
void Awake(){
instans = this;	
		Main = GameObject.Find ("Canvas").transform.FindChild ("Main").GetComponent<RectTransform> ();
		for (int i = 0; i < transform.childCount - 1; i++) {

			Debug.Log (transform.GetChild (i).name);
			if (transform.GetChild (i).name == "dot") {
				transform.GetChild (i).gameObject.AddComponent<Button> ();
				transform.GetChild (i).gameObject.GetComponent<Button> ().onClick.AddListener (() => {Using.transform.GetChild (0).GetComponent<Text> ().text += ".";FallowText();});
			} else if (transform.GetChild (i).name == "del") {
				transform.GetChild (i).gameObject.AddComponent<Button> ();
				transform.GetChild (i).gameObject.GetComponent<Button> ().onClick.AddListener (() => {
					if (Using.transform.GetChild (0).GetComponent<Text> ().text.Length > 0) {
						Using.transform.GetChild (0).GetComponent<Text> ().text = Using.transform.GetChild (0).GetComponent<Text> ().text.Remove (
							Using.transform.GetChild (0).GetComponent<Text> ().text.Length-1,1);
							FallowText();
					}
				});
			} else {
				string save = "";
				switch (transform.GetChild (i).name) {
				case "0":
					save += "0";
					break;
				case "1":
					save += "1";
					break;
				case "2":
					save += "2";
					break;
				case "3":
					save += "3";
					break;
				case "4":
					save += "4";
					break;
				case "5":
					save += "5";
					break;
				case "6":
					save += "6";
					break;
				case "7":
					save += "7";
					break;
				case "8":
					save += "8";
					break;
				case "9":
					save += "9";
					break;
				}
				transform.GetChild (i).gameObject.AddComponent<Button> ();
				transform.GetChild (i).gameObject.GetComponent<Button> ().onClick.AddListener (() =>{ Using.transform.GetChild (0).GetComponent<Text> ().text += save
				;FallowText();});
			
			}
		}
}

void FallowText(){
	
	if(Using!=null){
		switch(Using.transform.parent.parent.name){
			
			case "2":
			case "3":
			case "4":
			case "5":
			
			Main.FindChild("sam").FindChild(Using.transform.parent.parent.name).GetChild(0).GetComponent<Text>().text = Using.transform.GetChild (0).GetComponent<Text> ().text;

			break;
		}
	}
}
public void Closecheck(){


}
public void OpenKeyboard_hard(){
GetComponent<RectTransform>().anchoredPosition = new Vector2(0,1000);
		transform.FindChild ("area").gameObject.SetActive (true);
}
public void OpenKeyboard_soft(float time){
StartCoroutine(Mathf_Lerp(0,1000,time));
}
public void CloseKeyboard_hard(){
		transform.FindChild ("area").gameObject.SetActive (false);
		Main.anchoredPosition = new Vector2 (0,0);
		if (Using != null) {
			Using.GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		}
		Using = null;
GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
}
public void CloseKeyboard_soft(float time){
StartCoroutine(Mathf_Lerp(1000,0,time));
}
	float adder = 0;
IEnumerator Mathf_Lerp(float start,float end, float time){
	if(adder>=1||adder == 0){
	float T = 1f/time*0.02f;
	adder = 0;
	while(true){
		adder += T;
		if(adder>=1){
			GetComponent<RectTransform>().anchoredPosition = new Vector2(0,end);
	break;
}
GetComponent<RectTransform>().anchoredPosition = new Vector2(0,Mathf.Lerp(start,end,adder));

yield return new WaitForFixedUpdate();
	}
}
}
}
