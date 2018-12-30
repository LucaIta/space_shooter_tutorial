﻿using System.Collections;
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

	void Start() {
		score = 0;
		UpdateScore();
		StartCoroutine(SpawnWaves() );
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
		}
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	public void incrementScore(int incrementValue) {
		score += incrementValue;
		UpdateScore();
	}



}
