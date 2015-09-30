using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {
	public Texture fadeOutTexture;
	public float fadeSpeed;
	int drawDepth = -1000;
	float alpha = 1.0f;
	int fadeDirection = 1;
	// Use this for initialization
	void OnGui(){
		alpha += fadeDirection * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp (alpha, 0, 1);
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}
}
