using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] AnimationCurve rotationCurve;
    [SerializeField, Range(0, 1f)] float lerpSpeed;
    Quaternion targetRot;

    private void Start()
    {
        
    }

    private void Update()
    {
        Joycon joycon = JoyconManager.Instance.j[0];
        if (joycon.GetButtonDown(Joycon.Button.SHOULDER_2))
        {
            joycon.Recenter();
        }
        Quaternion joyconRot = joycon.GetVector();
        targetRot = Quaternion.Euler(-joyconRot.eulerAngles.y, joyconRot.eulerAngles.z, joyconRot.eulerAngles.x);

        float lerp = rotationCurve.Evaluate(Mathf.Abs(transform.eulerAngles.x) / 90f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, lerpSpeed);
    }
}
