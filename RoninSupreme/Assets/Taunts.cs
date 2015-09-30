using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Taunts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text text = GetComponent <Text> ();
		ArrayList taunts = new ArrayList ();
		taunts.Add ("Your ancestors are dissappointed");
		taunts.Add ("Consider basket weaving: you're a terrible samurai");
		taunts.Add ("You died. Again. Jeez.");
		taunts.Add ("Sentient Broccoli and Tomatoes and Rocks oh my!");
		taunts.Add ("You have failed your master");
		taunts.Add ("Today I bought a chicken sandwich");
		taunts.Add ("Snatching defeat from the jaws of victory");
		int rand = Random.Range (0, taunts.Count);
		text.text = (string)taunts [rand];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
