using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private PlayerController _playerControllerScript;

    private Vector3 _offset;
    private bool _isDefaultCamera = true;

    //add to rotation to rotate camera
    private Quaternion _initialRotation;
    private bool _isRotated = false;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - player.transform.position;
        _initialRotation = transform.rotation;
        _playerControllerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_isDefaultCamera)
        {
          transform.position = player.transform.position + _offset;
        }
        if (_playerControllerScript._hitCameraObstacleBackwards)
        {
            backwardsCamera();
        }
        if (_playerControllerScript._hitCameraObstacleLeft)
        {
            leftwardsCamera();
        }
        if (_playerControllerScript._hitCameraObstacleRight)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
               player.transform.position.z + 25) + _offset;

            if (_isRotated)
            {
                transform.Rotate(60, 180, 0);
                _isRotated = true;
            }
            _isDefaultCamera = false;
        }
    }
    private void backwardsCamera()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
                player.transform.position.z + 25) + _offset;

        if (_isRotated == false)
        {
            transform.Rotate(60, 180, 0);
            _isRotated = true;
        }
        _isDefaultCamera = false;
    }
    private void rightwardsCamera()
    {

    }
    private void leftwardsCamera()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
              player.transform.position.z) + _offset;

        if (_isRotated == false)
        {
          //  transform.Rotate(0, 0, 0);
            _isRotated = true;
        }
        _isDefaultCamera = false;
    }
}