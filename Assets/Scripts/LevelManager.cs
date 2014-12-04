using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	GameObject cannon;
	public GameObject rightCannonPrefab;
	public GameObject topCannonPrefab;
	public static bool gunSpawned;

	// Use this for initialization
	void Start () 
	{
		gunSpawned = false;
		rightCannonPrefab = Resources.Load("Prefabs/Guns/RightGun", typeof(GameObject)) as GameObject;
		topCannonPrefab = Resources.Load("Prefabs/Guns/TopGunLeft", typeof(GameObject)) as GameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (StageScrolling.levelSurvived == 1 && gunSpawned == false)
		{
			cannon = (GameObject) GameObject.Instantiate(rightCannonPrefab, new Vector3(6.434641f, -0.2688184f, 0f), Quaternion.identity);
			gunSpawned = true;
		}
		else if (StageScrolling.levelSurvived == 2 && gunSpawned == false)
		{
			cannon = (GameObject) GameObject.Instantiate(topCannonPrefab, new Vector3(6.588336f, 2.8639318f, 0f), Quaternion.identity);
			gunSpawned = true;
		}
		else if (StageScrolling.levelSurvived == 3 && gunSpawned == false)
		{
			cannon = (GameObject) GameObject.Instantiate(rightCannonPrefab, new Vector3(6.434641f, -0.2688184f, 0f), Quaternion.identity);
			gunSpawned = true;
		}
		else if (StageScrolling.levelSurvived == 4 && gunSpawned == false)
		{
			cannon = (GameObject) GameObject.Instantiate(rightCannonPrefab, new Vector3(6.434641f, -0.2688184f, 0f), Quaternion.identity);
			gunSpawned = true;
		}
	}
}
