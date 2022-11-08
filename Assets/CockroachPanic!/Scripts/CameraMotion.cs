using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    Vector3 cameraLocalEuler;
    [SerializeField] float cameraMotionSpeed = 0.3f;
    [SerializeField] float cameraMotionScale = 0.5f;
    private void OnEnable()
    {
        cameraLocalEuler = transform.localEulerAngles;
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(
            cameraLocalEuler.x + Mathf.PingPong(Time.time * cameraMotionSpeed, cameraMotionScale),
            cameraLocalEuler.y,
            cameraLocalEuler.z);
    }
}
