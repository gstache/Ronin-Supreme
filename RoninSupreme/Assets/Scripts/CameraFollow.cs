using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public GameObject target;
	private Transform _t;
	// Use this for initialization
	void Start () {
		GetComponent<Camera>().orthographicSize = ((Screen.height) / 100f);
		if (target) {
			_t = target.transform;
			_t.position += new Vector3 (5.5f, 0.0f, 0.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(_t)
			transform.position = new Vector3 (_t.position.x + 5.5f, (_t.position.y - 5.5f)/2.0f, transform.position.z);
	}
}
