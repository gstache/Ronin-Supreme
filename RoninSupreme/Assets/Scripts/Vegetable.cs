using UnityEngine;
using System.Collections;

public class Vegetable : MonoBehaviour {
	public GameObject bodyHalf_1;
	public GameObject bodyHalf_2;
	public GameObject splosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Player") {
			bool deadly = target.gameObject.GetComponent<Player> ().attacking;
			//print (deadly);
			if (deadly) {
				OnExplode ();
				GameObject.Destroy (gameObject);
			} else {
				target.gameObject.GetComponent<Player>().OnExplode();

				GameObject.Destroy (target.gameObject);
				Example ();
				//Application.LoadLevel ("score");
			}
		}
	}

	IEnumerator Example() {
		yield return new WaitForSeconds (.5f);
	}

	void OnExplode() {
		var t = transform;
		t.TransformPoint (0, 75, 0);
		GameObject bh = Instantiate (bodyHalf_1, t.position, Quaternion.identity) as GameObject;
		bh.GetComponent<Rigidbody2D> ().AddForce (new Vector2(-10, 70));
		bh.GetComponent<Rigidbody2D> ().AddTorque (100.5f);
		GameObject splode = Instantiate (splosion, t.position, Quaternion.identity) as GameObject;
		t.TransformPoint (0, 150, 0);
		GameObject bh1 = Instantiate (bodyHalf_2, t.position, Quaternion.identity) as GameObject;
		bh1.GetComponent<Rigidbody2D> ().AddForce (new Vector2(00, -10));

	}

}
