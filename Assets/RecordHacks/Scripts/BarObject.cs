using UnityEngine;

public class BarObject : MonoBehaviour {

  bool track;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		
	}


	// Update is called once per frame
	void Update() {
		if (track) {
			gameObject.SetActive(false);

			GameManager.instance.BarHit();

		} else if (gameObject.activeSelf && transform.position.y < -1.3) {
			gameObject.SetActive(false);
			Debug.Log("I MISSED");
			GameManager.instance.BarMiss();
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
    	track = true;
		}
	}
}
