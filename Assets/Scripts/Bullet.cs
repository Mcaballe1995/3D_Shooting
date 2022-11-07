using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.TryGetComponent<ZombieEnemy>(out ZombieEnemy zombieComponent))
		{
			zombieComponent.TakeDamage(1);
		}
		Destroy(gameObject);
	}
}
