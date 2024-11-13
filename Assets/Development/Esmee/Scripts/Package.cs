using UnityEngine;

public class Package : MonoBehaviour
{
    public PackageInfo Info;
    // Start is called before the first frame update
    void Start()
    {
        Info.Durability = 0; //like het kan op deze manier alleen als elk package dit script heeft werkt dat niet //moet ik 100 aparte scripts maken???
    }

    // Update is called once per frame
    void Update()
    {

    }
}
