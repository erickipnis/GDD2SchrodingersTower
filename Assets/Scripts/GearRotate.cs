using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GearRotate : MonoBehaviour {

	GameObject gearPre;
	GameObject[] Rgears;
	GameObject[] Lgears;

	public static bool rotate;

	// Use this for initialization
	void Start () {

		Rgears = GameObject.FindGameObjectsWithTag("GearR");

		Lgears = GameObject.FindGameObjectsWithTag("GearL");

		rotate = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(rotate)
		{
			foreach(GameObject gear in Rgears)
			{
				gear.transform.Rotate(0,0, -5*Time.deltaTime);

			}

			foreach(GameObject gear in Lgears)
			{
				gear.transform.Rotate(0,0, 5*Time.deltaTime);
				
			}
		}
	
	}
}
