using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureData : MonoBehaviour {
    public string creatureName;

    public Transform player;

    void Update () {
        transform.position = new Vector3 (0, 0, 0);
        transform.Rotate(0, 0, 0);
    }
}