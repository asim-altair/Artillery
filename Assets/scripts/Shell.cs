using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public AudioSource explosion;
    public float damage;
    Rigidbody rb;
    private GameObject playerGun;
    public GameObject blast;

    void Start(){
        rb = GetComponent<Rigidbody>();
        playerGun = GameObject.Find("105mm");
    }

    void FixedUpdate(){
        if(rb != null){
            Quaternion desiredRotation = Quaternion.LookRotation(rb.velocity, transform.up);
            rb.MoveRotation(desiredRotation);
        }
    }

    void OnCollisionEnter(Collision col){
        Debug.Log(col.gameObject.name);
        explosion.Play();
        Life life = col.gameObject.GetComponent<Life>();
        if(life != null){
            life.TakeDamage(damage);
        }
        Instantiate(blast, transform.position, transform.rotation);
        Destroy(gameObject.GetComponent<Rigidbody>());
        Destroy(gameObject.GetComponent<MeshRenderer>());
        Destroy(gameObject.GetComponent<CapsuleCollider>());
        Destroy(gameObject, 5f);
    }
}
