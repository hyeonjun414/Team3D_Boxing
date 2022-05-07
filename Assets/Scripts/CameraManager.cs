using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public enum CamType
{
    Normal,
    P1Cam,
    P1ResultCam,
    P2Cam,
    P2ResultCam,
    DrawCam
}

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }

    public CinemachineVirtualCamera[] cams;

    public void ActiveCam(CamType cam)
    {
        int camNum = (int)cam;
        for (int i = 0; i < cams.Length; i++)
        {
            if (i == camNum)
                cams[i].Priority = 1;
            else
                cams[i].Priority = 0;
        }
    }

}
