using UnityEngine;

public class NoteObject : MonoBehaviour {

	public bool canBePressed;

	public KeyCode keyToPress;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
			
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(keyToPress)) {
			if (canBePressed) {
				gameObject.SetActive(false);

				// GameManager.instance.NoteHit();

				if (transform.position.y > 1.25 || transform.position.y < 0.75) { 
					GameManager.instance.NormalHit();
				} else if (transform.position.y > 1.05 || transform.position.y < 0.95) {
					GameManager.instance.GoodHit();
				} else {
					GameManager.instance.PerfectHit();
				}


			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Activator") {
			canBePressed = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (gameObject.activeSelf) {
			if (other.tag == "Activator") {
				canBePressed = false;

				GameManager.instance.NoteMiss();
			}
		}
	}
}
