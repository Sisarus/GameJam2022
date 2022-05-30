using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

    public Transform SpawnPoint;

    bool respawn = false;

    [HideInInspector]
    PlayerIsNow playerIsNow;

    public ParticleSystem possessionVFX;

    void Start () {
        playerIsNow = transform.GetComponent<PlayerIsNow> ();
    }

    void Update () {

        if (playerIsNow.backToStartPoint) {
            respawn = true;
        } else {
            respawn = false;
        }

        if (respawn) {
            transform.position = SpawnPoint.position;
            playerIsNow.backToStartPoint = false;
            ParticleSystem instance = Instantiate(possessionVFX, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}