using UnityEngine;
using System.Collections;

public class PlayerCrouch : MonoBehaviour { 

	KeyCode downKey;
	
	// Use this for initialization
	void Start () {
		
		downKey = KeyCode.DownArrow; //assign down button here
	}
	
	// Update is called once per frame
	void Update () {
		//crouch 
		bool crouch = Input.GetKey(downKey);
		Crouch(crouch);
		
	}
	void Crouch(bool crouching){
		BoxCollider2D boxCollider = GetComponent("BoxCollider2D") as BoxCollider2D;
		CircleCollider2D circleCollider = GetComponent("CircleCollider2D") as CircleCollider2D;
		if(crouching){
			boxCollider.center=circleCollider.center;
		}
		else{
			boxCollider.center = circleCollider.center + new Vector2(0,0.4f);
		}
	}
}
