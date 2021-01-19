using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlatformForwardSpawner : MonoBehaviour
{
    public GameObject jumpCube;
    public GameObject spawner;
    public GameObject[] platforms;

    //names of platforms
    private GameObject defaultPlatform;
    private GameObject navMeshPlatform;

    // keep track of forward platforms stuff
    private float forwardDistance = 80;
    private float platformOffsetCounter = 100;
    private GameObject currentPlatform;

    // keep track of above platforms stuff
    private PlatformCounter _platformCounterScript;
    private int platformCount;
    private GameObject nextPlatform;

    // used for spawning jumps
    private int jumpsToBeSpawn = 4;
    private float jumpsSpawned = 0;
    private const float DistanceBetweenJumps = 20;
    private const float JumpHeight = 1;

    // Start is called before the first frame update
    void Start()
    {
        defaultPlatform = platforms[0];
        navMeshPlatform = platforms[1];
        
        PlatformForwardTriggerEventSystem.OnPlatformEnd += SpawnNewPlatform;
        _platformCounterScript = spawner.GetComponent<PlatformCounter>();
    }

    /// <summary>
    /// This method is mapped the event triggered by PlatformTriggerEventSystem class
    /// and whenever that event is triggered a new platform will be created with proper offset
    /// </summary>
    public void SpawnNewPlatform()
    {
        // Each time the player goes up a level
        platformCount = _platformCounterScript.platformCount;
        setPlatforms();

        // Instaniate next platform forward
        Instantiate(currentPlatform, new Vector3(transform.position.x - 20 * platformCount, 
            transform.position.y + 20 * platformCount, platformOffsetCounter), Quaternion.identity);

        // Instantiate platform above 
        Instantiate(currentPlatform, new Vector3(transform.position.x - 20 * (platformCount + 1), 
            transform.position.y + 20 * (platformCount + 1), platformOffsetCounter)
            , Quaternion.identity); 
        
        // Instantiate jumps above
        while (jumpsSpawned < jumpsToBeSpawn) 
        {
            //above jumps
            Instantiate(jumpCube, new Vector3(transform.position.x - 20 * (platformCount + 1),
                transform.position.y + 20 * (platformCount + 1) + JumpHeight, 
                transform.position.z + platformOffsetCounter + jumpsSpawned * DistanceBetweenJumps)
            , Quaternion.identity);

            // forwards jumps
            Instantiate(jumpCube, new Vector3(transform.position.x - 20 * platformCount, 
                transform.position.y + 20 * platformCount + JumpHeight, transform.position.z +
                platformOffsetCounter + jumpsSpawned * DistanceBetweenJumps), Quaternion.identity);
            
            //keep track of jumps
            jumpsSpawned += 1;
        }
        
        jumpsSpawned = 0;
        platformOffsetCounter += forwardDistance;
    }

    private void setPlatforms()
    {
        currentPlatform = defaultPlatform;
        nextPlatform = defaultPlatform;

        /*
        if (platformCount % 2 == 0)
        {
            currentPlatform = platforms[0];
            nextPlatform = platforms[1];
        }
        else
        {
            currentPlatform = platforms[1];
            nextPlatform = platforms[0];
        }
        */
    }
}
