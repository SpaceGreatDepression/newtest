using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemCallback2 : MonoBehaviour 
{
    public Text text;
    public LayoutElement element;
    private static float[] randomWidths = new float[3] { 100, 150, 50 };
    void ScrollCellIndex(int idx)
    {
        string name = "Cell " + idx.ToString();
        if (text != null)
        {
            string s =GameObject.Find("Canvas").transform.FindChild("Main").FindChild("midle").FindChild("6").FindChild("Text2").GetChild(0).GetChild(0).GetComponent<Text>().text;
            if(s!=""){
           float num = float.Parse(s);
        
          
            text.text = ((float)idx * num).ToString();
       
        }else{
                text.text = "";
            }
        }
        element.preferredWidth = randomWidths[Mathf.Abs(idx) % 3];
        gameObject.name = name;
    }
}
