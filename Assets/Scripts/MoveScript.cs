using UnityEngine;

public class MoveScript : MonoBehaviour
{
	// Object Speed
	public Vector2 speed = new Vector2(10, 10);
	
	// Moving Direction
	public Vector2 direction = new Vector2(1, 0);
	
	private Vector2 movement;
	
	void Update()
	{
		// Movement
		movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
	}

	// Update Movement with RigidBody
	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}
}