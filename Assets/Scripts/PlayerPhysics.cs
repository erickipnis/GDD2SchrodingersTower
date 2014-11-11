using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {

	//This script is attached to the player
	float jumpPower = 5.0f; //assign an integer for jump power
	
	bool crouching;

	Vector2 jumpVector;
	Vector2 leftVector;
	Vector2 rightVector;
	KeyCode jumpKey; 
	KeyCode downKey;
	KeyCode leftKey;
	KeyCode rightKey;	

	GameObject player;

	//BoxCollider2D box = player.GetComponent(BoxCollider2D) as BoxCollider2D; //assign the BoxCollider2D of your player and set it to is trigger

	void Start()
	{
		jumpKey = KeyCode.UpArrow; //assign jump button here
		downKey = KeyCode.DownArrow; //assign down button here
		leftKey = KeyCode.LeftArrow;
		rightKey = KeyCode.RightArrow;

		player = GameObject.FindWithTag("Player");

		crouching = false;
	}	

	void Update () 
	{
		crouching = Input.GetKey(downKey);		
		isCrouching();		

		//Jump
		if(Input.GetKeyDown(jumpKey))
		{	
			jumpVector = rigidbody2D.velocity;
			jumpVector.y = jumpPower;
			rigidbody2D.velocity = jumpVector;
		}

		if(Input.GetKey(leftKey))
		{
			player.transform.Translate(Vector3.left * Time.deltaTime * 5);
		}  

		if(Input.GetKey(rightKey))
		{
			player.transform.Translate(Vector3.right * Time.deltaTime * 5);
		}

		// If you want your object to go down on your platform
		// Similar to the Contra game platform feature.
		//if(Input.GetKeyDown(downKey))
		//{
		//	box.isTrigger = true;
		//}
	}

	void isCrouching(){
		BoxCollider2D boxCollider = GetComponent("BoxCollider2D") as BoxCollider2D;
		CircleCollider2D circleCollider = GetComponent("CircleCollider2D") as CircleCollider2D;
		if(crouching){
			boxCollider.center = circleCollider.center;
		}
		else{
			boxCollider.center = circleCollider.center + new Vector2(0,0.4f);
		}
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
