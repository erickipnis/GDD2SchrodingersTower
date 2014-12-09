using UnityEngine;
using System.Collections;

public class StageScrolling : MonoBehaviour {

	GameObject stage;
	GameObject score;
	GameObject survived;

	GameObject playablePre;
	GameObject[] playables;

	GameObject guns;
	GameObject[] allGuns;

	int incrementer = 0;
	int change = 0;
	int definedScroll = (int)990;

	public static int levelSurvived = 0;

	int timeToScroll;

	int current = 0;

	bool move = false;
	bool scroll = false;
	bool changeStart = false;

	Vector2 startPosition;
	public static Vector2 gunCurrent;
	public static Vector2 gunCurrent2;
	public static Vector2 gunCurrent3;
	public static Vector2 gunCurrent4;
	public static Vector2 gunCurrent5;

	int numLevels = 0;
	int numGoneThrough = 0;

	int numGuns = 0;

	// Use this for initialization
	void Start () {
		stage = GameObject.FindGameObjectWithTag("Stage");

		score = GameObject.FindGameObjectWithTag("Score");

		survived = GameObject.FindGameObjectWithTag("Levels");

		startPosition = stage.transform.position;

		timeToScroll = definedScroll + (numLevels * 62);

		playables = GameObject.FindGameObjectsWithTag("Playable");

		guns = GameObject.FindGameObjectWithTag("Gun");

		allGuns = GameObject.FindGameObjectsWithTag("Gun");


		gunCurrent = guns.transform.position;


		gunCurrent2 = new Vector2(0,0);
		gunCurrent3 = new Vector2(0,0);
		gunCurrent4 = new Vector2(0,0);
		gunCurrent5 = new Vector2(0,0);

		
		guns.GetComponent<GunScript>().enabled = true;
		guns.GetComponent<SpriteRenderer>().enabled = true;
		guns.GetComponent<Collider2D>().enabled = false;


		foreach(GameObject gun in allGuns)
		{
			gun.GetComponent<GunScript>().enabled = true;
			gun.GetComponent<SpriteRenderer>().enabled = true;
			gun.GetComponent<Collider2D>().enabled = false;

		}

		/*foreach(GameObject play in playables)
		{
			//numLevels++;

			//if(play.GetComponent<Gun>() != null)
			//{}

			gun.GetComponent<GunScript>().enabled = false;
			gun.GetComponent<SpriteRenderer>().enabled = false;


		}*/


		//DontDestroyOnLoad(score);
	}
	
	// Update is called once per frame
	void Update () {
	    
		GUIText scoreTm = (GUIText)score.GetComponent(typeof(GUIText));

		GUIText levelTm = (GUIText)survived.GetComponent(typeof(GUIText));

		allGuns = GameObject.FindGameObjectsWithTag("Gun");
		numGuns = 0;

		foreach(GameObject gun in allGuns)
		{
			numGuns++;
		}

		if(changeStart)
		{
			startPosition = stage.transform.position;
			changeStart = false;
		}

		if(move)
		{
			GearRotate.rotate = true;

			Vector2 currentPosition = stage.transform.position;
			Vector2 startP = startPosition;
		
			guns.GetComponent<GunScript>().enabled = false;
			guns.GetComponent<SpriteRenderer>().enabled = false;
			guns.GetComponent<Collider2D>().enabled = false;
			
			
			guns.transform.position = gunCurrent;
			
			foreach(GameObject gun in allGuns)
			{
				gun.GetComponent<GunScript>().enabled = false;
				gun.GetComponent<SpriteRenderer>().enabled = false;
				//gun.GetComponent<Collider2D>().enabled = false;
				
			}

			if(numGuns == 2)
			{
				allGuns[1].transform.position = gunCurrent2;
			}
			if(numGuns == 3)
			{
				allGuns[1].transform.position = gunCurrent2;
				allGuns[2].transform.position = gunCurrent3;
			}
			if(numGuns == 4)
			{
				allGuns[1].transform.position = gunCurrent2;
				allGuns[2].transform.position = gunCurrent3;
				allGuns[3].transform.position = gunCurrent4;
			}
			if(numGuns == 5)
			{
				allGuns[1].transform.position = gunCurrent2;
				allGuns[2].transform.position = gunCurrent3;
				allGuns[3].transform.position = gunCurrent4;
				allGuns[4].transform.position = gunCurrent5;
			}
			
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

				LevelManager.gunSpawned = false;

				levelSurvived++;



				levelTm.text = levelSurvived.ToString();


				guns.GetComponent<GunScript>().enabled = true;
				guns.GetComponent<SpriteRenderer>().enabled = true;
				guns.GetComponent<Collider2D>().enabled = false;


				foreach(GameObject gun in allGuns)
				{
					gun.GetComponent<GunScript>().enabled = true;
					gun.GetComponent<SpriteRenderer>().enabled = true;
					//gun.GetComponent<Collider2D>().enabled = false;
					
				}

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
			GearRotate.rotate = false;

			if(timeToScroll <= 0)
			{
				move = true;
				timeToScroll = definedScroll  + ((int)(levelSurvived * 312.5));

				Debug.Log(timeToScroll);

				Debug.Log(definedScroll  + (levelSurvived * 312));

			}
			else
			{
				timeToScroll--;
			}

			scoreTm.text = ((int)(timeToScroll/62.5)).ToString();

		}

		if(levelSurvived == 10 && timeToScroll == 0)
		{
			levelSurvived = 0;
			for(int i = 0; i < allGuns.Length; i++)
			{
				Destroy(allGuns[i]);
			}
			Application.LoadLevel("Win");
		}
	}
}