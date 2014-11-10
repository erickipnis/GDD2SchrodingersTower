using UnityEngine;
using System.Collections;

public class StageScrolling : MonoBehaviour {

	GameObject stage;

	int incrementer = 0;
	int change = 0;
	int timeToScroll = 0;

	bool move = false;
	bool scroll = false;
	bool changeStart = false;

	Vector2 startPosition;

	// Use this for initialization
	void Start () {
		stage = GameObject.FindGameObjectWithTag("Stage");
		startPosition = stage.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    
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
			if(timeToScroll >= 300)
			{
				move = true;
				timeToScroll = 0;
			}
			else
			{
				timeToScroll++;
			}
		}
	}
}