using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] AnimationCurve rotationCurve;
    Joycon joycon;
    Quaternion targetRot;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        joycon = JoyconManager.Instance.j[0];
    }

    private void Update()
    {
        if (joycon.GetButtonDown(Joycon.Button.SHOULDER_2))
        {
            joycon.Recenter();
        }
    }

    private void FixedUpdate()
    { 
        Quaternion joyconRot = joycon.GetVector();
        targetRot = Quaternion.Euler(-joyconRot.eulerAngles.y, joyconRot.eulerAngles.z, joyconRot.eulerAngles.x + 180f);
        float angle = Quaternion.Angle(Quaternion.LookRotation(Quaternion.Euler(0, targetRot.eulerAngles.y, 0) * Vector3.forward, Vector3.up), targetRot);
        Quaternion lerpRot = Quaternion.Lerp(rb.rotation, targetRot, rotationCurve.Evaluate(angle / 90f) * Time.timeScale);
        rb.MoveRotation(lerpRot);
    }
}
