using UnityEngine;
using System.Collections;

public class GameMenuButtons : MonoBehaviour {

	public enum GameMenuButton {Resume, MainMenu, Music, Effects}
	public GameMenuButton button;

	private Pauser pauser;
	// Use this for initialization
	void Start () {

		GameObject menu = GameObject.Find ("MenuButton"); 
		pauser = menu.GetComponent<Pauser>();

		if (button == GameMenuButton.Effects)
			if (!PlayerPrefs.HasKey ("Effects"))
				PlayerPrefs.SetString ("Effects", "On");


	
	}
	
	// Update is called once per frame
	void OnMouseDown() {
		if (button == GameMenuButton.Resume)
						pauser.paused = false;
		if (button == GameMenuButton.MainMenu)
						Application.LoadLevel ("MainMenu");
		if (button == GameMenuButton.Music)
						MusicChanger ();
		if (button == GameMenuButton.Effects)
						EffectsChanger ();
		
	}

	void MusicChanger() {
		GameObject musicDisableButton = transform.parent.FindChild ("MusicDisabled").gameObject;
		Debug.Log ("Music Changer: " + musicDisableButton.activeSelf);
		musicDisableButton.SetActive (!musicDisableButton.activeSelf);
		if (PlayerPrefs.GetString("Sound") == "On") {
			audio.mute = true;
			PlayerPrefs.SetString ("Sound", "Off");
		} else {
			PlayerPrefs.SetString ("Sound", "On");
			audio.mute = false;
		}
	}

	void EffectsChanger() {

		GameObject effectsDisableButton = transform.parent.FindChild ("EffectsDisabled").gameObject;
		Debug.Log ("Effects Changer: " + effectsDisableButton.activeSelf);
		effectsDisableButton.SetActive (!effectsDisableButton.activeSelf);
		if (PlayerPrefs.GetString("Effects") == "On") {
			AudioListener.volume = 0;
			PlayerPrefs.SetString ("Effects", "Off");
		} else {
			PlayerPrefs.SetString ("Effects", "On");
			AudioListener.volume = 1;
		}

	}
}
