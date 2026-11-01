using UnityEngine;
using TMPro; 

public class PlayerWallet : MonoBehaviour
{
    private int coinsCount = 0; 
    [SerializeField] private TextMeshProUGUI coinsText; 

    private void Start()
    {
        UpdateUI();
    }

    public void AddCoins(int amount)
    {
        coinsCount += amount;
        Debug.Log("Монет собрано: " + coinsCount); 
        UpdateUI(); 
    }

    private void UpdateUI()
    {
        if (coinsText != null)
        {
            coinsText.text = "Coins: " + coinsCount;
        }
    }
}