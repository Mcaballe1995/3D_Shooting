using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SVS
{
    public class RankBoss : MonoBehaviour
    {
        public Animator ani;
        public Boss boss;
        public int melee;

        void OnTriggerEnter(Collider col)
        {
            if(col.CompareTag("Player"))
            {
                melee = Random.Range(0, 4);
                switch(melee)
                {
                    case 0:
                        //hit1
                        ani.SetFloat("skills", 0);
                        boss.hit_select = 0;
                        break;
                    
                    case 1:
                        //hit2
                        ani.SetFloat("skills", 0.3333333f);
                        boss.hit_select = 1;
                        break;

                    case 2:
                        //jump hit
                        ani.SetFloat("skills", 0.6666667f);
                        boss.hit_select = 2;
                        break;
                }
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
                ani.SetBool("attack", true);
                boss.isAttacking = true;
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}