using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tairify.Camera
{
    public class Follow : MonoBehaviour
    {
        public float speed;
        public float camSpeed;
        public float currentXRot;
        public float currentYRot;

        void LateUpdate()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                currentXRot += touch.deltaPosition.x;
                currentYRot += touch.deltaPosition.y;
            }

            currentYRot = Mathf.Clamp(currentYRot, -200f, 350f);

            Quaternion desiredRotation = Quaternion.Euler(
                -currentYRot / speed,
                currentXRot / speed,
                0f
            );

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                desiredRotation,
                Time.deltaTime * camSpeed
            );
        }
    }
}
