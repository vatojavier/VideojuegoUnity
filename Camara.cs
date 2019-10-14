using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

    private GameObject jugador;
    public float altura;
    public float alejado;
    public float angulo;

	// Use this for initialization
	void Start () {
        altura = 12;
        alejado = 7;
        angulo = 56;
        jugador = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 posicion = new Vector3(jugador.transform.position.x, altura, jugador.transform.position.z - alejado);
        Vector3 rotacion = new Vector3(angulo, 0, 0);
        transform.position = posicion;
        transform.eulerAngles = rotacion;
    }
}
