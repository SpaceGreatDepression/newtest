using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputnumber : MonoBehaviour {

public static inputnumber instans;
public Text Target,Using;
 void Update () {
 Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);
 
     for(int i = 0 ; i < hits.Length;i++){
		 Debug.Log(hits[i].transform.name);
	 }
 }
void Awake(){
instans = this;	
}
public void Closecheck(){


}
public void OpenKeyboard_hard(){
GetComponent<RectTransform>().anchoredPosition = new Vector2(0,1000);
}
public void OpenKeyboard_soft(float time){
StartCoroutine(Mathf_Lerp(0,1000,time));
}
public void CloseKeyboard_hard(){
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
