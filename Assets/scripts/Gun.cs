using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    JoyStick joystick;
    float inputX;
    float inputY;
    public float defSpeed;
    public float eleSpeed;

    public float minDef;
    public float maxDef;
    public float minEle;
    public float maxEle;


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
        joystick = GameObject.Find("joystick").GetComponent<JoyStick>();

        breechDefaultPosition = breech.localPosition;

        gameManger = GameObject.Find("GameManger").GetComponent<GameManger>();

    }

    void Update(){
        Movement();
    }

    void Movement(){
        inputX += joystick.inputVector.x * Time.deltaTime * defSpeed;
        inputY += joystick.inputVector.y * Time.deltaTime * eleSpeed;
        inputX = Mathf.Clamp(inputX, minDef, maxDef);
        inputY = Mathf.Clamp(inputY, minEle, maxEle);
        transform.rotation = Quaternion.Euler(0, -inputX, 0);
        deflectionWheel.localRotation = Quaternion.Euler(0, 0, inputX * 35);
        elevationControler.localRotation = Quaternion.Euler(inputY, 0, 0);
        elevationWheel.localRotation = Quaternion.Euler(0, 90, inputY * 50);
        tyreLeft.localRotation = Quaternion.Euler(0, 90, -inputX * tyreSpeed);
        tyreRight.localRotation = Quaternion.Euler(0, 90, inputX * tyreSpeed);

        breech.localPosition = Vector3.MoveTowards(breech.localPosition, breechDefaultPosition, recoileSpeed * Time.deltaTime);
    }
    public void Fire(float delay){
        // if(!gameManger.playerTurn) return;
        if(!this.enabled)return;
        StartCoroutine(FireDelay(delay));

        gameManger.playerTurn = false;
    }

    IEnumerator FireDelay(float delay){
        yield return new WaitForSeconds(delay);
        flash.Play();
        breech.localPosition += new Vector3(0, 0, -0.7f);
        GameObject projectile = Instantiate(shell, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * launchForce;
        shot.Play();
    }
    
}
