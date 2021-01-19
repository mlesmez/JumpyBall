using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatFormController : MonoBehaviour
{  
    private PlayerController _playerControllerScript;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       
        _playerControllerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerControllerScript._hitPlatformObstacle)
        {
            transform.Rotate(0, 0, 1 *Time.deltaTime);
        }
    }
}
