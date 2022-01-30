using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersClass
{

    public float velocidadMov;
    public Vector2 direccion;
    public bool esCazador;

    public SpriteRenderer visualOno;
    public Animator animator;

    public float contadorRegresivo;

    public PlayersClass(){
        velocidadMov = 10.0f;
        direccion = Vector2.zero;
        contadorRegresivo = 10.0f;
       }
    public PlayersClass(float vel, Vector2 v, bool tjug)
    {
        velocidadMov = vel;
        direccion = v;
        esCazador = tjug;
    }
}
