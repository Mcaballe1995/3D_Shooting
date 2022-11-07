using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    private GameObject zonaDisparo;
    public GameObject bala;
    
    public int numBalas;
    public float cadencia;
    private float cadenciaInicial;

    // Start is called before the first frame update
    void Start()
    {
        cadenciaInicial = cadencia;
    }

    // Update is called once per frame
    void Update()
    {
        zonaDisparo = GameObject.FindGameObjectWithTag("ZonaDisparo");
       
        if (cadencia < 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                
                Instantiate(bala, zonaDisparo.transform.position, transform.rotation);
                cadencia = cadenciaInicial;
            }
        }
        cadencia -= Time.deltaTime;
    }


}
