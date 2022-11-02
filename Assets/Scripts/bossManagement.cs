using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossManagement : MonoBehaviour
{
    public GameObject door1;
    public GameObject canvasBoss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player"))
        {
            door1.GetComponent<BoxCollider>().enabled = true;
            door1.GetComponent<Renderer>().enabled = true;
            canvasBoss.SetActive(true);
        }
    }
    
}
