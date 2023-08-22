
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

    //State fields
    private PlayerBaseState _currentState;
    //TODO: have these as properties?
    public PlayerWalkingState walkState;
    public PlayerRunningState runState;

    //Player stats properties
    public float walkSpeed { get { return _walkSpeed; } set { _walkSpeed = value; } }
    public float runSpeed { get { return _runSpeed; } set { _runSpeed = value; } }
    public float rotationSpeed { get { return _rotationSpeed; } set { _rotationSpeed = value; } }


    //Player input values properties
    //Maybe need to rename this if in menu? Or should that be an entire diffrent entity?
    public float driveInput { get; private set; }
    public float rotationInput { get; private set; }
    public bool isRunning { get; private set; }


    //MonoBehaviour functions
    private void Awake()
    {
        InitializeInputs();
        InitializeStates();
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
    }

    private void InitializeInputs()
    {
        _playerInput = GetComponent<PlayerInput>();
        _movementInput = _playerInput.actions["Movement"];
        _runButton = _playerInput.actions["Run"];

        _runButton.started += _ => { isRunning = true; };
        _runButton.canceled += _ => { isRunning = false; };
    }


    private void ReadMovementInputs()
    {
        Vector2 movementValues = _movementInput.ReadValue<Vector2>();
        driveInput = movementValues.y;
        rotationInput = movementValues.x;
    }

    public void UpdateState(PlayerBaseState state)
    {
        _currentState = state;
        _currentState.EnterState();
    }





}