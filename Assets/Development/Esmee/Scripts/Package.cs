using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Package : MonoBehaviour
{
    public PackageInfo Info;
    public List<GameObject> PackageList = new List<GameObject>(); // A list to hold the packages.
    [SerializeField] private GameObject packagePrefab;

    [SerializeField] private TMP_Text questList; //text for the names from the list

    void Start()
    {
        AllPackages();
    }

    private void AllPackages()
    {
        for (int i = 0; i < 10; ++i) // Loop to add 10 instances of the packagePrefab to the PackageList.
        {
            PackageList.Add(packagePrefab);
        }
    }
}


