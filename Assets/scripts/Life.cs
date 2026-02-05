using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Slider healthBar;
    private bool dead = false;
    public bool breakable = false;
    public GameObject destroyed;
    public GameObject smoke;
    Rigidbody[] rbs;

    void Start(){
        if(healthBar != null){
            healthBar.maxValue = maxHealth;
        }
        health = maxHealth;
        if(!breakable)return;
        rbs = GetComponentsInChildren<Rigidbody>();
    }

    void Update(){
        if(health <= 0){
            if(!dead){
                if(!breakable){
                    Destroy(gameObject);
                    GameObject destroyedObj = Instantiate(destroyed, transform.position, transform.rotation);
                    GameObject smokeInstance = Instantiate(smoke, transform.position, transform.rotation);
                    Destroy(destroyedObj, 10f);
                    Destroy(smokeInstance, 10f);
                }else{
                    foreach(Rigidbody rb in rbs){
                        rb.isKinematic = false;
                        rb.AddExplosionForce(30, transform.position, 10, 30);
                    }
                }
                dead = true;
            }
        }
        if(healthBar != null){
            healthBar.value = health;
        }


    }

    public void TakeDamage(float value){
        health -= value;
    }
}
