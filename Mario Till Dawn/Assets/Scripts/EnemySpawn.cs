using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject botPrefab;
    public float spawnRadius = 11f;
    public float spawnDelay = 1f;
    public int maxBots = 100;

    private List<GameObject> bots = new List<GameObject>();

    private float timeSinceLastSpawn;
    
    void Update()
    {
        if(bots.Count < maxBots){
            timeSinceLastSpawn += Time.deltaTime;
            if(timeSinceLastSpawn > spawnDelay){
                SpawnBot();
                timeSinceLastSpawn = 0f;
            }
        }
    }

    void SpawnBot(){
        Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle.normalized * spawnRadius;
        GameObject newBot = Instantiate(botPrefab,spawnPosition,Quaternion.identity) as GameObject;
        bots.Add(newBot);
    }
}
