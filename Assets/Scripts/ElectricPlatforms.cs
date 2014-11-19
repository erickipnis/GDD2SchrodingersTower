using UnityEngine;
using System.Collections;

public class ElectricPlatforms : MonoBehaviour {

	bool isDangerous;
	SpriteRenderer renderer;
	float timeElapsed = 0;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer>();
		renderer.color = new Color(255f, 0f, 0f);
		isDangerous = false;
	}
	
	// Update is called once per frame
	void Update () {

		float randomNumber = Random.value * 100;

		timeElapsed += Time.deltaTime;
	//	Debug.Log(timeElapsed);

		//Debug.Log(randomNumber);

		if ((int)randomNumber <= 1)
		{
			isDangerous = true;
			renderer.color = new Color(255f, 0f, 0f);
		}

		if (timeElapsed >= 3)
		{
			isDangerous = false;
			timeElapsed = 0;
			renderer.color = new Color(255f, 255f, 255f);
		}

		//{
		//	isDangerous = false;
		//	renderer.color = new Color(255f, 255f, 255f);
		//}
		//SpriteRenderer.color = new Color(0f, 0f, 255f);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player" && isDangerous)
		{
			Destroy(coll.gameObject);
			Application.LoadLevel("GameOver");
		}
	}
}
