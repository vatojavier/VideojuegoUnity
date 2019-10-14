using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {
    public Transform spawn;

    public void disparar()
    {
        Ray ray = new Ray(spawn.position, spawn.forward);
        RaycastHit hit;

        float distancia = 30;

        if (Physics.Raycast(ray, out hit, distancia))
        {
            distancia = hit.distance;
        }

        Debug.DrawRay(ray.origin, ray.direction * distancia, Color.red,1);
    }
}
