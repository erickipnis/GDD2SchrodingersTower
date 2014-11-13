using UnityEngine;

public class BulletScript : MonoBehaviour
{
	public int damage = 1;
	
	public bool isPlayerShot = false;
	
	void Start()
	{
		Destroy(gameObject, 20);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			Destroy(coll.gameObject);
			Application.LoadLevel("GameOver");
		}

		if (coll.gameObject.tag == "Elevator")
		{
			Destroy(gameObject);
		}
		if (coll.gameObject.tag == "Elevator")
		{
			Destroy(gameObject);
		}
		if (coll.gameObject.tag == "Block")
		{
			//Physics2D.IgnoreCollision(this.collider2D, coll.collider);

			Destroy(gameObject);
		}
	}
}