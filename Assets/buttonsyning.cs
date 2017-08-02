using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class buttonsyning : MonoBehaviour {

	EventTrigger Target;
	IEnumerator Start(){
				this.gameObject.AddComponent<EventTrigger> ();

			

	//	yield return new WaitUntil(()=>Target.triggers!=null);
		yield return new WaitForSeconds(2f);
	
	Target = GameObject.Find("Canvas").transform.FindChild("Main").FindChild("midle").FindChild(name).
		FindChild("Text").FindChild("InputField").GetComponent<EventTrigger>();
	 GetComponent<EventTrigger> ().triggers = Target.triggers;

	
	}
}
