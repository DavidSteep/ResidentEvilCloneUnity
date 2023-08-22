using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControls : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed, backwardsWalkSpeed, rotationSpeed;

    //the speed that will be applied on movement, will change depending on state
    private float currentSpeed;

    [SerializeField]
    private PlayerInput playerInput;
    private InputAction movement;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        movement = playerInput.actions["Movement"];
    }
    // Start is called before the first frame update
    void Start()
    {
        //movement.performed += context => moveCharacter(context.ReadValue<Vector2>());
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveCharacter(movement.ReadValue<Vector2>());
    }

    //BUG: Because of the current implementation, walking while turning is slower than previous input system.
    // This is beacuse before the input values where seperated (if you turned right, rotation would be 1 and if you walked, the movement would be 1)
    // but now they corelante with eachother since they are compined into a vector (turning both right and walking forward results in (0.71, 0.71).
    //TODO: Should I keep this or should I seperate the inputs of each button? Can I get axis between two button instead? Test RE1 and 2 to see how they did it.
    private void moveCharacter(Vector2 directions)
    {
        Debug.Log("I'm walkin' here! (" + directions + ")");
        //Handle rotation of character
        var rotationDir = directions.x;
        var rotation = rotationDir * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        //Handle forward/backward movement of character
        var moveDir = directions.y;
        float movementSpeed;
        if(directions.y < 0) { movementSpeed = backwardsWalkSpeed; }
        else { movementSpeed = walkSpeed; }
        var movement = directions.y * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, movement);
    }
}
