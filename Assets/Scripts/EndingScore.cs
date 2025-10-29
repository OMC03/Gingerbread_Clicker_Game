using TMPro;
using UnityEngine;

public class EndingScore : MonoBehaviour
{
    public TMP_Text totalCookies;

    public void Start()
    {
        totalCookies.text = "You have collected a total of " + GameManager.totalCookies.ToString() + " cookies!";
    }
}
