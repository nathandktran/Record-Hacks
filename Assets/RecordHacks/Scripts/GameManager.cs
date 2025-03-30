using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public AudioSource music;

	public bool startPlaying;

	public BeatScroller bs;

	public int currentScore;
	public int scorePerNote = 100;
	public int currentMult;
	public int multiplierTracker;
	public int[] multilpierThresh;

	public Text scoreText;
	public Text multiText;

	public static GameManager instance;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		instance = this;

		scoreText.text = "Score: 0";
		currentMult = 1;
	}

	// Update is called once per frame
	void Update() {
		if (!startPlaying) {
			if (Input.anyKeyDown) {
				startPlaying = true;
				bs.hasStarted = true;
				music.Play();
			}
		}
	}

	public void NoteHit() {
		Debug.Log("Hit On Time");
		if (currentMult - 1 < multilpierThresh.Length) {
			multiplierTracker++;
			if (multilpierThresh[currentMult - 1] <= multiplierTracker) {
				multiplierTracker = 0;
				currentMult++;
				multiText.text = "Multiplier: x" + currentMult;
			}
		}
		currentScore += scorePerNote * currentMult;
		scoreText.text = "Score: " + currentScore;
	}

	public void NoteMiss() {
		Debug.Log("Missed Note");
		multiplierTracker = 0;
		currentMult = 1;
		multiText.text = "Multiplier: x" + currentMult;
	}
}
