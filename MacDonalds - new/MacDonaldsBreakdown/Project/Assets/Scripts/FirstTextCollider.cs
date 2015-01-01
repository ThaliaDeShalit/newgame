using UnityEngine;
using System.Collections;

public class FirstTextCollider : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		GameObject.FindWithTag ("MoveHeader").SetActive (true);
		GameObject.FindWithTag ("ShootHeader").SetActive (false);
		//gameObject.SetActive (false);
		Debug.Log ("1");
		//StartCoroutine (wait(2.0f));
		Debug.Log ("2");
		gameObject.SetActive (true);
		Debug.Log ("3");
		
	}
	
	//setting delay to 2 seconds
	IEnumerator wait(float seconds) {
		yield return new WaitForSeconds(seconds);
		Debug.Log ("Waited a sec");
	}
	
	void OnTriggerEnter2D() {
		Debug.Log ("entering ontriggerenter");
		GameObject.FindWithTag ("SecondText").SetActive (true);
		gameObject.SetActive (false);
		
	}
	
}
