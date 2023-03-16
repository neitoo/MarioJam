using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawn : MonoBehaviour
{
    public GameObject prefab;
    private float radius = 40f;
    private float spawnInterval;
    private int maxSpawnCount = 2;
    public static int spawnCount;
    private float lastSpawnTime;

    private void Start()
    {
        if (!ModeScript.isBeginner)
        {
            spawnInterval = 180f;
        }
        else
        {
            spawnInterval = 30f;
        }
        StartCoroutine(SpawnPrefab());
    }

    private IEnumerator SpawnPrefab()
    {
        while (true)
        {
            if (spawnCount < maxSpawnCount && Time.time - lastSpawnTime > spawnInterval)
            {
                Vector2 spawnPosition = GetRandomSpawnPosition();
                Instantiate(prefab, spawnPosition, Quaternion.identity);
                spawnCount++;
                lastSpawnTime = Time.time;
            }
            yield return null;
        }
    }

    private Vector2 GetRandomSpawnPosition()
    {
        Vector3 randomPos = Random.insideUnitSphere * radius;
        randomPos += transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPos, 1f);
        while (colliders.Length > 0)
        {
            randomPos = Random.insideUnitSphere * radius;
            randomPos += transform.position;
            colliders = Physics2D.OverlapCircleAll(randomPos, 1f);
        }
        return randomPos;
    }
}
