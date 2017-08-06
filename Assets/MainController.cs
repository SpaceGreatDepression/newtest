using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {
	public ToggleController TC;
	public void result(){
		if (TC.PowerToggle.T.transform.GetChild (0).gameObject.activeSelf) {
			if (TC.PowerToggle.S.text != "") {
				TC.NomalToggle [0].T.transform.GetChild (0).gameObject.SetActive (true);
				TC.NomalToggle [2].T.transform.GetChild (0).gameObject.SetActive (true);
				TC.NomalToggle [1].T.transform.GetChild (0).gameObject.SetActive (false);
				TC.NomalToggle [3].T.transform.GetChild (0).gameObject.SetActive (false);


			}


		} else {
			if (TC.maker.Count == 2) {
				if (TC.maker [0].S.text != "" && TC.maker [1].S.text != "") {
				
					if ((pp (TC.maker [0].T).name == "2" && pp (TC.maker [1].T).name == "3") || (pp (TC.maker [1].T).name == "2" && pp (TC.maker [0].T).name == "3")) {
					    //가로세로
						float g ,s,d,ga;
						if (pp (TC.maker [0].T).name == "2") {
							g = float.Parse (TC.maker [0].S.text);
							s = float.Parse (TC.maker [1].S.text);
						} else {
							g = float.Parse (TC.maker [1].S.text);
							s = float.Parse (TC.maker [0].S.text);
						}
						d = Mathf.Sqrt (Mathf.Pow(g,2)+Mathf.Pow(s,2));
						ga = Mathf.Atan(s/g);
						Debug.Log (ga);
						Debug.Log (ga*Mathf.Rad2Deg);
					//	TC.NomalToggle [2].S.text

					}else if((pp (TC.maker [0].T).name == "2" && pp (TC.maker [1].T).name == "4") || (pp (TC.maker [1].T).name == "2" && pp (TC.maker [0].T).name == "4")){
						//가로대각
					}else if((pp (TC.maker [0].T).name == "2" && pp (TC.maker [1].T).name == "5") || (pp (TC.maker [1].T).name == "2" && pp (TC.maker [0].T).name == "5")){
						//가로각도
					}else if((pp (TC.maker [0].T).name == "3" && pp (TC.maker [1].T).name == "4") || (pp (TC.maker [1].T).name == "3" && pp (TC.maker [0].T).name == "4")){
						//세로대각
					}else if((pp (TC.maker [0].T).name == "3" && pp (TC.maker [1].T).name == "5") || (pp (TC.maker [1].T).name == "3" && pp (TC.maker [0].T).name == "5")){
						//세로각도
					}else if((pp (TC.maker [0].T).name == "4" && pp (TC.maker [1].T).name == "5") || (pp (TC.maker [1].T).name == "4" && pp (TC.maker [0].T).name == "5")){
						//대각각도
					}


				}
			}
		}
	}
	Transform pp(GameObject g){
		return g.transform.parent.parent;
	}
}
