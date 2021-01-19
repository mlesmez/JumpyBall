using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAboveTriggerEventSystem : MonoBehaviour
{
    /// <summary>
    /// Event system to trigger if the player had entered the trigger - if so this class will publish and event
    /// The Spawner class will receive this event and spawn a new platform
    /// </summary>
    public delegate void TriggerAbove();
    public static event TriggerAbove GenerateNewPlatformAbove;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject.GetComponent<BoxCollider>());
            if (GenerateNewPlatformAbove != null)
            {
                GenerateNewPlatformAbove();
            }
        }
    }
}
