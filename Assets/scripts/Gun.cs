using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    DeflectionInput deflectionInput;
    ElevationInput elevationInput;

    public Transform elevationControler;
    public Transform deflectionWheel;
    public Transform elevationWheel;
    public Transform tyreLeft;
    public Transform tyreRight;
    public Transform firePoint;
    public Transform breech;

    public GameObject shell;

    public float tyreSpeed;
    public float launchForce;
    public float recoileSpeed;

    // Audio
    public AudioSource shot;

    private Vector3 breechDefaultPosition;

    GameManger gameManger;

    public ParticleSystem flash;
    void Start(){
        GameObject deflectionWheel = GameObject.Find("Deflection Wheel");
        GameObject elevationWheel = GameObject.Find("Elevation Wheel");
        deflectionInput = deflectionWheel.GetComponent<DeflectionInput>();
        elevationInput = elevationWheel.GetComponent<ElevationInput>();

        breechDefaultPosition = breech.localPosition;

        gameManger = GameObject.Find("GameManger").GetComponent<GameManger>();

    }

    void Update(){
        Movement();
    }

    void Movement(){
        if(deflectionInput == null && elevationInput == null) return;
        transform.rotation = Quaternion.Euler(0, -deflectionInput.currRotation, 0);
        deflectionWheel.localRotation = Quaternion.Euler(0, 0, deflectionInput.currRotation * 35);
        elevationControler.localRotation = Quaternion.Euler(elevationInput.currRotation, 0, 0);
        elevationWheel.localRotation = Quaternion.Euler(0, 90, elevationInput.currRotation * 50);
        tyreLeft.localRotation = Quaternion.Euler(0, 90, -deflectionInput.currRotation * tyreSpeed);
        tyreRight.localRotation = Quaternion.Euler(0, 90, deflectionInput.currRotation * tyreSpeed);

        breech.localPosition = Vector3.MoveTowards(breech.localPosition, breechDefaultPosition, recoileSpeed * Time.deltaTime);
    }
    public void Fire(){
        if(!gameManger.playerTurn) return;
        flash.Play();
        breech.localPosition += new Vector3(0, 0, -0.7f);
        GameObject projectile = Instantiate(shell, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * launchForce;

        shot.Play();
        gameManger.playerTurn = false;
    }
    
}
