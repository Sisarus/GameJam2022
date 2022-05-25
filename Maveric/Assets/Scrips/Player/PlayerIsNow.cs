using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsNow : MonoBehaviour {

    public List<GameObject> creaturePrefabs;

    public LayerMask layerMask;

    public float timeForCreature;
    float timer;

    PlayerController playerController;

    [HideInInspector]
    public int creatureNumber;

    // Start is called before the first frame update
    void Start () {
        playerController = GetComponent<PlayerController> ();
        HideOtherCreatures(0);
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown (0) && creatureNumber == 0) {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero, 20f, layerMask);
            if (hit.collider) {
                playerController.newPos = hit.transform.position;
                playerController.takingOver = true;
                string creaName = hit.transform.GetComponent<CreatureController>().creatureName;
                LookForCreature(creaName);
            }
        }


        if(creatureNumber != 0){
            timer -= Time.deltaTime;
            if (timer <= 0.0f){
                creatureNumber = 0;
                HideOtherCreatures(0);
            }
            Debug.Log("ajastin käyy " +  timer);
        }
    }

    void LookForCreature(string compareName){
        int check = 0;
        foreach(GameObject creature in creaturePrefabs){
            string checkName = creature.transform.GetComponent<CreatureController>().creatureName;
            if(checkName == null){
                break;               
            } else if(checkName == compareName){
                break;
            }
            check++;
        }
        creatureNumber = check;
        HideOtherCreatures(check);
    }

    void HideOtherCreatures(int noHide){
        int hided = 0;
        foreach(GameObject creature in creaturePrefabs){
            if(noHide == hided){
                creature.SetActive(true);
            } else{
                creature.SetActive(false);
            }
            hided++;
        }
        timer = timeForCreature;
    }

}