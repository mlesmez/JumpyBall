using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LavaMover : MonoBehaviour
{

    [Range(0.1f,1)]
    public float _speed;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y + _speed * Time.deltaTime, player.transform.position.z);

        }
    }
}
