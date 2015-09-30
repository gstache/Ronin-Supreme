using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreGui : MonoBehaviour {

	Text text;
	public GameObject player;
	float score;
	// Use this for initialization
	void Start () {
		text = GetComponent <Text> ();
		score = player.gameObject.GetComponent<Player> ().score;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) { 
			score = player.gameObject.GetComponent<Player> ().score;
		} 
		text.text = "Score: " + score.ToString();
	}
}
