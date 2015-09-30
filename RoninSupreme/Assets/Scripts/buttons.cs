using UnityEngine;
using System.Collections;

public class buttons : MonoBehaviour {

	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en"; 
	private const string FACEBOOK_APP_ID = "498554323646158";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";
	
	// Update is called once per frame
	public void ChangeScene(string scene) {
		Application.LoadLevel(scene);
	}
	

	public void ShareToTwitter (string textToDisplay)
	{
		textToDisplay += ". I scored "+ PlayerPrefs.GetFloat("score")+ "points. Try and beat me https://goo.gl/7GuSib";
		Application.OpenURL(TWITTER_ADDRESS +
		                    "?text=" + WWW.EscapeURL(textToDisplay) +
		                    "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
	}


	
	public void ShareToFacebook (string linkParameter)
	{
		linkParameter = "https://www.facebook.com/roninsupreme";
		string nameParameter = "RoninSupreme"; 
		string captionParameter = "There Can Only be ONE!"; 
		string descriptionParameter = "You only scored "+ PlayerPrefs.GetFloat("score").ToString() + " points in your beefy, cheesy quest for vengeance. Your friends can certainly do better"; 
		string pictureParameter = "https://pbs.twimg.com/media/CPHMuhdUcAE56Kf.png"; 
		string redirectParameter = "http://www.facebook.com/";
		Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
		                     "&link=" + WWW.EscapeURL(linkParameter) +
		                     "&name=" + WWW.EscapeURL(nameParameter) +
		                     "&caption=" + WWW.EscapeURL(captionParameter) + 
		                     "&description=" + WWW.EscapeURL(descriptionParameter) + 
		                     "&picture=" + WWW.EscapeURL(pictureParameter) + 
		                     "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
	}

	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel ("main_stage");
		}
	}
}
