using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	public AudioSource music;

	public bool startPlaying;

	public BeatScroller bs;

	public int currentScore;
	public int scorePerNote = 100;
	public int scorePerGood = 125;
	public int scorePerPerfect = 150;
	public int scorePerBar = 20;
	public int currentMult;
	public int multiplierTracker;
	public int[] multilpierThresh;

	public Text scoreText;
	public Text multiText;

	public float totalNotes;
	public float normalHits;
	public float goodHits;
	public float perfectHits;
	public float missedHits;

	public int screen = 0;
	public int gameFinished = 0;

	public GameObject resultsScreen;
	public Text percentageHit, normalsText, goodsText, perfectsText, missText, rankText, finalScoreText;

	public static GameManager instance;

	public int buttonData;
	public int resetData;
	public int potData;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		instance = this;

		scoreText.text = "Score: 0";
		currentMult = 1;

		totalNotes = FindObjectsByType<NoteObject>(FindObjectsSortMode.None).Length;
	}

	// Update is called once per frame
	void Update() {
		
		if (!startPlaying) {
			if (Input.anyKeyDown) {
				startPlaying = true;
				BeatScroller.hasStarted = true;
				music.Play();
			}
		} else {
			if (!music.isPlaying && !resultsScreen.activeInHierarchy) {
				
				resultsScreen.SetActive(true);
				gameFinished = 1;

				normalsText.text = "" + normalHits;
				goodsText.text = "" + goodHits;
				perfectsText.text = "" + perfectHits;
				missText.text = "" + missedHits;

				float totalHit = normalHits + goodHits + perfectHits;

				float percentHit = totalHit / totalNotes * 100;
				percentHit = (float) Math.Floor((double) percentHit * 100) / 100;

				percentageHit.text = percentHit + "%";

				string rankVal = "F";

				if (percentHit > 40) {
					rankVal = "D";
					if (percentHit > 55) {
						rankVal = "C";
						if (percentHit > 70) {
							rankVal = "B";
							if (percentHit > 85) {
								rankVal = "A";
								if (percentHit > 95) {
									rankVal = "S";
								}
							}
						}
					}
				}

				rankText.text = rankVal;
				finalScoreText.text = currentScore.ToString();
			}
		}
	}

	public void NoteHit() {
		if (currentMult - 1 < multilpierThresh.Length) {
			multiplierTracker++;
			if (multilpierThresh[currentMult - 1] <= multiplierTracker) {
				multiplierTracker = 0;
				currentMult++;
				multiText.text = "Multiplier: x" + currentMult;
			}
		}
		// currentScore += scorePerNote * currentMult;
		scoreText.text = "Score: " + currentScore;
	}

	public void NormalHit() {
		Debug.Log("Normal Hit");
		currentScore += scorePerNote * currentMult;
		normalHits++;
		NoteHit();
	}
	
	public void GoodHit() {
		Debug.Log("Good Hit");
		currentScore += scorePerGood * currentMult;
		goodHits++;
		NoteHit();
	}

	public void PerfectHit() {
		Debug.Log("Perfect Hit");
		currentScore += scorePerPerfect * currentMult;
		perfectHits++;
		NoteHit();
	}

	public void NoteMiss() {
		Debug.Log("Missed Note");
		multiplierTracker = 0;
		currentMult = 1;
		multiText.text = "Multiplier: x" + currentMult;
		missedHits++;
	}

	public void BarHit() {
		Debug.Log("Bar Hit");
		currentScore += scorePerBar * currentMult;
		scoreText.text = "Score: " + currentScore;
	}

	public void BarMiss() {
		Debug.Log("Bar Missed");
		multiplierTracker = 0;
		currentMult = 1;
		multiText.text = "Multiplier: x" + currentMult;
	}
		
	
}
