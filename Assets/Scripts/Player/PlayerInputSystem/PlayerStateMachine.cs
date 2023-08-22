
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
{

    //Player stats fields
    [SerializeField]
    private float _walkSpeed, _backwardsWalkSpeed, _runSpeed, _rotationSpeed;

    //Input fields
    [SerializeField]
    private PlayerInput _playerInput;
    private InputAction _movementInput;
    private InputAction _runButton;
    private InputAction _aimButton;
    private InputAction _actionButton;
    private InputAction _shootButton;

    //State fields
    private PlayerBaseState _currentState;
    //TODO: have these as properties?
    public PlayerWalkingState walkState;
    public PlayerRunningState runState;
    public PlayerIdleState idleState;
    public PlayerBackingState backingState;
    public PlayerAimingState aimState;

    //Player stats properties
    public float walkSpeed { get { return _walkSpeed; } set { _walkSpeed = value; } }
    public float runSpeed { get { return _runSpeed; } set { _runSpeed = value; } }
    public float backwardsWalkSpeed { get { return _backwardsWalkSpeed; } set { _backwardsWalkSpeed = value; } }
    public float rotationSpeed { get { return _rotationSpeed; } set { _rotationSpeed = value; } }


    //Player input values properties
    //Maybe need to rename this if in menu? Or should that be an entire diffrent entity?
    public float driveInput { get; private set; }
    public float rotationInput { get; private set; }
    public bool isRunning { get; private set; } //TODO: Check if this can be change to an event forwarder and that the states listens to those events?
    public bool isAiming { get; private set; } //TODO: Check if this can be change to an event forwarder and that the states listens to those events?
    public bool isShooting { get; private set; }
    public bool actionPerformed { get; private set; }
    public bool canPickupItem { get; private set; }


    public IPlayerGun equipedGun;

    //MonoBehaviour functions
    private void Awake()
    {
        InitializeInputs();
        InitializeStates();
        SetUpInputCallbacks();
    }

    private void Start()
    {
        UpdateState(walkState);
    }

    private void Update()
    {
        ReadMovementInputs();
        _currentState.UpdateState();
    }

    //Methods
    private void InitializeStates()
    {
        walkState = new PlayerWalkingState(this);
        runState = new PlayerRunningState(this);
        idleState = new PlayerIdleState(this);
        backingState = new PlayerBackingState(this);
        aimState = new PlayerAimingState(this);
    }

    private void InitializeInputs()
    {
        _playerInput = GetComponent<PlayerInput>();
        _movementInput = _playerInput.actions["Movement"];
        _runButton = _playerInput.actions["Run"];
        _aimButton = _playerInput.actions["Aim"];
        _aimButton = _playerInput.actions["Action"];
        _aimButton = _playerInput.actions["Shoot"];
    }

    private void SetUpInputCallbacks()
    {
        _runButton.started += _ => { isRunning = true; };
        _runButton.canceled += _ => { isRunning = false; };

        _aimButton.started += _ => { isAiming = true; };
        _aimButton.canceled += _ => { isAiming = false; };

        _actionButton.performed += _ => { actionPerformed = true; };

        _shootButton.performed += _ => { actionPerformed = true; };
    }


    private void ReadMovementInputs()
    {
        //BUG: Because of the current implementation, walking while turning is slower than previous input system.
        // This is beacuse before the input values where seperated (if you turned right, rotation would be 1 and if you walked, the movement would be 1)
        // but now they corelante with eachother since they are compined into a vector (turning both right and walking forward results in (0.71, 0.71).
        //TODO: Should I keep this or should I seperate the inputs of each button? Can I get axis between two button instead? Test RE1 and 2 to see how they did it.
        Vector2 movementValues = _movementInput.ReadValue<Vector2>();
        driveInput = movementValues.y; 
        rotationInput = movementValues.x;    }

    public void UpdateState(PlayerBaseState state)
    {
        _currentState = state;
        _currentState.EnterState();
    }





}