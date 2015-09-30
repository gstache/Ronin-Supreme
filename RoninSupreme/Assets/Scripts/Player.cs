using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public bool standing;
	public bool attacking;
	private PlayerController controller;
	private Animator animator;
	public float speed;
	public float speedFactor;
	public bool jumped;
	public bool doubleJumped;
	public float moveYprev = 0;
	public float score;
	public int multiplier;
	int scoreCount;
	float prevX = 0.0f;
	// Use this for initialization
	void Start () {
		score = 0.0f;
		scoreCount = 0;
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, 0.0f);
		controller = gameObject.GetComponent<PlayerController> ();
		animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		score += Mathf.Round(transform.position.x/10);

		speed += (Time.deltaTime / speedFactor);
		gameObject.GetComponent<Rigidbody2D> ().velocity 
			= new Vector2 (speed,gameObject.GetComponent<Rigidbody2D> ().velocity.y);
		if (controller.move.x > 0) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce(new Vector2(40.0f,0.0f));

			attacking = true;
		} 

		if (controller.move.y > 0 && controller.move.x == 0) {

			if(!attacking && !doubleJumped && moveYprev < 1f){

				gameObject.GetComponent<Rigidbody2D> ().AddForce(new Vector2(0.0f,20.0f));
				standing = false;
				if(moveYprev < 0.2f) {
					gameObject.GetComponent<Rigidbody2D> ().velocity 
						= new Vector2 (speed,Mathf.Max(gameObject.GetComponent<Rigidbody2D> ().velocity.y,5.0f));
				}
				if(jumped && !standing && moveYprev == 0) {
			//		gameObject.GetComponent<Rigidbody2D> ().velocity 
			//			= new Vector2 (speed,1.0f);

					doubleJumped = true;
				} else {
					//gameObject.GetComponent<Rigidbody2D> ().AddForce(new Vector2(0.0f,30.0f));
					jumped = true;
				}

			}
		} 
		moveYprev = controller.move.y;
		if (attacking) {
			animator.SetInteger ("AnimState", 2);
		} else if (!standing && !attacking) {
			animator.SetInteger ("AnimState", 1);
		} else if (standing && !attacking) {
			animator.SetInteger ("AnimState", 0);
		
		} 

	}
	private void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag.Equals ("Terrain")) {
			standing = true;
			jumped = false;
			doubleJumped = false;
			if(transform.position.x == prevX){
				transform.position =new Vector3(prevX, transform.position.y +.5f,0);
			}
			prevX = transform.position.x;
	
		} else if (coll.gameObject.tag.Equals ("Vegetable") && attacking) {

			score += 100*multiplier;
			GameObject point = Instantiate(Resources.Load("pointObject")) as GameObject;
			point.transform.position = new Vector3(transform.position.x+7,transform.position.y + .5f,0);
			point.GetComponent<RandomSprite>().currentSprite = (multiplier - 1);
			multiplier += 1;
			if(multiplier > 19){multiplier = 19;}
		}
	}
	public void SetToZero(){
		animator.SetInteger ("AnimState", 0);
		attacking = false;
	}
	public void OnExplode(){
		PlayerPrefs.SetFloat ("score", score);
		GameObject point = Instantiate(Resources.Load("death_explosion")) as GameObject;
		point.transform.position = new Vector3(transform.position.x+2,transform.position.y-1,0);


	}

	//void OnGUI(){
	//	Rect pos = new Rect();
	//	pos.center = new Vector2 (Screen.width * 0.5f, 10);
	//	pos.size = new Vector2 (100, 30);
	//	GUI.Box(pos,"Score: "+score.ToString());
	//}
}
