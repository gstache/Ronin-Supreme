using UnityEngine;
using System.Collections;

public class BGCrusher : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag.Equals("Background")) {
			target.GetComponent<BackgroundObject> ().Generate ();
		} else if (target.tag.Equals("Player")){
			target.gameObject.GetComponent<Player>().OnExplode();
		}

		Destroy (target.gameObject);
	}

}
