﻿using UnityEngine;
using System.Collections;

public class StageScrolling : MonoBehaviour {

	GameObject stage;
	GameObject score;
	GameObject survived;

	int incrementer = 0;
	int change = 0;
	int definedScroll = 3000;

	int levelSurvived = 0;

	int timeToScroll;

	bool move = false;
	bool scroll = false;
	bool changeStart = false;

	Vector2 startPosition;

	// Use this for initialization
	void Start () {
		stage = GameObject.FindGameObjectWithTag("Stage");

		score = GameObject.FindGameObjectWithTag("Score");

		survived = GameObject.FindGameObjectWithTag("Levels");

		startPosition = stage.transform.position;

		timeToScroll = definedScroll;

		DontDestroyOnLoad(score);
	}
	
	// Update is called once per frame
	void Update () {
	    
		TextMesh scoreTm = (TextMesh)score.GetComponent(typeof(TextMesh));

		TextMesh levelTm = (TextMesh)survived.GetComponent(typeof(TextMesh));

		if(changeStart)
		{
			startPosition = stage.transform.position;
			changeStart = false;
		}

		if(move)
		{
			Vector2 currentPosition = stage.transform.position;
			Vector2 startP = startPosition;
			
			while(scroll)
			{
				currentPosition.y -= 0.1f;
				
				stage.transform.position = currentPosition;
		
				scroll = false;
				incrementer = 0;
				break;
			}

			if((currentPosition.y-startP.y) <= -8.7f)
			{
				move = false;
				changeStart = true;

				levelSurvived++;

				levelTm.text = levelSurvived.ToString();
			}

			if(!scroll)
			{
				incrementer++;
			}
			if(incrementer >= 8)
			{
				scroll = true;
			}
		}
		else
		{

			if(timeToScroll <= 0)
			{
				move = true;
				timeToScroll = definedScroll;
			}
			else
			{
				timeToScroll--;
			}

			scoreTm.text = (timeToScroll/60).ToString();

		}
	}
}