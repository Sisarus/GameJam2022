using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCreature : MonoBehaviour
{
    [SerializeField]
    public string nameObject;

    public bool isCreature;

    [SerializeField]
    public string data;

    public float energy;

    [SerializeField]
    public float maxEnergy;

    [SerializeField]
    public LayerMask canSelectToShowLayer;

    public int playerLevel;
}
