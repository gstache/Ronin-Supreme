using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour {
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent <Text> ();
		float score = PlayerPrefs.GetFloat ("score");
		text.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Home)) {
			Application.Quit ();
		}
	}
}
