using UnityEngine;
using System.Collections;

public class BackgroundObject : MonoBehaviour {
	public GameObject terrain1;
	public GameObject terrain2;
	public ArrayList terrains;
	public float minXdist;
	// Use this for initialization
	void Start () {
		terrains = new ArrayList ();
		terrains.Add (terrain1);
		terrains.Add (terrain2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Generate(){
		int terrainInd = Random.Range (0, terrains.Count);
		GameObject selected = (GameObject)terrains [terrainInd];
		float xPos = transform.position.x + minXdist;
		float yPos = transform.position.y;
		float zPos = transform.position.z;
		GameObject terrain = Instantiate (selected, new Vector3 (xPos, yPos, zPos), Quaternion.identity) as GameObject;

	}
}
