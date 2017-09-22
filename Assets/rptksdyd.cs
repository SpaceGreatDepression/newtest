using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rptksdyd : MonoBehaviour {

	// Use this for initialization
	float tanqasd;
	void Start () {
		//float g = Mathf.Acos (-Mathf.Sqrt(5f)/3)*Mathf.Rad2Deg;
		float g = Mathf.Acos(-Mathf.Sqrt(5f)/3)*Mathf.Rad2Deg;
		Debug.Log (180f-g);
		float gg2 = g / 2f;
		Debug.Log ("육각 : "+ gg2);
		float g2 = (1f/Mathf.Cos (54f*Mathf.Deg2Rad))/2f;
		Debug.Log (g2);
		float s =  Mathf.Acos (g2/1)*Mathf.Rad2Deg;
		Debug.Log (s);
		float s2 = Mathf.Tan (54f * Mathf.Deg2Rad)/2f;
		Debug.Log (s2);

		float s1 =  Mathf.Acos (s2/(Mathf.Sqrt(3f)/2f))*Mathf.Rad2Deg;
		Debug.Log (180f-s1);
		Debug.Log (s1);
		float fff2 = (180f-s1)-gg2;
		Debug.Log ("오각 : " + fff2);

	}
	void Starts () {
		float Seta = 72;
		float tan = Mathf.Tan (Seta*Mathf.Deg2Rad);//오각직선

		Debug.Log ("오각직선 : " + tan);
		float d = Mathf.Sqrt(Mathf.Pow (tan, 2) + Mathf.Pow (1,2));
		Debug.Log (d);
		float g = Mathf.Asin (tan/d)*Mathf.Rad2Deg;
		Debug.Log (g);

		float Seta2 = 60;
		float tan2 = Mathf.Sin (Seta2*Mathf.Deg2Rad);//오각직선
		Debug.Log (tan2);
		float d2 = tan2 * 2;

		float g2 = (d2*2);
		Debug.Log ("육각직선 :" +g2);
		float sum = 2 + 2 + tan + tan + tan + tan + g2 + g2 + g2 + g2;
		Debug.Log (sum);
	

		float ge = 360f / sum;
		Debug.Log (ge);
		float o = tan * ge;
		o = (180f - o) / 2f;

		float u = g2 * ge;
		u = (180f - u) / 2f;
		tanqasd =u;

		float dd = 2f * ge;
		dd = (180f - dd) / 2f;
		Debug.Log ("o : " + o);
		Debug.Log ("u : " + u);
		Debug.Log ("d : " + dd);
		Debug.Log (180f-(o*2f));
		Debug.Log (180f-(u*2f));
		Debug.Log (180f-(dd*2f));
		ru = (90f - u)/2f;
		//ru = 90f - ru;
		sum -=  g2 + g2 + g2 + g2 + g2 + g2;
		sum = sum / 4f;
		Debug.Log (ge*sum);

	}
	float ru;
	// Update is called once per frame
	void Updates () {
		float Seta = tanqasd;
		float tan = Mathf.Tan (Seta*Mathf.Deg2Rad);//오각직선
		Debug.Log ("탄 : " + tan);
		float d = Mathf.Sqrt(Mathf.Pow (tan, 2) + Mathf.Pow (1,2));
		Debug.Log (d);
		float g = Mathf.Asin (tan/d)*Mathf.Rad2Deg;
		Debug.Log (g);
		float r = 0.1f / tan;
		Debug.Log (r);
		float ta = 2f - (2f * r);
		Debug.Log (ta);
		Debug.Log (ta/4f);
		sdf (ta/4f);
	}
	void sdf(float f){
		Debug.Log (ru);
		float n = 0.5f - f;
	
		float tan = Mathf.Atan (0.1f/n)*Mathf.Rad2Deg;//오각직선
		Debug.Log ("각 : " + tan);
	
	}
}
