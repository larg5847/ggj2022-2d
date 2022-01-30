using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersClass
{

    public float velocidadMov;
    public Vector2 direccion;
    public int tipoJugador;

    public SpriteRenderer visualOno;

    public float contadorRegresivo;

    public PlayersClass(){
        velocidadMov = 10.0f;
        direccion = Vector2.zero;
        contadorRegresivo = 10.0f;
       }
}
