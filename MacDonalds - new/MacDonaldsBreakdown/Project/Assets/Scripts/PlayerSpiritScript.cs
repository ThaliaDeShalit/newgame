using UnityEngine;
using System.Collections;

public class PlayerSpiritScript : MonoBehaviour {

	public float horSpeed = 0.2f;
	public float verSpeed = 0.2f;
	public float horBoundry = 1f;
	public float verBoundry = 15f;
	public float loseMenuAppears = 12f;
	public GameObject loseMenu;

	private float center;
	private Vector3 goalPos;
	private float z;
	private float lerpAdd = 0.3f;
	private GameObject pauseButton;
	private bool createdMenu = false;

	void Awake () {
		center = transform.position.x;
		z = transform.position.z;
		pauseButton = GameObject.Find("MenuButton");

		goalPos = new Vector3 (center - horBoundry, transform.position.y + verSpeed, z);
	}
	
	// Update is called once per frame
	void Update () {

		float y = transform.position.y;
		if (y > loseMenuAppears) {
			if (!createdMenu) {
				Debug.Log ("CreatedMenu1: " + createdMenu);
				createdMenu = true;
				Debug.Log ("CreatedMenu2: " + createdMenu);
				GameObject.Instantiate (loseMenu, loseMenu.transform.position, loseMenu.transform.rotation);
				Debug.Log ("CreatedMenu3: " + createdMenu);
				pauseButton.GetComponentInChildren<Pauser>().enabled = false;
				StopEnemies();
			}


		
		}
		if (transform.position.x > (center + horBoundry - 0.1)) {
			Vector3 currScale = transform.localScale;
			currScale.x *= -1;
			transform.localScale = currScale;
			goalPos = new Vector3 (center - horBoundry - lerpAdd, y + verSpeed, z);
		}
		else if (transform.position.x < (center - horBoundry + 0.1)) {
			Vector3 currScale = transform.localScale;
			currScale.x *= -1;
			transform.localScale = currScale;
			goalPos = new Vector3 (center + horBoundry + lerpAdd, y + verSpeed, z);
		}
		transform.position = Vector3.Lerp (transform.position, goalPos, horSpeed * Time.deltaTime);

		if (y > verBoundry)
						GameObject.Destroy (gameObject);
	
	}


	//setting delay to 2 seconds
	IEnumerator wait(float seconds) {
		yield return new WaitForSeconds(seconds);
		Debug.Log ("Waited a sec");
	}
	
	void StopEnemies() {
		Debug.Log ("entering StopEnemies");
		StartCoroutine (wait (2.0f));
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		Vector2 noMovement = new Vector2 (0, 0);
		foreach (GameObject enemy in enemies) {
			enemy.GetComponentInChildren<Enemy> ().enabled = false;
			enemy.rigidbody2D.velocity = noMovement;
			enemy.rigidbody2D.gravityScale = 0;
		}
	}
}
