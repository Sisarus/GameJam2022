using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGiver : MonoBehaviour
{
    [SerializeField] float energy;


    private void Update() {
        if(energy <= 0){
            NoEnergy();
        }
    }


    public float GetEnergy(){
        return energy;
    }

    void NoEnergy(){
        Destroy(gameObject);
    }
}
