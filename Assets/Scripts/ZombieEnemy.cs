using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{
    [SerializeField] float health, maxhealth = 3f;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}
