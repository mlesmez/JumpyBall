using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformCounter : MonoBehaviour
{
    public int platformCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        PlatformAboveTriggerEventSystem.GenerateNewPlatformAbove += GenerateNewPlatform;
    }

    public void GenerateNewPlatform()
    {
        platformCount += 1;
    }
}
