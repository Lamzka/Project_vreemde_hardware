using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starspawning : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private Transform designatedSpawnArea;
    [SerializeField] private float spawnTimer;

    private void StarSpawning()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        
        Instantiate<GameObject>(starPrefab, randomPosition, Quaternion.identity, designatedSpawnArea);

        spawnTimer = 3;
    }

    private void OnTriggerStay(Collider other)
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            StarSpawning();
        }
    }

}
