using UnityEngine;
using System.Collections;

public class MovieActivate : MonoBehaviour {

	public MovieTexture movTexture;
	void Start() {
		renderer.material.mainTexture = movTexture;
		movTexture.Play();
	}
	void Update() {

		if (Input.GetKeyDown (KeyCode.Space)) {
						if (renderer.material.mainTexture)
								movTexture.Pause ();
						else
								movTexture.Play ();
				}
	}

}
