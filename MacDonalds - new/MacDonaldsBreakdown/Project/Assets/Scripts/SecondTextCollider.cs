﻿using UnityEngine;
using System.Collections;

public class SecondTextCollider : MonoBehaviour {
	
	void Start () {
		gameObject.SetActive (false);
	}
	
	void OnTriggerEnter2D() {
		GameObject.FindWithTag ("MoveHeader").SetActive (false);
		gameObject.SetActive (false);
		GameObject.FindWithTag ("ShootHeader").SetActive (true);
	}
}