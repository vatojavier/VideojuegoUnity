using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(CharacterController))]
public class Controlador : MonoBehaviour {

    public float rotationSpeed = 500;
    public float walkSpeed;
    public float runSpeed;
    public Arma arma;


    private Camera cam;
    private Quaternion targetRotation;


    private CharacterController controller;

    
    
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();

        rotationSpeed = 500;
        walkSpeed = 5;
        cam = Camera.main;

    }
	
	// Update is called once per frame
	void Update () {

        apuntado();
        movimiento();

        if (Input.GetButtonDown("Shoot"))
        {
            arma.disparar();
        }
		
	}

    void apuntado()
    {
        /*Sale un rayo de la camara hasta el suelo, el personaje apunta hasta ese pto: */
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(Vector3.up, Vector3.zero);

        float distance;
        if (plane.Raycast(camRay, out distance))
        {
            Vector3 target = camRay.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }

    }
    void movimiento()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 motion = input;

        /*input *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) * 0.7f: 1;*/
        if (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1)
        {
            motion *= 0.7f;
        }
        else
        {
            motion *= 1;
        }
        motion *= walkSpeed;
        /*if (Input.GetButton("Run"))
        {
            motion *= runSpeed;
        }
        else
        {
            motion *= walkSpeed;
        }*/
        motion += Vector3.up * -8;
        controller.Move(motion * Time.deltaTime);
    }
}
