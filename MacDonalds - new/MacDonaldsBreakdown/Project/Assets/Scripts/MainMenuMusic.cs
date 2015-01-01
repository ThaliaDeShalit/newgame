using UnityEngine;
using System.Collections;

public class MainMenuMusic : MonoBehaviour {

	void Awake () {
		GameObject gameMusic = GameObject.Find("GameMusic");
		if (gameMusic) {
			Destroy(gameMusic);
		}
		DontDestroyOnLoad(gameObject);
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}

}
