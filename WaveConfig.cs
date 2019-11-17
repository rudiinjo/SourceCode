using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;
    int number;
    public void GetPrefabNumber()
    {
        number = UnityEngine.Random.Range(0, enemyPrefabs.Count);
    }
    public GameObject GetEnemyPrefab()
    {
        GameObject enemyPrefab = enemyPrefabs[number];
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waveWayPoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return spawnRandomFactor; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }
    public float GetMoveSpeed() { return moveSpeed; }
}
