using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstactCamera
{
    public abstract void OnStateEnter(CameraController camera);

    public abstract void OnStateUpdate(CameraController camera);

    public abstract void OnStateExit(CameraController camera);

    public static implicit operator AbstactCamera(Camera v)
    {
        throw new NotImplementedException();
    }
}
