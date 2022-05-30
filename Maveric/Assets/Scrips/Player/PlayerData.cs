using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public int playerLevel = 1;

    public float energyPoints = 0;


    public float timeHowLongCanBeCreature = 5;

    [HideInInspector]
    public float timePassedAsCreature;

    LevelUpSystem levelUpSystem;

    PlayerIsNow playerIsNow;

    void Awake () {
        levelUpSystem = FindObjectOfType<LevelUpSystem> ();
        playerIsNow = transform.GetComponent<PlayerIsNow>();
        playerIsNow.timeForCreature = timeHowLongCanBeCreature;
    }

    void Update(){
        timePassedAsCreature = playerIsNow.timer;
    }

    public void MofifyEnergyPoints (float value) {
        energyPoints += value;
    }

}