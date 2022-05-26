using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsNow : MonoBehaviour {

    public LayerMask layerMask;

    public float timeForCreature;

    [HideInInspector]
    float timer;
    
    [HideInInspector]
    public int creatureNumber = 0;

    [HideInInspector]
    public string creaName = "ghost";

    [HideInInspector]
    PlayerController playerController;

    [HideInInspector]
    public List<GameObject> creaturePrefabs = new List<GameObject> ();

    void Awake(){
        playerController = transform.GetComponent<PlayerController>();
        foreach (Transform child in transform) creaturePrefabs.Add (child.gameObject);
        HideOtherCreatures(creatureNumber);
    }
    
    void Update () {

        if (Input.GetMouseButtonDown (0) && creatureNumber == 0) {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero, 20f, layerMask);
            if (hit.collider) {
                playerController.newPos = hit.transform.position;
                playerController.takingOver = true;
                creaName = hit.transform.GetComponent<CreatureController>().creatureName;
                LookForCreature(creaName);
            }
        }

        if(creatureNumber != 0){
            timer -= Time.deltaTime;
            if (timer <= 0.0f){
                creatureNumber = 0;
                creaName = "ghost";
                HideOtherCreatures(creatureNumber);
            }
        } 
    }

    public void LookForCreature (string comName) {
        int creatureIndex = 0;
        foreach (GameObject creature in creaturePrefabs) {
            string checkName = creature.transform.GetComponent<CreatureController> ().creatureName;
            if (checkName == null) {
                break;
            } else if (checkName == comName) {
                break;
            }
            creatureIndex++;
        }
        creatureNumber = creatureIndex;
        HideOtherCreatures(creatureIndex);

    }

    public void HideOtherCreatures (int dontHide) {
        int creatureIndex = 0;
        foreach (GameObject creature in creaturePrefabs) {
            if (dontHide == creatureIndex) {
                creature.SetActive(true);
            } else {
                creature.SetActive(false);
            }
            creatureIndex++;
        }
        timer = timeForCreature;
    }

}