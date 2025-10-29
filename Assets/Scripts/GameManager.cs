using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text countText;
    [SerializeField] TMP_Text incomeText;
    [SerializeField] StoreUpgrades[] storeUpgrades;
    [SerializeField] int updatesPerSecond;
    [HideInInspector] public float count;
    public clickUpgrades clickUpgrades;
    public EndGame endGame;
    public float baseClickAmount;
    public float clickMultiplier;
    public float nextTimeCheck;
    public float lastIncomeValue;
    public static int totalCookies;
    private float idleCookieBuffer;
    private int cookiesToAdd;

    private void Start()
    {
        count = 0;
        nextTimeCheck = 1;
        updatesPerSecond = 5;
        baseClickAmount = 1f;
        clickMultiplier = 1f;
        UpdateUI();
        clickUpgrades.UpdateUI();
        endGame.UpdateUI();
    }

    void Update()
    {
        if (nextTimeCheck < Time.timeSinceLevelLoad)
        {
            IdleCalculate();
            nextTimeCheck = Time.timeSinceLevelLoad + (1f / updatesPerSecond);
        }
        UpdateUI();
        clickUpgrades.UpdateUI();
        endGame.UpdateUI();
        Debug.Log(totalCookies);
    }

    void IdleCalculate()
    {
        float sum = 0;
        foreach (var upgrade in storeUpgrades)
        {
            sum += upgrade.CalculateIncomePerSecond();
            upgrade.UpdateUI();
        }

        lastIncomeValue = sum;

        float incomeToAdd = sum / updatesPerSecond;
        count += incomeToAdd;

        // Use buffer to track partial cookies and convert only whole numbers to totalCookies
        idleCookieBuffer += incomeToAdd;
        int wholeCookies = Mathf.FloorToInt(idleCookieBuffer);

        if (wholeCookies > 0)
        {
            totalCookies += wholeCookies;
            idleCookieBuffer -= wholeCookies;
        }

        UpdateUI();
    }

    public void clickAction()
    {
        float dynamicClickAmount = baseClickAmount + (clickMultiplier * lastIncomeValue);
        count += dynamicClickAmount;
        cookiesToAdd = Mathf.RoundToInt(dynamicClickAmount);
        //Debug.Log(dynamicClickAmount);
        UpdateUI();
        totalCookies += cookiesToAdd;
    }

    public bool PurchaseAction(int cost)
    {
        if (count >= cost)
        {
            count -= cost;
            UpdateUI();
            return true;
        }
        return false;
    }

    void UpdateUI()
    {
        countText.text = Mathf.RoundToInt(count).ToString();
        incomeText.text = lastIncomeValue.ToString() + "/s";
    }
}
