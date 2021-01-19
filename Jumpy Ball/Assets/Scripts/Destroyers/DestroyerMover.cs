using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class DestroyerMover : MonoBehaviour
{

    public GameObject player;
   
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 140);

        }
    }
}
