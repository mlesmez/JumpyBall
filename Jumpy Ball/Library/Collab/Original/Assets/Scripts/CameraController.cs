using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private PlayerController _playerControllerScript;
    
    //angles for camera
    private Quaternion _leftTargetAngle = Quaternion.Euler(30, 90, 0);
    private Quaternion _rightTargetAngle = Quaternion.Euler(30, -90, 0);
    private Quaternion _backwardsTargetAngle = Quaternion.Euler(30, 180, 0);

    //how far camera will be from player
    private Vector3 _offset;

    //keep track if camera is initial camera view
    private bool _isDefaultCamera = true;
    // Start is called before the first frame update
    void Start()
    {
        //get distance between object and player
        _offset = transform.position - player.transform.position;
        //_initialRotation = transform.rotation; might need this in future
        //access player controller script
        _playerControllerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (_playerControllerScript._hitCameraObstacleBackwards && _playerControllerScript._isRotated)
        {
            backwardsCamera();
        }

        if (_playerControllerScript._hitCameraObstacleLeft )
        {
            leftwardsCamera();
        }
        if (_playerControllerScript._hitCameraObstacleRight)
        {
            rightwardsCamera();
        }
        if (_isDefaultCamera)
        {
            transform.position = player.transform.position + _offset;
        }
    }
    private void backwardsCamera()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
                player.transform.position.z + 25) + _offset;
        transform.rotation = Quaternion.Slerp(transform.rotation, _backwardsTargetAngle, .2f);
        _playerControllerScript._hitCameraObstacleRight = false;
        _playerControllerScript._hitCameraObstacleLeft = false;
        _isDefaultCamera = false;
        _playerControllerScript._isRotated = false;
        
    }
    private void rightwardsCamera()
    {
        transform.position = new Vector3(player.transform.position.x + 15, player.transform.position.y,
              player.transform.position.z + 13) + _offset;
        transform.rotation = Quaternion.Slerp(transform.rotation, _rightTargetAngle, .2f);
        _playerControllerScript._hitCameraObstacleBackwards = false;
        _playerControllerScript._hitCameraObstacleLeft = false;
        _isDefaultCamera = false;
    }
    private void leftwardsCamera()
    {
        transform.position = new Vector3(player.transform.position.x - 15, player.transform.position.y,
            player.transform.position.z + 13) + _offset;
        transform.rotation = Quaternion.Slerp(transform.rotation, _leftTargetAngle, .2f);

        _playerControllerScript._hitCameraObstacleBackwards = false;
        _playerControllerScript._hitCameraObstacleRight = false;
        _isDefaultCamera = false;
    }
}