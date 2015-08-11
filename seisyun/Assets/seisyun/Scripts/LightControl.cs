using UnityEngine;
using System.Collections;

public class LightControl : MonoBehaviour {
    public float time = 0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time >= 1f){
            Color color = new Color();
            if (GetComponent<Light>().color.g >= 0f)
            {
                color.r = GetComponent<Light>().color.r;
                color.g = GetComponent<Light>().color.g - 0.01f;
                color.b = GetComponent<Light>().color.b - 0.01f;
            }
            else
            {
                color.r = GetComponent<Light>().color.r - 0.01f;
                color.g = GetComponent<Light>().color.g;
                color.b = GetComponent<Light>().color.b;
            }
            GetComponent<Light>().color = color;
            time = 0f;
        }
	}
}
