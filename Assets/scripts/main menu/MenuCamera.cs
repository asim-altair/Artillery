using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public float speed;
    public float camSpeed;
    public float currentXRot;
    public float currentYRot;

    void LateUpdate(){
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            currentXRot += touch.deltaPosition.x;
            currentYRot += touch.deltaPosition.y;
        }
        currentYRot = Mathf.Clamp(currentYRot, -200, 350);
        Quaternion desiredRotation = Quaternion.Euler(-currentYRot / speed, currentXRot / speed, 0);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            desiredRotation, 
            Time.deltaTime * camSpeed
        );
    }
}
