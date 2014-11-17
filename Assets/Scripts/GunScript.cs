using UnityEngine;

public class GunScript : MonoBehaviour
{
	// Movement Variables
	public string type = "side";
	public float speed = 3;
	public float direction = 1;
	
	private Vector2 movement;

	// Bullet Prefab
	public Transform bulletPrefab;
	
	// Cooldown Variables
	public float shootingRate = 0.25f;
	private float shootCooldown;
	
	void Start()
	{
		shootCooldown = 0f;
	}
	
	void Update()
	{
		// Cooldown
		if (shootCooldown > 0)
			shootCooldown -= Time.deltaTime;

		// Shooting
		GunScript weapon = GetComponent<GunScript>();
		if (weapon != null)
			weapon.Attack(false);

		// Movement
		if (type == "side")
		{
			if (transform.position.y > 2.5)
				direction = -1;
			else if (transform.position.y < -4.15)
				direction = 1;
		}
		else if (type == "top")
		{
			if (transform.position.x > 2.5)
				direction = -1;
			else if (transform.position.x < -4.15)
				direction = 1;
		}

		movement = new Vector2(0, speed * direction);
	}

	// Update Movement with RigidBody
	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}

	// Attack the Player
	public void Attack(bool isPlayer)
	{
		if (CanAttack)
		{
			shootCooldown = .5f;
			
			var shotTransform = Instantiate(bulletPrefab) as Transform;
			
			shotTransform.position = this.transform.position;
			
			BulletScript shot = shotTransform.gameObject.GetComponent<BulletScript>();
			if (shot != null)
				shot.isPlayerShot = isPlayer;
			
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null)
				move.direction = this.transform.right;
		}
	}
	
	// Is cooldown over?
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}