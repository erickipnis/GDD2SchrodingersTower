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
			GameObject[] guns = GameObject.FindGameObjectsWithTag("Gun");
			for(int i = 0; i < guns.Length; i++)
			{
				DestroyImmediate(guns[i]);
				StageScrolling.levelSurvived = 0;
			}

			Destroy(coll.gameObject);
			//Application.LoadLevel("GameOver");
		}
		
		if (coll.gameObject.tag == "Elevator" || coll.gameObject.tag == "Floor")
		{
			Destroy(gameObject);
		}
		if (coll.gameObject.tag == "Block")
		{
			Physics2D.IgnoreCollision(this.collider2D, coll.collider);

		}
		if (coll.gameObject.tag == "Bullet")
		{
			Physics2D.IgnoreCollision(this.collider2D, coll.collider);
			
			//Destroy(gameObject);
		}
	}
}