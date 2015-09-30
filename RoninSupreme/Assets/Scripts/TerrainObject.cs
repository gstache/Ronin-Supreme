using UnityEngine;
using System.Collections;

public class TerrainObject : MonoBehaviour {
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject terrain1;
	public GameObject terrain2;
	public GameObject terrain3;
	public GameObject terrain4;
	public ArrayList terrains;
	public ArrayList enemies;
	public float zPos;
	public bool hasEnemiesOnIt;
	public float minXdist;
	public float maxXdist;
	public float maxYdist;
	// Use this for initialization
	void Start () {
		terrains = new ArrayList ();
		terrains.Add (terrain1);
		terrains.Add (terrain2);
		terrains.Add (terrain3);
		terrains.Add (terrain4);
		enemies = new ArrayList ();
		enemies.Add (enemy1);
		enemies.Add (enemy2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Generate(){
		Vector3 pos = transform.position;
		int terrainInd = Random.Range (0, terrains.Count);
		GameObject selected = terrains[terrainInd] as GameObject;
		float xPos = pos.x + Random.Range(minXdist, maxXdist);
		float Ydist = Random.Range (-maxYdist, maxYdist);
		float yPos = selected.gameObject.transform.position.y + Ydist; 
		float zPos = selected.gameObject.transform.position.z;
		int enemy = Random.Range (-2, 2);

		GameObject terrain = Instantiate (selected, new Vector3 (xPos, yPos, zPos), Quaternion.identity) as GameObject;
		 if (enemy >= 0){
			GameObject vegetable = enemies[enemy] as GameObject;
			xPos = xPos + Random.Range(-10.0f,10.0f);
			yPos = yPos + 3.0f;
			GameObject veggie = Instantiate(vegetable, new Vector3 (xPos, yPos, zPos), Quaternion.identity) as GameObject;
		}
	}

	void OnTriggerEnter2D(Collider2D target){
		if(target.tag.Equals("Player")){
			target.gameObject.GetComponent<Player>().OnExplode();
			Destroy(target.gameObject);
		}
	}
}
