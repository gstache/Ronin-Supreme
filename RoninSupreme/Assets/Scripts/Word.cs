using UnityEngine;
using System.Collections;

public class Word : MonoBehaviour {
	private Animator animator;
	public GameObject player;
	SpriteRenderer render;
	public Sprite word1;
	public Sprite word2;
	public Sprite word3;
	float speed;
	// Use this for initialization
	void Start () {
		render = gameObject.GetComponent<SpriteRenderer> ();
		int word = Random.Range (0, 3);
		if (word == 0) {
			render.sprite = word1;
		} else if (word == 1) {
			render.sprite = word2;
		} else {
			render.sprite = word3;
		}
		animator = gameObject.GetComponent<Animator> ();
		speed = player.GetComponent<Player> ().speed;
		player.GetComponent<Player> ().speed = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void next() {
		player.GetComponent<Player> ().speed = speed;
		Destroy (gameObject);
	}
}
