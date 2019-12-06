using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {
    
    public enum TipoArma{Corta, Larga, Melee}/*pa la forma de agarralo*/
    public enum TipoDisparo { Semi, Auto, Escopeta}


    /*public Transform spawn;*/
    public TipoArma tipoArma;
    public TipoDisparo tipoDisparo;


    public Transform salidaBala;

    /*void Start()
    {
        salidaBala = GameObject.Find("salidaBala");
        Debug.Log(salidaBala);
    }*/

    public void disparar()
    {
        
        Ray ray = new Ray(salidaBala.position, salidaBala.forward);
        RaycastHit hit;

        float distancia = 30;

      
        if (Physics.Raycast(ray, out hit, distancia))
        {
            distancia = hit.distance;
        }

        Debug.DrawRay(ray.origin, ray.direction * distancia, Color.red, 1);
    }

    public void DispararContinuo()
    {
        if(tipoDisparo == TipoDisparo.Auto)
        {
            disparar();
        }
    }

}
