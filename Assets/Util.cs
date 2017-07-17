using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {
	public static Util instans;
	Canvas c;
	Vector2 screenh;
	void Awake(){
		screenh = new Vector2 (Screen.width/2f,Screen.height/2f);
		instans = this;
		c = GameObject.Find ("Canvas").GetComponent<Canvas> ();
	}
	public Vector2 InputMousePosition(){
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle (c.transform as RectTransform,Input.mousePosition,c.worldCamera,out pos);

		return pos;
	}
	public Vector2 InputMousePosition(int i){
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<Canvas>().transform as RectTransform, Input.touches[i].position, GetComponent<Canvas>().worldCamera, out pos);
		return pos;

	}
	public Vector2 InputMousePosition(Touch T){
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<Canvas>().transform as RectTransform, T.position, GetComponent<Canvas>().worldCamera, out pos);
		return pos;

	}
	public Vector2 InputMousePosition2(){
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle (c.transform as RectTransform,Input.mousePosition,c.worldCamera,out pos);

		return pos+screenh;
	}
	public Vector2 InputMousePosition2(int i){
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<Canvas>().transform as RectTransform, Input.touches[i].position, GetComponent<Canvas>().worldCamera, out pos);
		return pos+screenh;

	}
	public Vector2 InputMousePosition2(Touch T){
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<Canvas>().transform as RectTransform, T.position, GetComponent<Canvas>().worldCamera, out pos);
		return pos+screenh;

	}
}
