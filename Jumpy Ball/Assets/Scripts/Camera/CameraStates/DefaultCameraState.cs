using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCameraState : AbstactCamera
{
    public override void OnStateEnter(CameraController camera)
    {
        camera._playerControllerScript._hitCameraObstacleBackwards = false;
        camera._playerControllerScript._hitCameraObstacleRight = false;
        camera._playerControllerScript._hitCameraObstacleLeft = false;
    }

    public override void OnStateExit(CameraController camera)
    {
        camera._isDefaultCamera = false;
    }

    public override void OnStateUpdate(CameraController camera)
    {
        if (camera._playerControllerScript._hitCameraObstacleLeft)
        {
            camera._playerControllerScript._hitCameraObstacleLeft = false;
            OnStateExit(camera);
            camera.MakeTransitionToNextState(camera.leftwardsCamera);
        }
        if (camera._playerControllerScript._hitCameraObstacleRight)
        {
            camera._playerControllerScript._hitCameraObstacleRight = false;
            OnStateExit(camera);
            camera.MakeTransitionToNextState(camera.rightwardsCamera);
        }
        if (camera._playerControllerScript._hitCameraObstacleBackwards)
        {
            camera._playerControllerScript._hitCameraObstacleBackwards = false;
            OnStateExit(camera);
            camera.MakeTransitionToNextState(camera.backwardsCamera);
        }
        camera.transform.position = new Vector3(camera.player.transform.position.x, camera.player.transform.position.y + 8,
               camera.player.transform.position.z - 10);
        camera.transform.rotation = camera.initialRotation;
    }
}
