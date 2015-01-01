using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {
	[HideInInspector]
	public bool paused = false;
	private bool createdMenu = false;
	public Object gameMenu;
	private Object gameMenuClone;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.P))
		{
			paused = !paused; 
		}

		if (paused) {
			Time.timeScale = 0;
			if (!createdMenu) {
				gameMenuClone = Object.Instantiate(gameMenu, new Vector3(0,6,0),transform.rotation);	
				createdMenu = true;
			}
		} else {
			Time.timeScale = 1;
			GameObject.Destroy(gameMenuClone);
			createdMenu = false;
		}
	}

	void OnMouseDown() {
		paused = !paused;
	
	}
}
