using UnityEngine;

[CreateAssetMenu(fileName = "PackageInfo", menuName = "ScriptableObjects/PackageInfoScriptableObject", order = 1)]
public class PackageInfo : ScriptableObject
{
    public string RecieverName;
    public string RecieverPlanet;


    public float Durability;

    public float Price;

    public GameObject Prefab;
}
