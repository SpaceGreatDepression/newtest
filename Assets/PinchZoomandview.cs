﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PinchZoomandview : MonoBehaviour
{
	List<Vector2> vl = new List<Vector2>();
	public float perspectiveZoomSpeed = 0.3f;        // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
	public RectTransform target;
	public RectTransform mask;
	public bool multi = true;
	Vector2 V;
	Rectt_To_t RT;
	void Start(){
		RT = transform.GetChild (0).GetChild (0).GetComponent<Rectt_To_t> ();
		V = new Vector2 (Screen.width,Screen.height);
		PinchOn (this.transform);
	}
	Vector2 defultsize;
	Vector2 defultpos;
	Vector2 maxsizes;
	Vector3 defultscale;
	public void PinchOn(Transform t){
		//mesage = m;
		//target = g;
		T = t;
		Pinchboo = true;

	}
	public void pinchoff(){
		Pinchboo = false;
	}
	bool Pinchboo = false;
	string mesage;

	Transform T;
	public Touch touchZero;
	public Touch touchOne;
	void pivotset(){
		if (T != null) {
			vel = Util.instans.InputMousePosition ();
	

			defultpos = T.GetComponent<RectTransform> ().anchoredPosition;

			//	defultpos = Vector2.zero;
			defultsize = T.GetComponent<RectTransform> ().sizeDelta;
			//	defultpos -= new Vector2 (0,60f);
			defultscale = T.localScale;
			maxsizes = new Vector2 (defultscale.x * defultsize.x, defultscale.y * defultsize.y);
			//Debug.Log ("dp : " + defultpos + " , ds : " + defultscale);
			T.GetComponent<RectTransform> ().pivot = new Vector2 (((vel.x - defultpos.x) / maxsizes.x)+0.5f, ((vel.y - defultpos.y) / maxsizes.y)+0.5f);

			T.GetComponent<RectTransform> ().anchoredPosition = defultpos;
			T.GetComponent<RectTransform> ().anchoredPosition -= new Vector2 (((0.5f-T.GetComponent<RectTransform> ().pivot.x)*defultsize.x)*defultscale.x,((0.5f-T.GetComponent<RectTransform> ().pivot.y)*defultsize.y)*defultscale.y);
			//Debug.Log ("dp : " + T.GetComponent<RectTransform> ().anchoredPosition + " , dpi: " + T.GetComponent<RectTransform> ().pivot);
		}
	}
	void pivotreset(){
		if (T != null) {
			if (T.GetComponent<RectTransform> ().pivot.x != 0.5f || T.GetComponent<RectTransform> ().pivot.y != 0.5f) {


				vel = Util.instans.InputMousePosition ();
				defultpos = T.GetComponent<RectTransform> ().anchoredPosition;
				//	defultpos = Vector2.zero;
				defultsize = T.GetComponent<RectTransform> ().sizeDelta;
				//defultpos -= new Vector2 (0,60f);
				defultscale = T.localScale;
				maxsizes = new Vector2 (defultscale.x * defultsize.x, defultscale.y * defultsize.y);
				Vector2 dpi = T.GetComponent<RectTransform> ().pivot;
				T.GetComponent<RectTransform> ().pivot = new Vector2 (0.5f, 0.5f);
				Debug.Log (T.GetComponent<RectTransform> ().anchoredPosition+" pi : " + dpi + " ds : " + T.transform.localScale);
				T.GetComponent<RectTransform> ().anchoredPosition = defultpos;
				if(dpi.x != 0.5f||dpi.y != 0.5f) {
					T.GetComponent<RectTransform> ().anchoredPosition += new Vector2 ((0.5f-dpi.x) * defultsize.x * defultscale.x, (0.5f-dpi.y ) * defultsize.y * defultscale.y);
				}else
					if (dpi.x != 0.5f) {
						T.GetComponent<RectTransform> ().anchoredPosition += new Vector2 ((0.5f-dpi.x) * defultsize.x * defultscale.x, 0);
					} else if (dpi.y != 0.5f) {
						T.GetComponent<RectTransform> ().anchoredPosition += new Vector2 (0, (0.5f-dpi.y ) * defultsize.y * defultscale.y);
					}
				Debug.Log (T.GetComponent<RectTransform> ().anchoredPosition);
			}
		}
	}
	bool fist = true;
	void Update()
	{

		//if (Pinchboo) {
		//	Debug.Log ("Input.touchCount : " + Input.touchCount);
		//pivotset ();
		if (Input.touchCount >= 2&&multi) {
		//Debug.Log (Imageclick);
		//if (Imageclick) {
			if (fist) {
				fist = false;
				pivotset ();
			}
			touchZero = Input.GetTouch (0);
			touchOne = Input.GetTouch (1);
	

			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;


			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;


			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;


			//Debug.Log ("deltaMagnitudeDiff * perspectiveZoomSpeed : " + deltaMagnitudeDiff * perspectiveZoomSpeed);
			float result = (deltaMagnitudeDiff * perspectiveZoomSpeed) * -1f;
		//	result = 1;

			if (result != 0) {
				T.localScale += new Vector3 (result * 0.01f, result * 0.01f, 0);
				if (T.localScale.x > 3) {
					T.localScale = new Vector3 (3, 3, 0);
				} else if (T.localScale.x < 1f) {
					T.localScale = new Vector3 (1f, 1f, 0);
				}
				RT.UpdateLR ();
			}
			size = true;


		} else if (Imageclick) 
		{
			pivotreset ();
			fist = true;
			if (size) {
				vl.Clear ();
				size = false;


				#if UNITY_EDITOR
				vel = Util.instans.InputMousePosition ();
				#else
				if (Input.touchCount >= 2) {
				if (Input.GetTouch (0).fingerId == touchZero.fingerId) {
				vel = Util.instans.InputMousePosition (0);
				} else {
				vel = Util.instans.InputMousePosition (touchOne);
				}
				}else{
				vel = Util.instans.InputMousePosition ();
				}
				#endif

			} else {

				count++;
				saver = target.anchoredPosition;
				target.anchoredPosition += Util.instans.InputMousePosition () - vel;
				//vl.Add((saver - target.anchoredPosition)*-1f);
				//if (vl.Count > 5) {
				//	vl.RemoveAt (0);
				//}
				vel = Util.instans.InputMousePosition ();
			}
			pivotreset ();
		//	Debug.Log ("checkout");
			Vector2 v = target.GetComponent<RectTransform> ().anchoredPosition;

			Vector2 M = maxsize ();
			if (!multi) {

				//v = new Vector2(target.GetComponent<RectTransform> ().anchoredPosition.y,target.GetComponent<RectTransform> ().anchoredPosition.x);
				M = new Vector2((target.GetComponent<RectTransform>().sizeDelta.y-V.x)/2f,(target.GetComponent<RectTransform>().sizeDelta.x-V.y)/2f);
			}
		//	Debug.Log ("maxsize : " + M);
			//smooth = false;
			//Debug.Log("v : " + v);
			//Debug.Log("M : " + M);
			if (v.x > M.x || v.x < -M.x || v.y > M.y || v.y < -M.y) {
				if (multi) {
					smooth = true;
				}
				float x = v.x;
				if (v.x > M.x) {
					x = M.x;
				} else if (v.x < -M.x) {
					x = -M.x;
				}
				float y = v.y;
				if (v.y > M.y) {
					y = M.y;
				} else if (v.y < -M.y) {
					y = -M.y;
				}  
				velo = Vector2.zero;


			
				gotop = new Vector2 (x, y);
			
					GetComponent<RectTransform> ().anchoredPosition = gotop;
				if (target.GetComponent<RectTransform> ().sizeDelta.y <= V.x&&!multi) {
					GetComponent<RectTransform> ().anchoredPosition = velo;
				}
			}

		} else if(smooth) {


			fist = true;
			target.anchoredPosition = Vector2.SmoothDamp (target.anchoredPosition, gotop, ref velo, 0.1f,9999f,Time.deltaTime);

		}
	

	}
	Vector2 saver;
	Vector2 velo;
	bool size = false;
	int count = 0;
	bool Imageclick = false;
	public bool smooth = false;
	Vector2 vel;
	public void ImageDown(){
		if (transform.localScale.x != 1 && transform.localScale.y != 1) {
			size = true;
			vel = Util.instans.InputMousePosition ();

			//pinchoff ();
			Imageclick = true;
		}
	}
	public void ImageDown2(){
		
			size = true;
		vel = Util.instans.InputMousePosition ();

			//pinchoff ();
			Imageclick = true;

	}



	public void ImageUp(){
		#if UNITY_EDITOR
		Imageclick = false;
		if (multi) {
		checkout ();
		}
		#else
		//	if (Input.touchCount <= 1) {
		Imageclick = false;
		if (multi) {
		checkout ();
		}
		//	}
		#endif

	}
	public Vector2 maxsize(){
		float x = (target.transform.localScale.x - 1f) * (target.GetComponent<RectTransform> ().sizeDelta.x / 2f);
		float y = (target.transform.localScale.y - 1f) * (target.GetComponent<RectTransform> ().sizeDelta.y / 2f);
		return new Vector2 (x,y);
	}
	void checkout(){
		pivotreset ();
		Debug.Log ("checkout");
		Vector2 v = target.GetComponent<RectTransform> ().anchoredPosition;
		Vector2 M = maxsize ();
		Debug.Log ("maxsize : " + M);
		smooth = false;
		if (v.x > M.x || v.x < -M.x || v.y > M.y || v.y < -M.y) {
			smooth = true;
			float x = v.x;
			if (v.x > M.x) {
				x = M.x;
			} else if (v.x < -M.x) {
				x = -M.x;
			}
			float y = v.y;
			if (v.y > M.y) {
				y = M.y;
			} else if (v.y < -M.y) {
				y = -M.y;
			}  
			velo = Vector2.zero;



			gotop = new Vector2 (x, y);
		//	GetComponent<RectTransform> ().anchoredPosition = gotop;
		}

		/*else {
			//smooth = true;
			Debug.Log("saver : " + saver);
			Debug.Log("target.anchoredPosition : " + target.anchoredPosition);
			Vector2 save = (saver - target.anchoredPosition)*-1f;
			save = new Vector2 (save.x *5,save.y*5);
			//			Vector2 save = new Vector2(0,0);
			//			for (int i = 0; i < vl.Count; i++) {
			//				save += vl [i];
			//			}
			//			Debug.Log (save);
			Debug.Log (save);
			save +=target.anchoredPosition ;

			if (save.x > M.x || save.x < -M.x || save.y > M.y || save.y < -M.y) {
				smooth = true;
				float x = save.x;
				if (save.x > M.x) {
					x = M.x;
				} else if (save.x < -M.x) {
					x = -M.x;
				}
				float y = save.y;
				if (save.y > M.y) {
					y = M.y;
				} else if (save.y < -M.y) {
					y = -M.y;
				}  
				velo = Vector2.zero;



				gotop = new Vector2 (x, y);
				//gotop = save;
			}else{
				gotop = save;
			} 

			gotop = save;
		
		}
	*/
	}

	Vector2 gotop;

}