using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour {

    public bool isControlledByPlayer = false;

    public string creatureName;

    Animator animator;

    [HideInInspector]
    PathFinder pathFinder;
    [HideInInspector]
    List<Vector3> backPath = new List<Vector3> ();

    [HideInInspector]
    private const float TimeStep = 0.5f;
    [HideInInspector]
    private float timer = 0;

    [HideInInspector]
    public bool goHome = true;
    [HideInInspector]
    public bool isHome = true;
    [HideInInspector]
    public Transform targetPlayer;

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
        int creatureNumber = FindObjectOfType<PlayerIsNow> ().GetComponent<PlayerIsNow> ().creatureNumber;
        if (!pathFinder && creatureNumber == 0 && isHome || !isControlledByPlayer && creatureNumber == 0 && isHome) {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero, 20f);
            if (hit.collider == gameObject.GetComponent<Collider2D> ()) {
                pathFinder.SetActive (false);
            } else {
                pathFinder.SetActive (true);
            }
        }

        if (isControlledByPlayer) {
            animator.SetBool ("isVisible", false);
            transform.position = Vector3.MoveTowards (transform.position, targetPlayer.transform.position, Time.deltaTime * 10);
            timer += Time.deltaTime;
            if (timer >= TimeStep) {
                timer = 0;
                if (backPath.Count > 0) {
                    Vector3 last = backPath[backPath.Count - 1];
                    if (Vector3.Distance (last, transform.position) > 0.02f) {
                        backPath.Add (transform.position);
                    }
                } else {
                    backPath.Add (transform.position);
                }
            }
            animator.SetBool ("isMoving", false);
        }

        if (goHome) {
            animator.SetBool ("isVisible", true);
            animator.SetBool ("isMoving", true);
            targetPlayer = null;
        }

        if (backPath.Count > 0 && !isControlledByPlayer && !isHome) {
            Vector3 goHome = backPath[backPath.Count - 1];
            transform.position = Vector3.MoveTowards (transform.position, goHome, Time.deltaTime * 0.5f);
            if (Vector3.Distance (goHome, transform.position) < 0.02f) {
                backPath.RemoveAt (backPath.Count - 1);
            }
        }

        if (backPath.Count == 0) {
            isHome = true;
        } else {
            isHome = false;
        }

    }

}