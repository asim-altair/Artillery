using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    //Data
    Player player;
    GunData[] allGuns;
    private int currentGun;
    public float sliderSpeed;

    //UI Refrences
    public TextMeshProUGUI moneyField;
    public TextMeshProUGUI gunNameField;
    //health
    [Header("Health fields...................................")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI healthIncreament;
    public TextMeshProUGUI healthPrice;
    public Slider healthSlider;
    public GameObject healthMoneyIcon;
    public GameObject healthUpgradeBtn;
    //range
    [Header("Range fields...................................")]
    public TextMeshProUGUI rangeText;
    public TextMeshProUGUI rangeIncreament;
    public TextMeshProUGUI rangePrice;
    public Slider rangeSlider;
    public GameObject rangeMoneyIcon;
    public GameObject rangeUpgradeBtn;
    //damage
    [Header("Damage fields...................................")]
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI damageIncreament;
    public TextMeshProUGUI damagePrice;
    public Slider damageSlider;
    public GameObject damageMoneyIcon;
    public GameObject damageUpgradeBtn;
    //areaDamage
    [Header("AreaDamage fields...................................")]
    public TextMeshProUGUI areaDamageText;
    public TextMeshProUGUI areaDamageIncreament;
    public TextMeshProUGUI areaDamagePrice;
    public Slider areaSlider;
    public GameObject areaDamageMoneyIcon;
    public GameObject areaDamageUpgradeBtn;

    public Transform instancePosition;

    void Start(){
        player = GameManger.Instance.player;
        allGuns = GameManger.Instance.allGuns;
        InstantiateGun(player.selectedGun);
    }

    void Update(){
        UIUpdater();
    }

    public void InstantiateGun(int id){
        currentGun = id;
        Destroy(GameObject.FindGameObjectWithTag("Gun"));
        GameObject gunInScene = Instantiate(allGuns[id].prefeb, instancePosition.position, instancePosition.rotation);
        Destroy(gunInScene.GetComponent<Gun>());
    }

    public void UpgradeHealth(){
        player.guns[currentGun].health += allGuns[currentGun].healthIncreament;
        player.guns[currentGun].healthLevel++;
    }
    public void UpgradeRange(){
        player.guns[currentGun].range += allGuns[currentGun].rangeIncreament;
        player.guns[currentGun].rangeLevel++;
    }
    public void UpgradeDamage(){
        player.guns[currentGun].damage += allGuns[currentGun].damageIncreament;
        player.guns[currentGun].damageLevel++;
    }
    public void UpgradeAreaDamage(){
        player.guns[currentGun].areaDamage += allGuns[currentGun].areaDamageIncreament;
        player.guns[currentGun].areaDamageLevel++;
    }

    public void UIUpdater(){
        moneyField.text = player.money.ToString();
        gunNameField.text = player.guns[currentGun].gunName;
        //health
        healthText.text = "Health: " + player.guns[currentGun].health;
        if(player.guns[currentGun].healthLevel >= 4){
            healthMoneyIcon.SetActive(false);
            healthUpgradeBtn.SetActive(false);
            healthIncreament.text = "Max";
        }else{
            healthIncreament.text = "+" + allGuns[currentGun].healthIncreament;
            healthPrice.text = allGuns[currentGun].prices[player.guns[currentGun].healthLevel - 1].ToString();
            healthMoneyIcon.SetActive(true);
            healthUpgradeBtn.SetActive(true);
        }
        healthSlider.maxValue = allGuns[currentGun].maxHealth;
        healthSlider.value = Mathf.MoveTowards(healthSlider.value, player.guns[currentGun].health, Time.deltaTime * sliderSpeed);
        //range
        rangeText.text = "Range: " + player.guns[currentGun].range;
        if(player.guns[currentGun].rangeLevel >= 4){
            rangeMoneyIcon.SetActive(false);
            rangeUpgradeBtn.SetActive(false);
            rangeIncreament.text = "Max";
        }else{
            rangeIncreament.text = "+" + allGuns[currentGun].rangeIncreament;
            rangePrice.text = allGuns[currentGun].prices[player.guns[currentGun].rangeLevel - 1].ToString();
            rangeMoneyIcon.SetActive(true);
            rangeUpgradeBtn.SetActive(true);
        }
        rangeSlider.maxValue = allGuns[currentGun].maxRange;
        rangeSlider.value = Mathf.MoveTowards(rangeSlider.value, player.guns[currentGun].range, Time.deltaTime * sliderSpeed);
        //damage
        damageText.text = "Damage: " + player.guns[currentGun].damage;
        if(player.guns[currentGun].damageLevel >= 4){
            damageMoneyIcon.SetActive(false);
            damageUpgradeBtn.SetActive(false);
            damageIncreament.text = "Max";
        }else{
            damageIncreament.text = "+" + allGuns[currentGun].damageIncreament;
            damagePrice.text = allGuns[currentGun].prices[player.guns[currentGun].damageLevel - 1].ToString();
            damageMoneyIcon.SetActive(true);
            damageUpgradeBtn.SetActive(true);
        }
        damageSlider.maxValue = allGuns[currentGun].maxDamage;
        damageSlider.value = Mathf.MoveTowards(damageSlider.value, player.guns[currentGun].damage, Time.deltaTime * sliderSpeed);
        //areaDamage
        areaDamageText.text = "Area: " + player.guns[currentGun].areaDamage;
        if(player.guns[currentGun].areaDamageLevel >= 4){
            areaDamageMoneyIcon.SetActive(false);
            areaDamageUpgradeBtn.SetActive(false);
            areaDamageIncreament.text = "Max";
        }else{
            areaDamageIncreament.text = "+" + allGuns[currentGun].areaDamageIncreament;
            areaDamagePrice.text = allGuns[currentGun].prices[player.guns[currentGun].areaDamageLevel - 1].ToString();
            areaDamageMoneyIcon.SetActive(true);
            areaDamageUpgradeBtn.SetActive(true);
        }
        areaSlider.maxValue = allGuns[currentGun].maxAreaDamage;
        areaSlider.value = Mathf.MoveTowards(areaSlider.value, player.guns[currentGun].areaDamage, Time.deltaTime * sliderSpeed);
    }
}
