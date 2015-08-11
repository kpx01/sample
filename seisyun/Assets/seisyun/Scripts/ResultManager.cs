using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultManager : MonoBehaviour {
    public Text text;

    const string SCORE_KEY = "score";

	// Use this for initialization
	void Start () {
        text.text = LoadScore() + " m";
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space)) Application.LoadLevel("title");
	}

    int LoadScore()
    {
        return PlayerPrefs.GetInt(SCORE_KEY, -1);
    }
}
