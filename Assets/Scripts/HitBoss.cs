using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SVS{
public class HitBoss : MonoBehaviour
    {
        public int damage;

        void OnTriggerEnter(Collider col)
        {
            if(col.CompareTag("Player"))
            {
                col.GetComponent<PlayerMovementScript>().hp_min -= damage;
            }
        }
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
