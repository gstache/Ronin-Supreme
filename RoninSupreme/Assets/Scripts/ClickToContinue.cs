using UnityEngine;
using System.Collections;

public class ClickToContinue : MonoBehaviour {
	public string scene;
	public int level = 0;
	public bool loadlock;
	public GameObject clickText;
	// Use this for initialization
	void Start () {
		try {
			level = PlayerPrefs.GetInt("level");
			if (level < 1) {
				PlayerPrefs.SetInt ("level", 1);
			}
		} catch {
			PlayerPrefs.SetInt ("level", 1);
			level = 0;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !loadlock) {
			if (level < 1) {
				Application.LoadLevel ("training1");
			} else {
				loadScene ();
			}
		}
		if (Input.GetKey (KeyCode.Home)) {
			Application.Quit ();
		}
	}
	void unlock(){
		loadlock = false;
		Instantiate (clickText);
	}

	void loadScene() {
		loadlock = true;
		Application.LoadLevel (scene);
	}


}
