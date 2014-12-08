using UnityEngine;

public class GunScript : MonoBehaviour
{
	// Movement Variables
	public string type = "side";
	public Vector2 speed = new Vector2(3, 3);
	public Vector2 direction = new Vector2(1, 0);
	private Vector2 movement;

	// Bullet Prefab
	public Transform bulletPrefab;
	
	// Cooldown Variables
	public float shootingRate = 0.25f;
	private float shootCooldown;

	// Random Frequency
	public float rFreq = 99;

	public static Vector2 gunPosition;
	
	void Start()
	{
		shootCooldown = 0f;

		gunPosition = new Vector2(0,0);
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
			if (transform.position.y > 2.9)
				direction.y = -1;
			else if (transform.position.y < -5.4)
				direction.y = 1;
		}
		else if (type == "top")
		{
			if (transform.position.x > 7.2)
				direction.x = -1;
			else if (transform.position.x < -7.2)
				direction.x = 1;
		}

		movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			GameObject[] guns = GameObject.FindGameObjectsWithTag("Gun");
			for(int i = 0; i < guns.Length; i++)
			{
				DestroyImmediate(guns[i]);
				StageScrolling.levelSurvived = 0;
			}
			
			Destroy(coll.gameObject);
			Application.LoadLevel("GameOver");
		}
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

			int r = (int)Random.Range(0, rFreq);
			//print (r);
			Debug.Log(r);


			if(r <= 75 )
			{
				var shotTransform = Instantiate(bulletPrefab) as Transform;
			
				shotTransform.position = this.transform.position;
			
				BulletScript shot = shotTransform.gameObject.GetComponent<BulletScript>();
				if (shot != null)
				shot.isPlayerShot = isPlayer;
			
				MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
				if (move != null && type == "side")
				move.direction = this.transform.right;
			}
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