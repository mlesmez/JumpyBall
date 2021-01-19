using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [Range(5,100)]
    //I think 10 is a good speed we could also change it throughout the game
    public float horizontalSpeed;
    private int _jumps = 0;
    private float zVelocity = 10;
    

    //booleans for when you hit a game object
    public bool _hitCameraObstacleBackwards = false;
    public bool _hitCameraObstacleRight = false;
    public bool _hitCameraObstacleLeft = false;
    public bool _isRotated = false;

    public bool _hitPlatformObstacle = false;

    private bool _gameOver = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    void FixedUpdate()
    {
        //left and right movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, zVelocity);
        rb.AddForce(movement * horizontalSpeed);
        

        if (Input.GetKeyDown(KeyCode.Space) && _jumps !=0)
        {
            rb.AddForce(-Physics.gravity, ForceMode.VelocityChange - 1);
            _jumps -= 1;
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death Zone") && !_gameOver)
        {
            Destroy(gameObject);
            _gameOver = true;
        }
        if (!_gameOver)
        {
            if (other.gameObject.CompareTag("CameraBackwardsObstacle"))
            {

                Destroy(other.gameObject);
                _isRotated = true;
                _hitCameraObstacleBackwards = true;
            }
            if (other.gameObject.CompareTag("CameraRightObstacle"))
            {
                Destroy(other.gameObject);
                _hitCameraObstacleRight = true;
            }
            if (other.gameObject.CompareTag("CameraLeftObstacle"))
            {
                Destroy(other.gameObject);
                _hitCameraObstacleLeft = true;
            }
            if (other.gameObject.CompareTag("PlatformObstacle"))
            {
                Destroy(other.gameObject);
                _hitPlatformObstacle = true;
            }
            if (other.gameObject.CompareTag("JumpCube"))
            {
                Destroy(other.gameObject);
                _jumps += 1;
            }
        }
    }
}
