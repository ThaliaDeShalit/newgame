using UnityEngine;
using System.Collections;

public class GameMusic : MonoBehaviour {

	void Awake() {
		GameObject mainMenuMusic = GameObject.Find("MainMenuMusic");
		if (mainMenuMusic) {
			Destroy(mainMenuMusic);
		}
		DontDestroyOnLoad(gameObject);
	}
}
