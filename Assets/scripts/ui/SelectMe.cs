using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectMe : MonoBehaviour
{
    public Player player;

    public int missionNum;
    public TextMeshProUGUI missionText;
    public bool selected;
    public Image img;
    public Sprite bgSelected;
    public Sprite bgUnSelected;
    private GameObject[] otherCards; 
    public GameObject lockIcon;
    public GameObject textNumber;

    void Start(){
        missionText.text = missionNum.ToString();
        otherCards = GameObject.FindGameObjectsWithTag("card");
    }

    void Update(){
        if(selected){
            img.sprite = bgSelected;
        }else{
            img.sprite = bgUnSelected; 
        }
        if(player.currentMission < missionNum){
            lockIcon.SetActive(true);
            textNumber.SetActive(false);
        }else{
            textNumber.SetActive(true);
            lockIcon.SetActive(false);
        }
    }

    public void Select(){
        if(player.currentMission < missionNum) return;
        selected = true;
        foreach(GameObject card in otherCards){
            SelectMe script = card.GetComponent<SelectMe>();
            if(card.gameObject != this.gameObject){
                script.selected = false;
            }
        }
    }
}
