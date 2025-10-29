using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class clickUpgrades : MonoBehaviour
{
    [Header("Components")]
    public TMP_Text priceText;
    public Button button;
    public TMP_Text upgradeNameText;
    public GameObject clickerUpgrade;

    [Header("Generator Values")]
    public int itemPrice;

    [Header("Managers")]
    public GameManager gameManager;

    public void onClickAction()
    {
        bool purchaseSuccess = PurchaseAction(itemPrice);
        if (purchaseSuccess)
        {
            // Increase the per-click value once
            //float clickBonus = gameManager.lastIncomeValue * 0.02f;
            //gameManager.baseClickAmount += clickBonus;
            gameManager.clickMultiplier = 0.02f;

            clickerUpgrade.SetActive(false);
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
