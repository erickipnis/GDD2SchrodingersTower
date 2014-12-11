using UnityEngine;
using System.Collections;

public class ElectricPlatforms : MonoBehaviour {

	bool isDangerous;
	bool cooldown;
	SpriteRenderer renderer;
	float timeElapsed = 0;
	Animator anim;

	// Use this for initialization
	void Start () {
		isDangerous = false;
		cooldown = false;
		anim=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		float randomNumber = Random.value * 100;

		if (isDangerous || cooldown)
		{
			timeElapsed += Time.deltaTime;
		}
	//	Debug.Log(timeElapsed);

		//Debug.Log(randomNumber);

		if ((int)randomNumber == 1)
		{
			if (!cooldown)
			{
				isDangerous = true;
			}
		}

		if (timeElapsed >= 3 & isDangerous)
		{
			isDangerous = false;
			timeElapsed = 0;
			cooldown = true;
		}
		else if (timeElapsed >= 3 & cooldown)
		{
			cooldown = false;
			timeElapsed = 0;
		}

		anim.SetBool("Dangerous",isDangerous);

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
			GameObject[] guns = GameObject.FindGameObjectsWithTag("Gun");
			for(int i = 0; i < guns.Length; i++)
			{
				DestroyImmediate(guns[i]);
				StageScrolling.levelSurvived = 0;
			}

			Destroy(coll.gameObject);
			Application.LoadLevel("GameOver");
		}
	}
}
