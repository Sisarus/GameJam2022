using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
    AntSpawner antSpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
    bool active = true;

    void Awake () {
        antSpawner = FindObjectOfType<AntSpawner> ();
    }

    void Start () {
        waveConfig = antSpawner.GetCurrentWave ();
        waypoints = waveConfig.GetWaypoints ();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update () {
        if(active) FollowPath ();
    }

    void FollowPath () {
        if (waypointIndex < waypoints.Count) {

            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed () * Time.deltaTime;
            transform.position = Vector2.MoveTowards (transform.position, targetPosition, delta);

            CalculateAngle ();
            if (transform.position == targetPosition) {
                waypointIndex++;
            }
        } else {
            Destroy (gameObject);
        }
    }

    void CalculateAngle () {
        Vector3 targetPosition = waypoints[waypointIndex].position;
        Vector3 tF = transform.up;
        Vector3 fD = targetPosition - transform.position;

        float dot = tF.x * fD.x + tF.y * fD.y;

        float angle = Mathf.Acos (dot / (tF.magnitude * fD.magnitude));

        float unityAngle = Vector3.SignedAngle (tF, fD, transform.forward);

        transform.Rotate (0, 0, unityAngle * Time.deltaTime * 3f);
    }

    Vector3 Cross (Vector3 v, Vector3 w) {

        float xMult = v.y * w.z - v.z * w.y;
        float yMult = v.z * w.x - v.x * w.z;
        float zMult = v.x * w.y - v.y * w.x;

        Vector3 crossProd = new Vector3 (xMult, yMult, zMult);
        return crossProd;
    }

    float CalculateDistance () {
        Vector3 antPosition = transform.position;
        Vector3 targetPosition = waypoints[waypointIndex].position;
        return Vector3.Distance (antPosition, targetPosition);
    }

    public void SetActive(bool value){
        active = value;
    }
}