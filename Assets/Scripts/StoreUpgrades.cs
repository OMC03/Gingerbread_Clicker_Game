using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreUpgrades : MonoBehaviour
{
    [Header("Components")]
    public TMP_Text priceText;
    public TMP_Text incomeInfoText;
    public Button button;
    public Image characterImage;
    public TMP_Text upgradeNameText;

    [Header("Generator Values")]
    public string upgradeName;
    public int startPrice;
    public float upgadePriceMultiplier;
    public float cookiesPerUpgrade;

    [Header("Managers")]
    public GameManager gameManager;

    int level = 0;

    private void Start()
    {
        UpdateUI();
    }

    public void clickAction()
    {
        int price = CalculatePrice();
        bool purchaseSuccess = gameManager.PurchaseAction(price);
        if (purchaseSuccess)
        {
            level++;
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        priceText.text = CalculatePrice().ToString();
        incomeInfoText.text = level.ToString() + " x " + cookiesPerUpgrade + "/s";
        //5 x 0.5/s
        bool canAfford = gameManager.count >= CalculatePrice();
        button.interactable = canAfford;

        bool isPurchased = level > 0;
        characterImage.color = isPurchased ? Color.white : Color.black;
        upgradeNameText.text = isPurchased ? upgradeName : "???";
}

    int CalculatePrice()
    {
        int price = Mathf.RoundToInt(startPrice * Mathf.Pow(upgadePriceMultiplier, level));
        return price;
    }

    public float CalculateIncomePerSecond()
    {
        return cookiesPerUpgrade * level;
    }
}
