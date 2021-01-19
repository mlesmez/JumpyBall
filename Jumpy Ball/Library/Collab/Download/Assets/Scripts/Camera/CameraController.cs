using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public PlayerController _playerControllerScript;
    public AbstactCamera currentState;
    public Quaternion initialRotation;

    //how far camera will be from player
    public Vector3 _offset;

    //keep track if camera is initial camera view
    public bool _isDefaultCamera = true;

    // states
    public AbstactCamera cameraBaseState;
    public DefaultCameraState defaultCamera = new DefaultCameraState();
    public BackwardsCameraState backwardsCamera = new BackwardsCameraState();
    public RightwardsCameraState rightwardsCamera = new RightwardsCameraState();
    public LeftwardsCameraState leftwardsCamera = new LeftwardsCameraState();

    void Start()
    {
        initialRotation = transform.rotation;
        //access player controller script
        _playerControllerScript = player.GetComponent<PlayerController>();

        MakeTransitionToNextState(defaultCamera);
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null) {
            currentState.OnStateUpdate(this);
        }
    }
    public void MakeTransitionToNextState(AbstactCamera stateToMove)
    {
        // store the current state
        currentState = stateToMove;
        // move to next state
        currentState.OnStateEnter(this);
    }
}