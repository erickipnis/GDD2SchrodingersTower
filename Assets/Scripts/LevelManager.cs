using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	GameObject cannon;
	public GameObject cannonPrefab;
	public static bool gunSpawned;

	// Use this for initialization
	void Start () 
	{
		gunSpawned = false;
		cannonPrefab = Resources.Load("Prefabs/Guns/RightGun", typeof(GameObject)) as GameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (StageScrolling.levelSurvived == 1 && gunSpawned == false)
		{
			cannon = (GameObject) GameObject.Instantiate(cannonPrefab, new Vector3(6.434641f, -0.2688184f, 0f), Quaternion.identity);
			gunSpawned = true;
		}
	}
}
