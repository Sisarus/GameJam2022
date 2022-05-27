using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public int playerLevel = 1;

    public float energyPoints = 0;

    float timeHowLongCanBeCrature = 5;

    LevelUpSystem levelUpSystem;

    void Awake () {
        levelUpSystem = FindObjectOfType<LevelUpSystem> ();
    }

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void MofifyEnergyPoints (float value) {
        energyPoints += value;
    }

    public float GetTimeHowLongCanBeCrature () {
        return timeHowLongCanBeCrature;
    }

    public void ModifyTimeHowLongCanBeCrature (float value) {
        timeHowLongCanBeCrature += value;
    }
}