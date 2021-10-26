using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider;
    public Slider defenceSlider;
    public Slider energySlider;
    public Text healthText;
    public Text defenceText;
    public Text energyText;
    public int MaxHealth = 500;
    public int BaseDefence = 5;
    public int MaxEnergy = 360;

    public GameObject player;

    private void Awake()
    {
        
    }

    private void Update()
    {
        UpdatePlayerBarUI();
    }

    void UpdatePlayerBarUI()
    {
        healthSlider.value = (float)player.GetComponent<PlayerController>().CurrentHealth / MaxHealth;
        defenceSlider.value = (float)player.GetComponent<PlayerController>().CurrentDefence / BaseDefence;
        energySlider.value = (float)player.GetComponent<PlayerController>().CurrentEnergy / MaxEnergy;
        healthText.text = player.GetComponent<PlayerController>().CurrentHealth + "/" + MaxHealth;
        defenceText.text = player.GetComponent<PlayerController>().CurrentDefence + "/" + BaseDefence;
        energyText.text = player.GetComponent<PlayerController>().CurrentEnergy + "/" + MaxEnergy;
    }
}
