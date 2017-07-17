using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class Rectt_To_t : MonoBehaviour {
	Camera C;
	LineRenderer LR;
	public float Width;
	public float Hight;
	public float Angle;
	public float Miniwidth;
	public float linewidth;
	bool useWorldSpace;

	Vector2 screens;
	// Use this for initialization
	public void UpdateLR(){
		LR.widthMultiplier = convert ((screens.x/2f) + (linewidth*transform.parent.parent.localScale.x));
	}
	void SettingPivot(RectTransform rectTransform, Vector2 pivot)
	{
		if (rectTransform == null) return;
		Vector2 size = rectTransform.rect.size;
		Vector2 deltaPivot = rectTransform.pivot - pivot;
		Vector3 deltaPosition = new Vector3(deltaPivot.x * size.x, deltaPivot.y * size.y);
		deltaPosition = new Vector2 (deltaPosition.x * transform.parent.localScale.x,deltaPosition.y * transform.parent.localScale.y);
		rectTransform.pivot = pivot;
		rectTransform.localPosition -= deltaPosition;
	/*
		rectTransform.pivot = pivot;
		rectTransform.anchoredPosition = new Vector2((pivot.x-0.5f)*screens.x,(pivot.y-0.5f)*(Hight+100f));
*/
	}
	public void reset(){
		Vector2 v = Util.instans.InputMousePosition2 ();
		Debug.Log (v);
		Action A =() => {Pivot = new Vector2 ( 
			(v.x/screens.x)*transform.parent.localScale.x
			,
			((v.y-((screens.y/2f)-((Hight+100f)/2f)))/(Hight+100f))*transform.parent.localScale.y
		);};
		A ();
		SettingPivot (transform.parent as RectTransform, Pivot);
	
	}
	Vector2 Pivot;
	void getpivot(){
		Vector2 v = Util.instans.InputMousePosition2 ();

		Pivot =  new Vector2 ();
	}
	List<Vector3> pointlist = new List<Vector3> ();
	void setting(Vector2 v){
		transform.parent.GetComponent<RectTransform> ().sizeDelta = new Vector2 (screens.x,Hight+100f);
		Vector2 center = new Vector3 (screens.x/2f,screens.y/2f);
		useWorldSpace = LR.useWorldSpace;
		if (LR.GetComponent<RectTransform> () == null) {
			useWorldSpace = true;
			LR.useWorldSpace = true;
		}
		pointlist = new List<Vector3> ();
		if (!useWorldSpace) {
			LR.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.5f,0.5f);
			LR.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.5f,0.5f);

			LR.GetComponent<RectTransform> ().anchoredPosition = Vector2.zero;


			center = Vector2.zero;


		}

		pointlist.Add (convert(new Vector2(0,-Hight/2f)+center));
		pointlist.Add (convert(new Vector2(Width/2f,-Hight/2f)+center));

		pointlist.Add (convert(new Vector2(-Width/2f,Hight/2f)+center));
		pointlist.Add (convert(new Vector2(-Width/2f,-Hight/2f)+center));
		pointlist.Add (convert(new Vector2(0,-Hight/2f)+center));

		//	for (int i = 0; i < pointlist.Count; i++) {
		//		pointlist [i] += convert(center);
		//	}
		Angle = Mathf.Atan2 (Hight,Width)*Mathf.Rad2Deg;
		float tan = Mathf.Tan(Angle*Mathf.Deg2Rad);
		//Debug.Log (tan);
		int number = (int)(Width/Miniwidth);

		pointlist.Add (convert(new Vector2((Width/2f)-Miniwidth,-Hight/2f)+center));
		pointlist.Add (convert(new Vector2((Width/2f)-Miniwidth,-Hight/2f+(Miniwidth*tan))+center));
		for (int i = 2; i < number+1; i++) {
			if (i % 2 == 0) {
				pointlist.Add (convert (new Vector2 ((Width / 2f) - (Miniwidth * i), -Hight / 2f + ((Miniwidth * i) * tan)) + center));
				pointlist.Add (convert (new Vector2 ((Width / 2f) - (Miniwidth * i), -Hight / 2f )+ center));
			} else {
				pointlist.Add (convert (new Vector2 ((Width / 2f) - (Miniwidth * i), -Hight / 2f )+ center));
				pointlist.Add (convert (new Vector2 ((Width / 2f) - (Miniwidth * i), -Hight / 2f + ((Miniwidth * i) * tan))+ center));
			}
		}
	
		LR.numPositions = pointlist.Count;
		LR.SetPositions (pointlist.ToArray());

		LR.widthMultiplier = convert ((screens.x/2f) + linewidth);
	
	}
	void setting(){
		setting (Vector2.zero);
	}
	void Start () {
		screens = new Vector2 (Screen.width,Screen.height);

		LR = GetComponent<LineRenderer> ();

		setting ();

	//	Debug.Log (convert (0));
	

		List<Datalist> Dlist = new List<Datalist> ();
		//Action<string> asdf = (logs) => Debug.Log (logs);
		Dlist.Add (new Datalist((logs) => Debug.Log (logs),"M1"));
		//Dlist.Add (new Datalist(M2,"M2"));
		//Dlist.Add (new Datalist(M3,"M3"));
		StartCoroutine ("delegatetest", Dlist);
		var imsi = new {k = 123,sl = "ss"};
		temp TT = (logs) => Debug.Log (logs);
		TT ("kkkoy");
		Func<int,int> Fc = (i) => i + 10;
		Debug.Log (Fc(9).ToString());
		temp2 T2 = (s) =>{Debug.Log("ddd");return 6;};
		Debug.Log (T2("dd").ToString());

	}
	IEnumerator delegatetest(List<Datalist> D){
		for (int i = 0; i < D.Count; i++) {
			D [i].ds (D[i].name);
			yield return new WaitForSeconds (1f);
		}
	}
	void M1(string s){
		Debug.Log ("M1 : " + s);
	}
	void M2(string s){
		Debug.Log ("M2 : " + s);
	}
	void M3(string s){
		Debug.Log ("M3 : " + s);
	}
	public delegate void temp(string s);
	public delegate int temp2(string s);
	// Update is called once per frame

	Vector3 convert(Vector2 V2){
		if (useWorldSpace) {
			C = GameObject.Find ("Main Camera").GetComponent<Camera> ();
			Vector3 v;
			RectTransformUtility.ScreenPointToWorldPointInRectangle (GetComponent<RectTransform> (), V2, C, out v);
			return new Vector3 (v.x, v.y, 0);
		} else {
			return new Vector3 (V2.x, V2.y, 0);
		}
	}
	float convert(float f){
		//if (useWorldSpace) {
			C = GameObject.Find ("Main Camera").GetComponent<Camera> ();
			Vector3 v;
			RectTransformUtility.ScreenPointToWorldPointInRectangle (GetComponent<RectTransform> (), new Vector2 (f, 0), C, out v);
			return v.x;
		//} else {
		//	return f;
		//}
			
	}
}
class Datalist{
	//public delegate void D(string s);
	//public D ds;
	public Action<string> ds;
	public string name;
	public Datalist(Action<string> d,string n){
		ds = d;
		name = n;
	}
}

public class Employee

{
	public float currPay;
	public virtual void GiveBonus(float amount)

	{

		currPay += amount;

	}

}



public class SalesPerson  :  Employee

{

	// 재정의한다.

	public override void GiveBonus(float amount)

	{

		//currPay += amount * 0.1;
		//base.GiveBonus(amount * 0.1);

	}

}






