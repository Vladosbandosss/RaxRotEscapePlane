using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject rocket, plane;

    public bool spawnRocket, spawnPlane;

    public float spawnTime = 3f;

    [HideInInspector]
    public bool canSpawn = true;


    private void Start()
    {
        Invoke(nameof(SpawnEnemy), spawnTime);
    }
    public void ActivateSpawning()
    {
        Invoke(nameof(SpawnEnemy), spawnTime);
    }

    void SpawnEnemy()
    {
        GameObject go = null;

        if (spawnRocket)
        {
            go = Instantiate(rocket, transform.position, Quaternion.identity);
        }

        if (spawnPlane)
        {
            go = Instantiate(plane, transform.position, Quaternion.identity);
        }

        go.GetComponent<Enemy>().enemySpawner = this;

        canSpawn = false;
    }
}
