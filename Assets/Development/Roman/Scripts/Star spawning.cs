using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starspawning : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private float spawnTimer;

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            StarSpawning();
        }
    }

    private void StarSpawning()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
        
        Instantiate<GameObject>(starPrefab, randomPosition, Quaternion.identity);

        spawnTimer = 1;
    }

}
