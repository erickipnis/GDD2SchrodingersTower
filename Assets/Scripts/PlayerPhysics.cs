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
}
