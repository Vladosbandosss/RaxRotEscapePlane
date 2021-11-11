using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    public GameObject minePrefab;

    public float minX = -8.3f;
    public float maxX = 8.3f;

    public float spawnInterval = 3.5f;

    void Start()
    {
        Invoke(nameof(ActivateMineSpawner), 1f);
    }
    
    void ActivateMineSpawner()
    {
        StartCoroutine(nameof(SpawnMines));

        Invoke(nameof(ActivateMineSpawner), spawnInterval);
    }
    IEnumerator SpawnMines()
    {
        int count = Random.Range(3, 8);

        Vector3 temp = transform.position;

        for (int i = 0; i < count; i++)
        {
            temp.x = Random.Range(minX, maxX);

            Instantiate(minePrefab, temp, Quaternion.identity);

            yield return null;
        }
    }
}
