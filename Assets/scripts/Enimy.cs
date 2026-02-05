using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enimy : MonoBehaviour
{
    
    GameObject[] playerTargets;
    GameObject selectedTarget;
    Quaternion targetDeflection;
    Quaternion targetElevation;
    public Transform deflection;
    public Transform elevation;
    public Transform firePoint;
    public GameObject shell;
    public AudioSource shot;
    public float speed;
    public float launchForce;
    GameManger gameManger;

    public float waitTime = 3f;
    private float currentWaitTime;

    public ParticleSystem flash;

    void Start(){
        gameManger = GameObject.Find("GameManger").GetComponent<GameManger>();
        SelectTarget();
        CalculateDeflection();
        CalculateElevation();
    }

    void Update(){
        RotateTowardsTarget();
    }
    void SelectTarget(){
        playerTargets = GameObject.FindGameObjectsWithTag("PlayerTarget");
        selectedTarget = playerTargets[(int)Random.Range(0, playerTargets.Length)];
    }

    void RotateTowardsTarget(){
        if(gameManger.playerTurn) return;
        currentWaitTime += Time.deltaTime;
        if(currentWaitTime < waitTime) return;
        float yRotation = Mathf.DeltaAngle(0, deflection.localEulerAngles.y);
        float eleAngle = Mathf.DeltaAngle(0, elevation.localEulerAngles.x);
        deflection.transform.localRotation = Quaternion.RotateTowards(
            deflection.transform.localRotation, 
            targetDeflection, 
            Time.deltaTime * speed
            );
        
        elevation.localRotation = Quaternion.RotateTowards(
            elevation.localRotation,
            targetElevation,
            Time.deltaTime * speed
        );
        
        if(targetDeflection == deflection.localRotation && targetElevation == elevation.localRotation){
            Fire();
            currentWaitTime = 0;
        }
    }
    void CalculateDeflection(){
        Vector3 directionToPlayer = selectedTarget.transform.position - deflection.position;
        Vector3 horizontalError = new Vector3(directionToPlayer.x, 0, directionToPlayer.z);
        float angle = Vector3.SignedAngle(deflection.forward, horizontalError, transform.up);
        targetDeflection = deflection.localRotation * Quaternion.Euler(0, angle, 0);
    }
    void CalculateElevation(){
        float distance = Vector3.Distance(elevation.position, selectedTarget.transform.position);
        float gravity = Mathf.Abs(Physics.gravity.y);
        float value = (gravity * distance) / (launchForce * launchForce);
        float angleOfEle = (0.5f * Mathf.Asin(value)) * Mathf.Rad2Deg;
        targetElevation = Quaternion.Euler(-angleOfEle, 0, 0);
    }
    void Fire(){
        GameObject projectile = Instantiate(shell, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody>().velocity = firePoint.transform.forward * launchForce;
        shot.Play();
        flash.Play();
        SelectTarget();
        CalculateDeflection();
        CalculateElevation();
        gameManger.playerTurn = true;
    }
}
