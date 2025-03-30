using UnityEngine;

public class NoteObject : MonoBehaviour {

	public bool canBePressed;

	public KeyCode keyToPress;

	public int buttonNum;

	public GameObject hitEffect, goodEffect, perfectEffect, missEffect;



	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
			
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(keyToPress) 
				// || ((GameManager.instance.buttonData & (1<<buttonNum)) > 0)
				) {
			if (canBePressed) {
				gameObject.SetActive(false);

				// GameManager.instance.NoteHit();

				if (transform.position.y > 1.25 || transform.position.y < 0.75) { 
					GameManager.instance.NormalHit();
					Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
				} else if (transform.position.y > 1.05 || transform.position.y < 0.95) {
					GameManager.instance.GoodHit();
					Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
				} else {
					GameManager.instance.PerfectHit();
					Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
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
				Instantiate(missEffect, transform.position, missEffect.transform.rotation);
			}
		}
	}
}
