using UnityEngine;
using System.Collections;




public class MainMenuScript : MonoBehaviour {

	[HideInInspector]
	public enum Button{Quit, Sound, Play, About}

	public Button button;

	void Start() {

		if (button == Button.Sound)
				if (!PlayerPrefs.HasKey ("Music")) {
						PlayerPrefs.SetString ("Music", "On");
						audio.mute = false;
				}

	}

	void OnMouseDown() {
		if (button == Button.Quit)
			Application.Quit ();
		else if (button == Button.Play)
			Application.LoadLevel ("GrassLevel2");
		else if (button == Button.About)
			Application.LoadLevel ("About");
		else if (PlayerPrefs.GetString("Music") == "On") {
			PlayerPrefs.SetString ("Music", "Off");
			audio.mute = true;
		} else {
			PlayerPrefs.SetString ("Music", "On");
			audio.mute = false;
		}
	}

}
