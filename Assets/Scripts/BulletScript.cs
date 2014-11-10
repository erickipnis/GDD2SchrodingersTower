using UnityEngine;

public class BulletScript : MonoBehaviour
{
	public int damage = 1;
	
	public bool isPlayerShot = false;
	
	void Start()
	{
		Destroy(gameObject, 20);
	}
}