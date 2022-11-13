using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainMenuCam : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] Transform levelPos;

    private void Update()
    {
        levelPos.rotation = Quaternion.Euler(0, levelPos.rotation.eulerAngles.y + rotateSpeed * Time.deltaTime, 0);
    }
}
