using UnityEngine;
using System.Collections;

public class Player_Death : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if(player.transform.position.y <= -6)
		{
			Application.LoadLevel("GameOver");
		}
	
	}
}
