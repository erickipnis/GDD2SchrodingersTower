using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	GameObject cannon;
	public GameObject rightCannonPrefab;
	public GameObject leftCannonPrefab;
	public GameObject topCannonPrefab;
	public static bool gunSpawned;

	// Use this for initialization
	void Start () 
	{
		gunSpawned = false;
		rightCannonPrefab = Resources.Load("Prefabs/Guns/RightGun", typeof(GameObject)) as GameObject;
		topCannonPrefab = Resources.Load("Prefabs/Guns/TopGunLeft", typeof(GameObject)) as GameObject;
		leftCannonPrefab = Resources.Load("Prefabs/Guns/LeftGun", typeof(GameObject)) as GameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (StageScrolling.levelSurvived == 2 && gunSpawned == false)
		{
			cannon = (GameObject) GameObject.Instantiate(rightCannonPrefab, new Vector3(6.434641f, -0.1688184f, 0f), Quaternion.identity);
			gunSpawned = true;

			StageScrolling.gunCurrent2 = new Vector2(6.434641f, -0.1688184f);
		}
		else if (StageScrolling.levelSurvived == 4 && gunSpawned == false)
		{
			cannon = (GameObject) GameObject.Instantiate(topCannonPrefab, new Vector3(6.588336f, 2.8639318f, 0f), Quaternion.identity);
			gunSpawned = true;

			StageScrolling.gunCurrent3 = new Vector2(6.588336f, 2.8639318f);
		}
		else if (StageScrolling.levelSurvived == 6 && gunSpawned == false)
		{
			cannon = (GameObject) GameObject.Instantiate(rightCannonPrefab, new Vector3(6.434641f, -2.288184f, 0f), Quaternion.identity);
			gunSpawned = true;

			StageScrolling.gunCurrent4 = new Vector2(6.434641f, -2.288184f);
		}
		else if (StageScrolling.levelSurvived == 8 && gunSpawned == false)
		{
			cannon = (GameObject) GameObject.Instantiate(leftCannonPrefab, new Vector3(-6.390183f, -3.588184f, 0f), Quaternion.identity);
			gunSpawned = true;

			StageScrolling.gunCurrent5 = new Vector2(-6.390183f, -3.588184f);
		}
	}
}
