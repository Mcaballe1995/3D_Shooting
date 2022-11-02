using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SVS{
    
    public class Boss : MonoBehaviour
    {
            public int rutine;
            public float crono;
            public float time_rutines;
            public Animator ani;
            public Quaternion angle;
            public float grade;
            public GameObject target;
            public bool isAttacking;
            public RankBoss rank;
            public float speed;
            public GameObject[] hit;
            public int hit_select;
            
            public GameObject teleport;
            
            //lanzallamas
            public bool lanzallamas;
            public List<GameObject> pool = new List<GameObject> ();
            public GameObject fire;
            public GameObject cabeza;
            public float cronometro2;

            //jump attack
             public float jump_distance;
            public bool direction_skill;

            // fire ball
            public GameObject fire_ball;
            public GameObject point;
            public List<GameObject> pool2 = new List<GameObject> ();

            //hp boss
            public int fase = 1;
            public float hpMin;
            public float hpMax;
            public Image hpBar;
            public bool death;
        // Start is called before the first frame update
        void Start()
        {
           ani = GetComponent<Animator>();
           target = GameObject.Find("Player");
        }

        public void boss_Behaviour()
        {
            //if the distance between boss and player is < 15 
            if(Vector3.Distance(transform.position, target.transform.position) < 25)
            {
                //boss will rotate to the player position
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                //point.transform.LookAt(target.transform.position);

                if(Vector3.Distance(transform.position, target.transform.position) > 1 && !isAttacking)
                {
                    switch (rutine)
                    {
                        case 0:
                            //walk
                            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                            ani.SetBool("walk", true);
                            ani.SetBool("run", false);

                            if(transform.rotation == rotation)
                            {
                                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                            }

                            ani.SetBool("attack", false);
                            crono += 1 * Time.deltaTime;
                            if(crono > time_rutines)
                            {
                                rutine = Random.Range(0, 4);
                                crono = 0;
                            }
                            break;

                        case 1:
                            //run
                            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                            ani.SetBool("walk", false);
                            ani.SetBool("run", true);

                            if(transform.rotation == rotation)
                            {
                                transform.Translate(Vector3.forward * speed*2 * Time.deltaTime);
                            }

                            ani.SetBool("attack", false);
                            
                            break;
                        
                        case 2:
                        //jump attack
                        if(fase == 2){
                            jump_distance += 1 * Time.deltaTime;
                            ani.SetBool("walk", false);
                            ani.SetBool("run", false);
                            ani.SetBool("attack", true);
                            ani.SetFloat("skills", 1);
                            hit_select = 3;
                            
                            rank.GetComponent<CapsuleCollider>().enabled = false;

                            if(direction_skill)
                            {
                                if(jump_distance < 1f)
                                {
                                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                                }
                                transform.Translate(Vector3.forward * 8 * Time.deltaTime);
                            }
                        }else{
                            rutine = 0;
                            crono = 0;
                        }

                            break;
                    }
                }
            }
        }

        public void Final_Ani()
        {
            rutine = 0;
            ani.SetBool("attack", false);
            isAttacking = false;
            rank.GetComponent<CapsuleCollider>().enabled = true;
            jump_distance = 0;
            direction_skill = false;
        }

        public void Direction_Attack_Start()
        {
            direction_skill = true;
        }

        public void Direction_Attack_Final()
        {
            direction_skill = false;
        }

        public void ColliderWeaponTrue()
        {
            hit[hit_select].GetComponent<SphereCollider>().enabled = true;
        }

        public void ColliderWeaponFalse()
        {
            hit[hit_select].GetComponent<SphereCollider>().enabled = false;
        }

        public void Alive()
        {
            if(hpMin < 500)
            {
                time_rutines = 1;
                fase = 2;
            }
            boss_Behaviour();
        }

        // Update is called once per frame
        void Update()
        {
            hpBar.fillAmount = hpMin / hpMax;

            if(hpMin > 0)
            {
                Alive();
            }else{
                if(!death)
                {
                    ani.SetTrigger("dead");
                    death = true;
                    
                    teleport.SetActive(true);
                }
            }
        }
    }

}
