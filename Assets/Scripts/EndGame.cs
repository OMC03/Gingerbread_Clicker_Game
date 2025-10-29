using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [Header("Components")]
    public TMP_Text priceText;
    public Button button;
    public TMP_Text upgradeNameText;

    [Header("Generator Values")]
    public int itemPrice;
    public string SceneToLoad;

    [Header("Managers")]
    public GameManager gameManager;

    public void onClickAction()
    {
        bool purchaseSuccess = PurchaseAction(itemPrice);
        if (purchaseSuccess)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }

    public void UpdateUI()
    {
        priceText.text = itemPrice.ToString();
        bool canAfford = gameManager.count >= itemPrice;
        button.interactable = canAfford;
    }

    public bool PurchaseAction(int cost)
    {
        if (gameManager.count >= cost)
        {
            gameManager.count -= cost;
            return true;
        }
        return false;
    }
}
