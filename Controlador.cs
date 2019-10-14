using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(CharacterController))]
public class Controlador : MonoBehaviour {

    public float rotationSpeed = 500;
    public float walkSpeed;
    public float runSpeed;

    private Quaternion targetRotation;

    private CharacterController controller;
    
    
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();

        rotationSpeed = 500;
        walkSpeed = 10;
        runSpeed = 20;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (input != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y,
                targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);

        }

        Vector3 motion = input;

        /*input *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) * 0.7f: 1;*/
        if (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1){
            motion *= 0.7f;
        }
        else{
            motion *= 1;
        }

        if (Input.GetButton("Run")){
            motion *= runSpeed;
        }
        else{
            motion *= walkSpeed;
        }


        motion += Vector3.up * -8;

        controller.Move(motion * Time.deltaTime );
		
	}
}
