using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatFormController : MonoBehaviour
{
    private Quaternion _platformRotation;
    private PlayerController _playerControllerScript;
    private float _rotateSpeed =100;
    // Start is called before the first frame update
    void Start()
    {
        _platformRotation = transform.rotation;
        _playerControllerScript = gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (_playerControllerScript._hitPlatformObstacle)
       // {
        //    transform.Rotate(_rotateSpeed*Time.deltaTime, 0, 0);
       // }
    }
}
