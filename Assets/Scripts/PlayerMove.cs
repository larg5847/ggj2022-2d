using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{

    PlayersClass p;

    float ultimoTap;
    float tiempoUltimoTap;
    const float DobleClick = 0.3f;
    public bool cazador;


    // Start is called befor the first frame update
    void Start()
    {
        p = new PlayersClass(5.0f, Vector2.zero, cazador);

        p.animator = GetComponent<Animator>();
        p.visualOno = GetComponent<SpriteRenderer>();
        if (p.esCazador)
        {
            gameObject.tag = "perseguidor";
        }
        else
        {
            gameObject.tag = "perseguido";
        }


    }

    // Update is called once per frame
    void Update()
    {
        movimientoJugador();
        revisionTag();
    }




    void movimientoJugador()
    {
        p.direccion = Vector2.zero;


        if (Input.GetKey(KeyCode.A))
        {
            p.direccion.x = -1;
            p.animator.SetInteger("Direction", 3);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            p.direccion.x = 1;
            p.animator.SetInteger("Direction", 2);
        }


        if (Input.GetKey(KeyCode.W))
        {
            p.direccion.y = 1;
            p.animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            p.direccion.y = -1;
            p.animator.SetInteger("Direction", 0);
        }

        p.direccion.Normalize();
        p.animator.SetBool("IsMoving", p.direccion.magnitude > 0);
        GetComponent<Rigidbody2D>().velocity = p.velocidadMov * p.direccion;

        if (p.esCazador && (p.direccion.x != 0 || p.direccion.y != 0))
        {
            p.visualOno.enabled = false;
        }
        else
        {
            p.visualOno.enabled = true;
        }

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
                //p.visualOno.enabled = false;
                p.esCazador = true;
            }
            else
            {
                gameObject.tag = "perseguido";
                p.contadorRegresivo = 10.0f;
                //p.visualOno.enabled = true;
                p.esCazador = false;
            }
        }
    }


    //revisar
    bool ChecarDobleTap()
    {
        tiempoUltimoTap = Time.time - ultimoTap;

        if (tiempoUltimoTap <= DobleClick)
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
        if (colision.gameObject.tag == "haloDeLuz")
        {
            if (gameObject.tag == "perseguidor")
            {
                //p.visualOno.enabled = 
            }
        }

        if (colision.gameObject.tag == "perseguido" && p.esCazador == true)
        {
            Debug.Log("se atrapaste");
        }
    }
}

