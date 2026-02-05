using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeflectionInput : MonoBehaviour, IDragHandler
{
    public float rotationSpeed;
    public float currRotation;
    public float minDef;
    public float maxDef;

    
    public void OnDrag(PointerEventData data){
        float rotationAmount = data.delta.x * rotationSpeed;

        transform.Rotate(0f, 0f, rotationAmount);
        currRotation += data.delta.x / 50;
        currRotation = Mathf.Clamp(currRotation, minDef, maxDef);
    }
}
