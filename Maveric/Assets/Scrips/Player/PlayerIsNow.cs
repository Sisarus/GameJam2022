using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsNow : MonoBehaviour {

    public LayerMask layerMask;
    [HideInInspector]
    public float timeForCreature;

    [HideInInspector]
    public float timer;

    [HideInInspector]
    public int creatureNumber = 0;

    [HideInInspector]
    public string creaName = "ghost";

    [HideInInspector]
    PlayerController playerController;

    [HideInInspector]
    public List<GameObject> creaturePrefabs = new List<GameObject> ();
    [HideInInspector]
    public bool backToStartPoint = false;

    Transform creature = null;

    bool timerOn = false;

    void Awake () {
        playerController = transform.GetComponent<PlayerController> ();
        foreach (Transform child in transform) creaturePrefabs.Add (child.gameObject);
        HideOtherCreatures ();
    }

    void Update () {

        if (Input.GetMouseButtonDown (0) && creatureNumber == 0) {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero, 20f, layerMask);
            if (hit.collider) {
                creature = hit.transform;
                if (creature.GetComponent<CreatureController> ().isHome) {
                    playerController.newPos = hit.transform.position;
                    playerController.takingOver = true;
                    creaName = creature.GetComponent<CreatureController> ().creatureName;
                    creature.GetComponent<CreatureController> ().goHome = false;
                    creature.GetComponent<CreatureController> ().targetPlayer = transform;
                    LookForCreature (creaName);
                }
            }
        }

        if (timerOn) {
            timer -= Time.deltaTime;
            if (timer <= 0.0f) {
                backToStartPoint = true;
                creatureNumber = 0;
                creaName = "ghost";
                creature.GetComponent<CreatureController> ().goHome = true;
                creature.GetComponent<CreatureController> ().isControlledByPlayer = false;
                creature = null;
                HideOtherCreatures ();
                timerOn = false;
            }
        }

        if (playerController.changeToCreature) {
            HideOtherCreatures ();
            playerController.changeToCreature = false;
            Debug.Log (creature);
            creature.GetComponent<CreatureController> ().isControlledByPlayer = true;
            timerOn = true;
        }
    }

    public void LookForCreature (string comName) {
        int creatureIndex = 0;
        foreach (GameObject creature in creaturePrefabs) {
            string checkName = creature.transform.GetComponent<CreatureData> ().creatureName;
            Debug.Log (checkName + "  " + comName);
            if (checkName == null) {
                break;
            } else if (checkName == comName) {
                break;
            }
            creatureIndex++;
        }
        creatureNumber = creatureIndex;
    }

    public void HideOtherCreatures () {
        int creatureIndex = 0;
        foreach (GameObject creature in creaturePrefabs) {
            if (creatureNumber == creatureIndex) {
                creature.SetActive (true);
            } else {
                creature.SetActive (false);
            }
            creatureIndex++;
        }
        timer = timeForCreature;
    }

}