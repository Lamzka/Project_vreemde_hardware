using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Package : MonoBehaviour
{
    public PackageInfo Info;
    public List<GameObject> PackageList = new List<GameObject>();
    [SerializeField] private GameObject packagePrefab;

    [SerializeField] private TMP_Text questList;

    void Start()
    {
        AllPackages();
        Names();
    }

    void Update()
    {
    }


    private void AllPackages()
    {
        for (int i = 0; i < 10; ++i)
        {
            PackageList.Add(packagePrefab);
        }
        //SpawnPackages(); //of in start?
    }

    /* private void SpawnPackages()
     {
         for (int i = 0; i < PackageList.Count; ++i)
         {
            //we kunnen zeggen van ze spawnen in, of ze staan al in de scene en dan sleep je ze in de allpackages list handmatig
         }
     }*/

    private void Names()
    {
        if (Info == null || Info.RecieverPlanet.Length == 0 || Info.RecieverName.Length == 0)
        {
            return;
        }

        System.Text.StringBuilder nameListBuilder = new System.Text.StringBuilder();

        for (int i = 0; i < PackageList.Count; ++i)
        {
            string randomPlanet = Info.RecieverPlanet[Random.Range(0, Info.RecieverPlanet.Length)];
            string randomName = Info.RecieverName[Random.Range(0, Info.RecieverName.Length)];

            nameListBuilder.AppendLine($"{randomName} - {randomPlanet}");
        }

        questList.text = nameListBuilder.ToString();
    }
}


