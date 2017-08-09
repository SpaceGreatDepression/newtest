using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
						ga = Mathf.Atan(s/g)*Mathf.Rad2Deg;
					Dd = d/s;
				TC.NomalToggle [2].S.text = ban3(d);
				TC.NomalToggle [3].S.text = ban3(ga);
					//	TC.NomalToggle [2].S.text
//charton();
					}else if((pp (TC.maker [0].T).name == "2" && pp (TC.maker [1].T).name == "4") || (pp (TC.maker [1].T).name == "2" && pp (TC.maker [0].T).name == "4")){
						//가로대각
							float g ,s,d,ga;

										if (pp (TC.maker [0].T).name == "2") {
							g = float.Parse (TC.maker [0].S.text);
							d = float.Parse (TC.maker [1].S.text);
						} else {
							g = float.Parse (TC.maker [1].S.text);
							d = float.Parse (TC.maker [0].S.text);
						}
						s =Mathf.Sqrt (Mathf.Pow(d,2)-Mathf.Pow(g,2));
						ga = Mathf.Acos(g/d)*Mathf.Rad2Deg;
                 Dd = d/s;
				TC.NomalToggle [1].S.text = ban3(s);
				TC.NomalToggle [3].S.text = ban3(ga);
				//charton();
					}else if((pp (TC.maker [0].T).name == "2" && pp (TC.maker [1].T).name == "5") || (pp (TC.maker [1].T).name == "2" && pp (TC.maker [0].T).name == "5")){
						//가로각도
						float g ,s,d,ga;
						if (pp (TC.maker [0].T).name == "2") {
							g = float.Parse (TC.maker [0].S.text);
							ga = float.Parse (TC.maker [1].S.text);
						} else {
							g = float.Parse (TC.maker [1].S.text);
							ga = float.Parse (TC.maker [0].S.text);
						}
					
						s = Mathf.Tan(ga*Mathf.Deg2Rad)*g;
						d = Mathf.Sqrt (Mathf.Pow(g,2)+Mathf.Pow(s,2));
						Dd = d/s;
				TC.NomalToggle [1].S.text = ban3(s);
				TC.NomalToggle [2].S.text = ban3(d);
//charton();
					}else if((pp (TC.maker [0].T).name == "3" && pp (TC.maker [1].T).name == "4") || (pp (TC.maker [1].T).name == "3" && pp (TC.maker [0].T).name == "4")){
						//세로대각
float g ,s,d,ga;
						if (pp (TC.maker [0].T).name == "3") {
							s = float.Parse (TC.maker [0].S.text);
							d = float.Parse (TC.maker [1].S.text);
						} else {
							d = float.Parse (TC.maker [1].S.text);
							s = float.Parse (TC.maker [0].S.text);
						}
						g = Mathf.Sqrt (Mathf.Pow(d,2)-Mathf.Pow(s,2));
						ga = Mathf.Atan(s/g)*Mathf.Rad2Deg;
						Dd = d/s;
				TC.NomalToggle [0].S.text = ban3(g);
				TC.NomalToggle [3].S.text = ban3(ga);
//charton();
					}else if((pp (TC.maker [0].T).name == "3" && pp (TC.maker [1].T).name == "5") || (pp (TC.maker [1].T).name == "3" && pp (TC.maker [0].T).name == "5")){
						//세로각도
						float g ,s,d,ga;
						if (pp (TC.maker [0].T).name == "3") {
							s = float.Parse (TC.maker [0].S.text);
							ga = float.Parse (TC.maker [1].S.text);
						} else {
							s = float.Parse (TC.maker [1].S.text);
							ga = float.Parse (TC.maker [0].S.text);
						}
						g = 1f/Mathf.Tan(ga*Mathf.Deg2Rad)*s;
						d = Mathf.Sqrt (Mathf.Pow(g,2)+Mathf.Pow(s,2));
								Dd = d/s;
				TC.NomalToggle [0].S.text = ban3(g);
				TC.NomalToggle [2].S.text = ban3(d);
		
				//charton();
					}else if((pp (TC.maker [0].T).name == "4" && pp (TC.maker [1].T).name == "5") || (pp (TC.maker [1].T).name == "4" && pp (TC.maker [0].T).name == "5")){
						//대각각도
											float g ,s,d,ga;
						if (pp (TC.maker [0].T).name == "4") {
							d = float.Parse (TC.maker [0].S.text);
							ga = float.Parse (TC.maker [1].S.text);
						} else {
							d = float.Parse (TC.maker [1].S.text);
							ga = float.Parse (TC.maker [0].S.text);
						}
						s = Mathf.Sin(ga*Mathf.Deg2Rad)*d;
						g = Mathf.Sqrt (Mathf.Pow(d,2)-Mathf.Pow(s,2));
						Dd = d/s;
				TC.NomalToggle [0].S.text = ban3(g);
				TC.NomalToggle [1].S.text = ban3(s);
				//charton();
					}


				}
			}
		}
			charton();
	}
	public void changeview(){
		if(
		TC.transform.parent.FindChild("view2").GetComponent<RectTransform>().anchoredPosition.x == 1080f){
		TC.transform.parent.FindChild("view2").GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
		}else{
			TC.transform.parent.FindChild("view2").GetComponent<RectTransform>().anchoredPosition = new Vector2(1080,0);
		}
	}
	public void resetall(){
		PlayerPrefs.DeleteAll();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public static string ban3(float f)
    {
      
        float n =  Mathf.Round (f * 100.0f);
             n = n / 100f;
        return n.ToString();
    }
	public static string ban3(string f)
    {
      
       
        return ban3(float.Parse(f));
    }
	
	public static float Dd;
	void charton(){

if(GameObject.Find("Canvas").transform.FindChild("Main").FindChild("midle").FindChild("6").FindChild("Text").GetChild(0).GetChild(0).GetComponent<Text>().text!=""){
		TC.transform.parent.FindChild("1").GetChild(0).GetComponent<LoopHorizontalScrollRect>().RefreshCells();
}
		if(GameObject.Find("Canvas").transform.FindChild("Main").FindChild("midle").FindChild("7").FindChild("Text2").GetChild(0).GetChild(0).GetComponent<Text>().text!=""){
				Dd = Dd*float.Parse(GameObject.Find("Canvas").transform.FindChild("Main").FindChild("midle").FindChild("7").FindChild("Text2").GetChild(0).GetChild(0).GetComponent<Text>().text);
		TC.transform.parent.FindChild("view2").FindChild("2").GetChild(0).GetComponent<LoopHorizontalScrollRect>().RefreshCells();
		TC.transform.parent.FindChild("view2").FindChild("3").GetChild(0).GetComponent<LoopHorizontalScrollRect>().RefreshCells();
		}


			GameObject.Find("Canvas").transform.FindChild("Main").FindChild("sam").FindChild("2").GetChild(0).GetComponent<Text>().text = 
			TC.NomalToggle [0].S.text;
						GameObject.Find("Canvas").transform.FindChild("Main").FindChild("sam").FindChild("3").GetChild(0).GetComponent<Text>().text = 
			TC.NomalToggle [1].S.text;
						GameObject.Find("Canvas").transform.FindChild("Main").FindChild("sam").FindChild("4").GetChild(0).GetComponent<Text>().text = 
			TC.NomalToggle [2].S.text;
						GameObject.Find("Canvas").transform.FindChild("Main").FindChild("sam").FindChild("5").GetChild(0).GetComponent<Text>().text = 
			TC.NomalToggle [3].S.text;
	}
	Transform pp(GameObject g){
		return g.transform.parent.parent;
	}
	void Start(){
		result();
	}
}
