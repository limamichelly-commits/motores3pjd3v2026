using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text coinText;

    private void OnEnable()
    {
        PlayerObserverManager.OnCoinChanged += UpdateCoins;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnCoinChanged -= UpdateCoins;
    }

    void UpdateCoins(int amount)
    {
        coinText.text = "Moedas: " + amount;
    }
}