using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElevationInput : MonoBehaviour, IDragHandler
{
    public float rotationSpeed;
    public float currRotation;
    public float minDef;
    public float maxDef;

    
    public void OnDrag(PointerEventData data){
        float rotationAmount = data.delta.y * rotationSpeed;

        transform.Rotate(0f, 0f, rotationAmount);
        currRotation += data.delta.y / 50;
        currRotation = Mathf.Clamp(currRotation, minDef, maxDef);
    }
}
