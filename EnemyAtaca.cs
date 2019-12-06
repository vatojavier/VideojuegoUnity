using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyAtaca : MonoBehaviour {

    public AxisMouseTopDownPlayerMove jugador;
    public EnemyIA ia;

    private Transform posJugador;
    private float distancia;
    public Animator animacionZombie;
    private float progresoAtaque;

    // Use this for initialization
    void Start () {
        

        ia = GetComponent<EnemyIA>();
        animacionZombie = ia.animator;

        posJugador = ia.target;

	}
	
	// Update is called once per frame
	void Update () {
        distancia = Vector3.Distance(posJugador.position, transform.position);
        
        if (distancia < ia.attackingDistance)
        {
            progresoAtaque = animacionZombie.GetCurrentAnimatorStateInfo(0).normalizedTime;
            progresoAtaque = progresoAtaque - (float) Math.Truncate(progresoAtaque);

            Debug.Log(progresoAtaque);
            
            if (progresoAtaque > 0.45f && progresoAtaque < 0.58f)
            {
                jugador.salud -= 1;
            }
           
        }

	}
}
