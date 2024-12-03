using UnityEngine;

[CreateAssetMenu(fileName = "PackageInfo", menuName = "ScriptableObjects/PackageInfoScriptableObject", order = 1)]
public class PackageInfo : ScriptableObject //the properties of the packages
{
    public string[] RecieverPlanet;
    public string[] RecieverName;

    public float Durability;

    public int Earnings;
}
