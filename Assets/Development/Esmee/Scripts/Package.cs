using UnityEngine;

public class Package : MonoBehaviour
{
    public PackageInfo Info;
    void Start()
    {
        if (Info != null && Info.RecieverPlanet.Length > 0)
        {
            string randomPlanet = Info.RecieverPlanet[Random.Range(0, Info.RecieverPlanet.Length)];
            Debug.Log("Random Planet: " + randomPlanet);
        }

        if (Info != null && Info.RecieverName.Length > 0)
        {
            string randomName = Info.RecieverName[Random.Range(0, Info.RecieverName.Length)];
            Debug.Log("Random Name: " + randomName);
        }
    }

    void Update()
    {
    }

}
