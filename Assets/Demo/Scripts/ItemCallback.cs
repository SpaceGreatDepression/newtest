using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemCallback : MonoBehaviour 
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
            string s =GameObject.Find("Canvas").transform.FindChild("Main").FindChild("midle").FindChild("6").FindChild("Text").GetChild(0).GetChild(0).GetComponent<Text>().text;
          string s1 = GameObject.Find("Canvas").transform.FindChild("Main").FindChild("midle").FindChild("3").FindChild("Text").GetChild(0).GetChild(0).GetComponent<Text>().text;
            if(s!=""&&s1!=""){
				float numb = MainController.se;
           float num = float.Parse(s);
          float num1 = float.Parse(s1);
          
				text.text = MainController.ban3(((float)idx*numb) + num);
       
        }else{
                text.text = "";
            }
        }
        element.preferredWidth = randomWidths[Mathf.Abs(idx) % 3];
        gameObject.name = name;
    }
}
