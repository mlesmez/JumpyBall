﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoverRight : MonoBehaviour
{

    private Vector3 _leftPosition;
    private Vector3 _rightPosition;
    private float _Speed = 2;
    private bool _IsMax;
    // Start is called before the first frame update

    private void Awake()
    {
        // left and right max positions
        _leftPosition = new Vector3(transform.position.x -2.5f, transform.position.y, transform.position.z);
        _rightPosition = new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (_IsMax == false)
        {
            transform.Translate(_Speed * Time.deltaTime, 0, 0);
            if (transform.position.x >= _rightPosition.x)
            {
                _IsMax = true;
            }
        }
        if (_IsMax == true)
        {
            transform.Translate(-_Speed * Time.deltaTime, 0, 0);
            if (transform.position.x <= _leftPosition.x)
            {
                _IsMax = false;
            }
        }
    }
}