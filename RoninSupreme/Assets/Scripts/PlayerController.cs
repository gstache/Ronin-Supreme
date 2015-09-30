using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Vector2 move = new Vector2();
	public bool hasJumpedOnce = false;
	public bool hasJumpedTwice = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		move.x = 0;
		//move.y = move.y;
		if (Input.touchCount > 0) {
			float xPos = Input.GetTouch(0).position.x;
			float width = Screen.width;
			if(xPos < width/2.0f) { 
				move.y += .1f;
			} else if (xPos > width/2.0f){
				move.x = 1;
			} 
			if(Input.GetTouch (0).phase == TouchPhase.Ended){
				move.y = 0;
			}
		} 
		if (Input.GetKey ("up")) {
			move.y += .1f;

		} 
		if(Input.GetKeyUp("up")){
			move.y = 0;
		}
		if (Input.GetKey ("left")) {
			move.x = 1;
		}

		if (Input.GetKey(KeyCode.Escape)) {
			Application.LoadLevel ("splash");
		}

		if (Input.GetKey (KeyCode.Home)) {
			Application.Quit ();
		}
	}


}
