using UnityEngine;

public class Starspawning : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private Transform designatedSpawnArea;
    [SerializeField] private float spawnTimer;

    private void StarSpawning()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-2000, 2000), Random.Range(-2000, 2000), Random.Range(-2000, 2000));

        Instantiate<GameObject>(starPrefab, randomPosition, Quaternion.identity, designatedSpawnArea);

        spawnTimer = 5;
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
