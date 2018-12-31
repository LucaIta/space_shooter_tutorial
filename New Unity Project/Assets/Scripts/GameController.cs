using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoreText;
	private int score;
	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;

	void Start() {
		score = 0;
		restart = false;
		gameOver = false;
		restartText.text = "";
		gameOverText.text = "";
		UpdateScore();
		StartCoroutine(SpawnWaves() );
	}

	void Update() {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount ; i ++) 
			{
				// X position must be random, while Y and Z can be set from the IDE
				Vector3 spawnPosition = new Vector3(Random.Range (- spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
			if (gameOver) {
				restartText.text = "Press 'R' for restart";
				restart = true;
				break;
			};

		}
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	public void incrementScore(int incrementValue) {
		score += incrementValue;
		UpdateScore();
	}

	public void GameOver() {
		gameOverText.text = "Game Over !";
		gameOver = true;
	}


}
