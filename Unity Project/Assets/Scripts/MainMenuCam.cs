using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainMenuCam : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float orbitSpeed;
    CinemachineTrackedDolly trackedDolly;

    private void Awake()
    {
        trackedDolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    void Update()
    {
        trackedDolly.m_PathPosition += orbitSpeed * Time.deltaTime;
    }
}
