using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsManger : MonoBehaviour
{
   public Transform[] positions;
   GameManger gameManger;
   Player player;
   GunData[] allGuns;
   GameObject[] gunsInScene;
   float firedguns = 0;
   public float fireDelayBetweenGuns;

   void Start(){
      
      player = GameManger.Instance.player;
      allGuns = GameManger.Instance.allGuns;

      for(int i = 0; i < player.slots; i++){
         Instantiate(allGuns[player.selectedGun].prefeb, positions[i].position, positions[i].rotation);
      }
      gunsInScene = GameObject.FindGameObjectsWithTag("Player");
   }

   public void Fire(){
      foreach(GameObject gun in gunsInScene){
         gun.GetComponent<Gun>().Fire(firedguns);
         firedguns += fireDelayBetweenGuns;
      }
      firedguns = 0;
   }

   public void OnOffGun(int num){
      if(gunsInScene[num].GetComponent<Gun>().enabled){
         gunsInScene[num].GetComponent<Gun>().enabled = false;
         gunsInScene[num].transform.Find("Canvas").gameObject.SetActive(false);
      }else{
         gunsInScene[num].GetComponent<Gun>().enabled = true;
         gunsInScene[num].transform.Find("Canvas").gameObject.SetActive(true);
      }
   }
}
