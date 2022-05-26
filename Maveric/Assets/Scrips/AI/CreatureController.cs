using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour {

    public bool isControlledByPlayer;

    public bool isPlayer;

    public string creatureName;

    Animator animator;

    [HideInInspector]
    PathFinder pathFinder;

    // Start is called before the first frame update
    void Awake () {
        animator = GetComponent<Animator> ();
        animator.SetBool ("isMoving", true);
        pathFinder = GetComponent<PathFinder> ();
        if (isControlledByPlayer && pathFinder != null) {
            pathFinder.SetActive (false);
        }
    }

    // Update is called once per frame
    void Update () {
        int creatureNumber = FindObjectOfType<PlayerIsNow>().GetComponent<PlayerIsNow>().creatureNumber;
        if (!pathFinder && !isPlayer && creatureNumber == 0 || !isControlledByPlayer && !isPlayer && creatureNumber == 0) {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero, 20f);
            if (hit.collider == gameObject.GetComponent<Collider2D>()) {
                pathFinder.SetActive (false);
                if(Input.GetMouseButtonDown(0)) {
                    isControlledByPlayer = true;
                    animator.SetBool ("isMoving", false);
                }
            } else {
                pathFinder.SetActive (true);
            }
        }

    }

}