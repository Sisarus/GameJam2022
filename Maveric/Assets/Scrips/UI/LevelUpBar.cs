using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpBar : MonoBehaviour {

    [Header ("Level Up - slider")]
    public Slider levelSlider;

    int energyLevel;

    int maxLevelToLevelUp;

    [SerializeField]
    TextMeshProUGUI levelUpText;

    [Header ("Timer - slider")]
    public Slider timeSlider;
    [SerializeField]
    TextMeshProUGUI timerText;

    LevelUpSystem levelUpSystem;

    PlayerData playerData;

    public GameObject endGame;

    // Start is called before the first frame update
    void Start () {
        levelUpSystem = FindObjectOfType<LevelUpSystem> ();

        playerData = FindObjectOfType<PlayerData> ();

        maxLevelToLevelUp = levelUpSystem.GetNextLevelEnergyLevel (playerData.playerLevel);

        levelSlider.maxValue = maxLevelToLevelUp;
        levelSlider.value = playerData.energyPoints;

        timeSlider.maxValue = playerData.timeHowLongCanBeCreature;
        timeSlider.value = playerData.timePassedAsCreature;
        timerText.text = "time " + playerData.timeHowLongCanBeCreature;

        endGame.SetActive (false);
    }

    // Update is called once per frame
    void Update () {
        if (playerData.energyPoints >= maxLevelToLevelUp) {
            endGame.SetActive (true);
            //end.isEndgame = true;
        }

        levelSlider.value = playerData.energyPoints;

        levelUpText.text = "Level " + playerData.playerLevel + " [ " + playerData.energyPoints + " / " + maxLevelToLevelUp + " ]";

        timeSlider.value = playerData.timePassedAsCreature;
        timerText.text = "time " + Mathf.Round (playerData.timePassedAsCreature);
    }

}