using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PackageQuestHandler : MonoBehaviour
{
    public static int PackagesDeliverd = 0;

    [SerializeField] private TMP_Text pakcageCountText;

    private void Start()
    {
        pakcageCountText.text = "Packages to Deliver: " + PackagesDeliverd;
    }

    public void AddPoint()
    {

        PackagesDeliverd++;
        pakcageCountText.text = "Packages to Deliver: " + PackagesDeliverd;

        if (PackagesDeliverd >= 4)
        {
            SceneManager.LoadScene(3);
        }

    }
}


