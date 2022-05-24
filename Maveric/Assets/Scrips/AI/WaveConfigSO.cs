using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> antPrefabs;
    [SerializeField] Transform pathPrefabs;
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float mininumSpawnTime = 0.2f;

    public Transform GetStartingWaypoint(){
        return pathPrefabs.GetChild(0);
    }

    public List<Transform> GetWaypoints(){
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefabs){
            waypoints.Add(child);
        }

        return waypoints;
    }
    
    public float GetMoveSpeed(){
        return moveSpeed;
    }

    public int GetEnemyCount(){
        return antPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index){
        return antPrefabs[index];
    }

    public float GetRandomSpawnTime(){
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, mininumSpawnTime, float.MaxValue);    
    }

}
