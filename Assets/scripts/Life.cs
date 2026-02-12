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
    public GameObject destroyed;
    public GameObject smoke;

    void Start(){
        if(healthBar != null){
            healthBar.maxValue = maxHealth;
        }
        health = maxHealth;
    }

    void Update(){
        if(health <= 0){
            if(!dead){
                    Destroy(gameObject);
                    GameObject destroyedObj = Instantiate(destroyed, transform.position, transform.rotation);
                    GameObject smokeInstance = Instantiate(smoke, transform.position, transform.rotation);
                    Destroy(destroyedObj, 10f);
                    Destroy(smokeInstance, 10f);
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
