using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{

    PlayersClass p;
    
    float ultimoTap;
    float tiempoUltimoTap;
    const float DobleClick = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        p = new PlayersClass();
        ultimoTap = Time.time;
        p.tipoJugador = 1;

        p.visualOno = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        p.direccion = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            p.direccion.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            p.direccion.x = 1;
        }


        if (Input.GetKey(KeyCode.W))
        {
            p.direccion.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            p.direccion.y = -1;
        }

        p.direccion.Normalize();
        GetComponent<Rigidbody2D>().velocity = p.velocidadMov * p.direccion;

        revisionTag();
    }

    


    void movimientoJugador()
    {
        p.direccion = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            p.direccion.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            p.direccion.x = 1;
        }


        if (Input.GetKey(KeyCode.W))
        {
            p.direccion.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            p.direccion.y = -1;
        }

        p.direccion.Normalize();
        GetComponent<Rigidbody2D>().velocity = p.velocidadMov * p.direccion;
    }


    void revisionTag()
    {
        if (p.contadorRegresivo > 0)
        {
            p.contadorRegresivo -= Time.deltaTime;

        }
        else
        {
            if (gameObject.tag == "perseguido")
            {
                gameObject.tag = "perseguidor";
                p.contadorRegresivo = 10.0f;
                p.visualOno.enabled = false;
                p.tipoJugador = 2;
                
            }
            else
            {
                gameObject.tag = "perseguido";
                p.contadorRegresivo = 10.0f;
                p.visualOno.enabled = true;
                p.tipoJugador = 1;
            }
        }
    }


    //revisar
    bool ChecarDobleTap()
    {
        tiempoUltimoTap = Time.time - ultimoTap;
        
        if(tiempoUltimoTap <= DobleClick)
        {
            ultimoTap = Time.time;
            return (true);
        }
        else
        {
            ultimoTap = Time.time;
            return (false);
        }
        
    }

    void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.gameObject.tag == "haloDeLuz")
        {
            if (gameObject.tag == "perseguidor")
            {
                //p.visualOno.enabled = 
            }
        }

        if(colision.gameObject.tag == "perseguido" && p.tipoJugador == 2)
        {
            Debug.Log("se atraparon");
        }
    }
}

