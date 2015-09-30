using UnityEngine;
using System.Collections;

public class TerrainCrusher : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag.Equals("Terrain")) {
			target.GetComponent<TerrainObject> ().Generate ();
			Destroy (target.gameObject);
		} else if (target.tag.Equals("Player")){
			target.gameObject.GetComponent<Player>().OnExplode();
			Destroy (target.gameObject);
		} else if (target.tag.Equals ("Vegetable") ){
			Destroy(target.gameObject);
			GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Player>().multiplier = 1;
		}
	

	}

}
