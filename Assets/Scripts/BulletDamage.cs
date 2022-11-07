using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float vel;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = transform.forward * vel;
        time -= Time.deltaTime;
        if (time < 0)
        {
            //Destroy(this.gameObject);
        }
    }
}
