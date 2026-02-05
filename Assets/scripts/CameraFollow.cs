using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed;

    void Start(){
        // target = GameObject.Find("105mm").transform;
    }

    void LateUpdate(){
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            target.rotation,
            Time.deltaTime * speed
        );
    }
}
