using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class comportamientoLampara : MonoBehaviour
{

    //bool activado;
    Light2D luz;
    // Start is called before the first frame update
    void Start()
    {
        //activado = false;
        luz = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D queColisionador)
    {
        if(queColisionador.gameObject.CompareTag("perseguido"))
        {
            //activado = true;
            luz.intensity = 1.0f;

        }
        if(queColisionador.gameObject.CompareTag("perseguidor"))
        {
            //activado = false;
            luz.intensity = 0.0f;
        }
    }
}
