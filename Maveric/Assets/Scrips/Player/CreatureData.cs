using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureData : MonoBehaviour {
    public string creatureName;

    void Update () {
        transform.localPosition = new Vector3 (0, 0, 0);
        transform.localRotation = Quaternion.identity;
    }
}