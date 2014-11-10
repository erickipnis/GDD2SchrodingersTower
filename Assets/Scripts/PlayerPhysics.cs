using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {

	//This script is attached to the player
	float jumpPower = 1.0f; //assign an integer for jump power
	Vector2 jumpVector;
	KeyCode jumpKey = KeyCode.UpArrow; //assign jump button here
	KeyCode downKey = KeyCode.DownArrow; //assign down button here

	GameObject player = GameObject.FindWithTag("Player");
	//BoxCollider2D box = player.GetComponent(BoxCollider2D) as BoxCollider2D; //assign the BoxCollider2D of your player and set it to is trigger
	
	void Update () 
	{
		//Jump
		if(Input.GetKeyDown(jumpKey))
		{	
			jumpVector = Rigidbody2D.velocity;
			jumpVector.y = 1.0f;
			rigidbody2D.velocity.y = jumpVector.y;
		}        
		
		// If you want your object to go down on your platform
		// Similar to the Contra game platform feature.
		//if(Input.GetKeyDown(downKey))
		//{
		//	box.isTrigger = true;
		//}
	}        
	
	
	// have a seperated gameobject that has a boxcollider2d make sure is trigger is checked
	// in my case I named it Trigger and parent it to the platform
	// and make sure it is just a little under your platform.
	// your platform should have a boxcollider2D is trigger off
	
	// detects trigger and makes your players boxcollider2D isTrigger true which disables
	// collision and make it pass through your platform
	
	/*void OnTriggerEnter2D (Collider2D hitInfo)
	{
		if(hitInfo.name == "Player") 
		{
			box.isTrigger = true;
		}
	}
	
	
	// Exits your Trigger and set your player Collider2D.isTrigger false, which makes it collide
	// to your platform again.
	
	void OnTriggerExit2D (Collider2D hitInfo)
	{
		if(hitInfo.name == "Trigger") 
		{
			box.isTrigger = false;
		}
	}*/
}
