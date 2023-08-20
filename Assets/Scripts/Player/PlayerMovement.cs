using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  
    //TODOS:
    //1. Fix state machine and how the controls works in that
    //2. Put gun functions in a seperate class and make it a property of this one.
    //3. Put linerender code elsewhere.
    [SerializeField]
    private float _walkSpeed, _reverseWalkSpeed, _runSpeed, _rotationSpeed, _gunDamage;

    private LineRenderer gunAimLine;


    // Start is called before the first frame update
    void Start()
    {
        //gunAimLine = GetComponent<LineRenderer>();
        //gunAimLine.enabled = false;
        //gunAimLine.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Learn about CharacterController instead and use it here
        //Also, find out why collider triggers need to interact with rigidbody or character controller.

        //Player rotation
        float rotation = Input.GetAxisRaw("Horizontal") * _rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);



        
        //TODO: Use state machine instead to determine speed and if the player can move.
        //Player walk speed
        float movementSpeed;
        float walkDirection = Input.GetAxisRaw("Vertical");
        
        //Aiming
        if (Input.GetKey(KeyCode.Space))
        {
            movementSpeed = 0;
            
            //renderAimLine();
            if(Input.GetKey(KeyCode.Return))
            {
                //shoot();
            }
        }
        //Walking
        else
        {
            //gunAimLine.enabled = false; // Temporary, yes I know this is horrible.
            if (walkDirection < 0) //Walking Backwards
            {
                movementSpeed = _reverseWalkSpeed;
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftControl)) //Running
                {
                    movementSpeed = _runSpeed;
                }
                else
                {
                    movementSpeed = _walkSpeed;
                }

            }
        }

        float translation = Input.GetAxisRaw("Vertical") * movementSpeed;
        translation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
 

    }

    //TODO: This is temp, have on gun object instead probably.
    // Change it so that 
 
    private void renderAimLine()
    {
        gunAimLine.enabled = true;
        gunAimLine.SetPosition(0, transform.position);
        gunAimLine.SetPosition(1, transform.position + transform.forward * 100);

    }
}
