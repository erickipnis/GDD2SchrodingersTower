using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {

	//This script is attached to the player
	float jumpPower = 5.0f; //assign an integer for jump power
	
	bool crouching=false;

	Vector2 jumpVector;
	Vector2 leftVector;
	Vector2 rightVector;
	KeyCode jumpKey; 
	KeyCode downKey;
	KeyCode leftKey;
	KeyCode rightKey;	
	bool isJumping;
	int jumpCount;
	GameObject player;
	bool facingRight = true;
	float speed = 0;
	Animator anim;


	//BoxCollider2D box = player.GetComponent(BoxCollider2D) as BoxCollider2D; //assign the BoxCollider2D of your player and set it to is trigger

	void Start()
	{
		jumpKey = KeyCode.W; //assign jump button here
		downKey = KeyCode.S; //assign down button here
		leftKey = KeyCode.A;
		rightKey = KeyCode.D;
		isJumping = false;
		jumpCount = 0;
		player = GameObject.FindWithTag("Player");

		anim=GetComponent<Animator>();
	}	

	void Update () 
	{
		crouching = Input.GetKey(downKey);	
		anim.SetBool("Crouching",crouching);	
		isCrouching();		

		//Jump
		if(Input.GetKeyDown(jumpKey) && jumpCount <= 1)
		{	
			jumpVector = rigidbody2D.velocity;
			jumpVector.y = jumpPower;
			rigidbody2D.velocity = jumpVector;
			jumpCount++;
			isJumping = true;
			anim.SetTrigger("Jump");
			anim.SetBool("Fall",true);
		}
		if(Input.GetKey(leftKey))
		{
			if(facingRight)
			{
				Flip();
			}
			player.transform.Translate(Vector3.left * Time.deltaTime * 5);
			facingRight=false;
			speed=1;
		}  

		else if(Input.GetKey(rightKey))
		{
			if(!facingRight)
			{
				Flip();
			}
			player.transform.Translate(Vector3.right * Time.deltaTime * 5);
			facingRight=true;
			speed=1;
		}
		else
		{
			speed=0;
		}
		if(isJumping && Input.GetKey(downKey))
		{
			player.transform.Translate(Vector3.down * Time.deltaTime * 4);
		}
		anim.SetFloat("Speed",Mathf.Abs(speed));
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
			boxCollider.center = circleCollider.center + new Vector2(0,0.5f);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		/*if (coll.gameObject.tag == "Bullet")
		{
			Destroy(gameObject);
			Destroy(coll.gameObject);
		}*/

		if(coll.gameObject.tag == "Floor" || coll.gameObject.tag == "Block")
		{
			isJumping = false;
			jumpCount = 0;
			anim.SetBool("Fall",false);
		}
		else
		{
			anim.SetBool("Jump",false);
		}

	}
	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x*=-1;
		transform.localScale=theScale;
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
