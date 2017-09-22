using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemCallback3 : MonoBehaviour 
{
    public Text text;
    public LayoutElement element;
    private static float[] randomWidths = new float[3] { 200, 150, 50 };
    void ScrollCellIndex(int idx)
    {
		int temp = idx % 5;
		int temp2 = idx / 5;
		idx = (temp * 8) + temp2;
          string name = "Cell " + idx.ToString();
        if (text != null)
        {
            string s =GameObject.Find("Canvas").transform.FindChild("Main").FindChild("midle").FindChild("7").FindChild("Text2").GetChild(0).GetChild(0).GetComponent<Text>().text;


            if(s!=""){
           float num = float.Parse(s);
        
				if (control9.status9 == 1) {
					text.text = MainController.ban3 (MainController.gg - ((float)(idx) * num));
				} else {
					//Debug.Log (leght.statues);
					Debug.Log(num);
					if (leght.statues == 2) {
						text.text = text.text = MainController.ban3 ((float)(idx ) * num);
					} else if (leght.statues == 1) {
						if (leght.L.transform.GetChild (0).GetComponent<Text> ().text != "") {
							float N = float.Parse (leght.L.transform.GetChild (0).GetComponent<Text> ().text);
							text.text = text.text = MainController.ban3 (((float)(idx ) * num) + N);
						} else {
							text.text = text.text = MainController.ban3 ((float)(idx ) * num);
						}

					} else if (leght.statues == 3) {
						if (leght.R.transform.GetChild (0).GetComponent<Text> ().text != "") {
							
							float N =  float.Parse (leght.R.transform.GetChild (0).GetComponent<Text> ().text);
							//Debug.Log (N);
							text.text = text.text = MainController.ban3 (((float)(idx ) * num )- N);
						} else {
							text.text = text.text = MainController.ban3 ((float)(idx ) * num);
						}
					}



					//text.text = text.text = MainController.ban3 ((float)(idx + 1) * num);
				}
       
        }else{
                text.text = "";
            }
        }
        element.preferredWidth = randomWidths[Mathf.Abs(idx) % 3];
        gameObject.name = name;
    }
}
