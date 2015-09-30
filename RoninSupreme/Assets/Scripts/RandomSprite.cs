using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {
	public Sprite[] sprites;
	public string resourceName;
	public int currentSprite = 1;
	// Use this for initialization
	void Start () {
		if (resourceName != "") {
			sprites = Resources.LoadAll<Sprite> (resourceName);
			GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];
		} 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

