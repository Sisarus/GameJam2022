using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpBar : MonoBehaviour {
    public Slider slider;

    float energyLevel;

    int maxLevelToLevelUp;

    LevelUpSystem levelUpSystem;

    PlayerData playerData;

    // Start is called before the first frame update
    void Start () {
        levelUpSystem = FindObjectOfType<LevelUpSystem> ();

        playerData = FindObjectOfType<PlayerData> ();

        maxLevelToLevelUp = levelUpSystem.GetNextLevelEnergyLevel (playerData.playerLevel);

        Debug.Log ("Need energy " + maxLevelToLevelUp + "  " + playerData.energyPoints);

        slider.maxValue = maxLevelToLevelUp;
        slider.value = playerData.energyPoints;
    }

    // Update is called once per frame
    void Update () {
        if (energyLevel == maxLevelToLevelUp) {
            Debug.Log ("Level up");
            Debug.Log ("but must done!");
        }

        slider.value = playerData.energyPoints;
    }
}