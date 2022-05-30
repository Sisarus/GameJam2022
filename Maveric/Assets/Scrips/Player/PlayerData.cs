using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public int playerLevel = 1;

    public float energyPoints = 0;


    public float timeHowLongCanBeCreature = 10;

    LevelUpSystem levelUpSystem;

    PlayerIsNow playerIsNow;

    void Awake () {
        levelUpSystem = FindObjectOfType<LevelUpSystem> ();
        playerIsNow = transform.GetComponent<PlayerIsNow>();
        timeHowLongCanBeCreature = playerIsNow.timeForCreature;
        playerIsNow.timeForCreature = timeHowLongCanBeCreature;
    }

    void Update(){
        timeHowLongCanBeCreature = playerIsNow.timeForCreature;
        
    }

    public void MofifyEnergyPoints (float value) {
        energyPoints += value;
    }

}