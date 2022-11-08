using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CockroachPanic.UI
{
    public class UI_LogoMotion : MonoBehaviour
    {
        [SerializeField] float motionSpeed = 1;
        [SerializeField] float motionScale = 5; 
        // Update is called once per frame
        void Update()
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                Mathf.PingPong(Time.time * motionSpeed, motionScale) - motionScale / 2
                );
        }
    }
}
