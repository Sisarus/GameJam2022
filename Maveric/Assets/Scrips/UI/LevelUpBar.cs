using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpBar : MonoBehaviour {

    [Header("Level Up - slider")]
    public Slider levelSlider;

    float energyLevel;

    int maxLevelToLevelUp;

    [SerializeField]
    TextMeshProUGUI levelUpText;

    [Header("Timer - slider")]
    public Slider timeSlider;
    [SerializeField]
    TextMeshProUGUI timerText;


    LevelUpSystem levelUpSystem;

    PlayerData playerData;

    // Start is called before the first frame update
    void Start () {
        levelUpSystem = FindObjectOfType<LevelUpSystem> ();

        playerData = FindObjectOfType<PlayerData> ();

        maxLevelToLevelUp = levelUpSystem.GetNextLevelEnergyLevel(playerData.playerLevel);

        levelSlider.maxValue = maxLevelToLevelUp;
        levelSlider.value = playerData.energyPoints;

    }

    // Update is called once per frame
    void Update () {
        if (energyLevel == maxLevelToLevelUp) {
            Debug.Log ("Level up");
            Debug.Log ("but must done!");
        }

        levelSlider.value = playerData.energyPoints;

        levelUpText.text = "Level " + playerData.playerLevel + " [ " + playerData.energyPoints + " / " + maxLevelToLevelUp + " ]"; 

        timerText.text = "time " + playerData.timeHowLongCanBeCreature;
    }

    
}