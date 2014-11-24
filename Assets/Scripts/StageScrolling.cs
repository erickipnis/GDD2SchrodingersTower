using UnityEngine;
using System.Collections;

public class StageScrolling : MonoBehaviour {

	GameObject stage;
	GameObject score;
	GameObject survived;

	GameObject playablePre;
	GameObject[] playables;

	GameObject guns;

	int incrementer = 0;
	int change = 0;
	int definedScroll = 1000;

	int levelSurvived = 0;

	int timeToScroll;

	int current = 0;

	bool move = false;
	bool scroll = false;
	bool changeStart = false;

	Vector2 startPosition;
	Vector2 gunCurrent;

	int numLevels = 0;
	int numGoneThrough = 0;

	// Use this for initialization
	void Start () {
		stage = GameObject.FindGameObjectWithTag("Stage");

		score = GameObject.FindGameObjectWithTag("Score");

		survived = GameObject.FindGameObjectWithTag("Levels");

		startPosition = stage.transform.position;

		timeToScroll = definedScroll;

		playables = GameObject.FindGameObjectsWithTag("Playable");

		guns = GameObject.FindGameObjectWithTag("Gun");

		gunCurrent = guns.transform.position;

		/*foreach(GameObject play in playables)
		{
			//numLevels++;

			//if(play.GetComponent<Gun>() != null)
			//{}

			gun.GetComponent<GunScript>().enabled = false;
			gun.GetComponent<SpriteRenderer>().enabled = false;


		}*/

		guns.GetComponent<GunScript>().enabled = true;
		guns.GetComponent<SpriteRenderer>().enabled = true;
		guns.GetComponent<Collider2D>().enabled = false;
		//DontDestroyOnLoad(score);
	}
	
	// Update is called once per frame
	void Update () {
	    
		GUIText scoreTm = (GUIText)score.GetComponent(typeof(GUIText));

		GUIText levelTm = (GUIText)survived.GetComponent(typeof(GUIText));

		if(changeStart)
		{
			startPosition = stage.transform.position;
			changeStart = false;
		}

		if(move)
		{
			Vector2 currentPosition = stage.transform.position;
			Vector2 startP = startPosition;

			guns.GetComponent<GunScript>().enabled = false;
			guns.GetComponent<SpriteRenderer>().enabled = false;
			guns.GetComponent<Collider2D>().enabled = false;


			guns.transform.position = gunCurrent;
			
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

				guns.GetComponent<GunScript>().enabled = true;
				guns.GetComponent<SpriteRenderer>().enabled = true;
				guns.GetComponent<Collider2D>().enabled = false;

				/*playables[current].SetActive(false);
				
				current++;
				
				playables[current].SetActive(true);*/

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