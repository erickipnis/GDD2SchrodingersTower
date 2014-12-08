using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour
{

	public float speed = 2.0f;

	void Start()
	{
	
	}
	// 
	// Update is called once per frame
	void Update()
	{
		Vector4 c = new Vector4(guiText.material.color.r, guiText.material.color.g, guiText.material.color.b, Mathf.PingPong(Time.time * speed, 1.0f));
		guiText.material.color = c;
	}
}