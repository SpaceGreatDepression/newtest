using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class inputnumberelement : MonoBehaviour {
void Start(){
	if(GetComponent<BoxCollider2D>() == null){
	this.gameObject.AddComponent<BoxCollider2D>();
	}
	GetComponent<BoxCollider2D>().size = GetComponent<RectTransform>().sizeDelta;
		GetComponent<BoxCollider2D>().offset = new Vector2(((0.5f-GetComponent<RectTransform>().pivot.x)*GetComponent<RectTransform>().sizeDelta.x)
		,((0.5f-GetComponent<RectTransform>().pivot.y)*GetComponent<RectTransform>().sizeDelta.y));
}
	public void PointerEnter(){
		inputnumber.instans.Target  = GetComponent<Text>();
	}
		public void PointerExit(){
			if(inputnumber.instans.Target  == GetComponent<Text>()){
		inputnumber.instans.Target  = null;
		}
	}
	public void PointerDown(){
		inputnumber.instans.Using = GetComponent<Text>();
	}

}
