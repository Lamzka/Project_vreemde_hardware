using System.Collections.Generic;
using UnityEngine;

public class PackageSpawner : MonoBehaviour, IDropOffCheck
{
    [SerializeField] private GameObject packagePrefab;

    public List<GameObject> SpawnPoints = new List<GameObject>();

    private void OnEnable()
    {

        GameObject.FindGameObjectWithTag("Marker").GetComponent<DropOffObserver>().SetListeners(this);
    }

    private void OnDisable()
    {

        GetComponent<DropOffObserver>().RemoveListeners(this);
    }

    public void CheckDropOff()
    {
        foreach (GameObject spawnPoint in SpawnPoints)
        {
            Instantiate(packagePrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
