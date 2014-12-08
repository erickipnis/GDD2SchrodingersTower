using UnityEngine;
using System.Collections;

public class PlayerColl : MonoBehaviour {

	GameObject cat;
	GameObject[] guns;


	// Use this for initialization
	void Start () {
	
		cat = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		guns = GameObject.FindGameObjectsWithTag("Gun");

		if(cat.transform.position.x < -5.8f && cat.transform.position.y < -4f)
		{
			foreach(GameObject gun in guns)
			{
				if(gun.transform.position.y < -4.5f && gun.transform.position.x <= 0.1264596f)
				{
					Destroy(this.gameObject);
					Application.LoadLevel("GameOver");
				}
			}
		}
		if( cat.transform.position.x > 6.3f && cat.transform.position.y < -4f)
		{
			foreach(GameObject gun in guns)
			{
				if(gun.transform.position.y < -4.5f && gun.transform.position.x >= 6.434641f)
				{
					Destroy(this.gameObject);
					Application.LoadLevel("GameOver");
				}
			}
		}
	}


}
