using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text coinsText;

    private void OnEnable()
    {
        PlayerObserverManager.OnCoinsChanged += UpdateCoins;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnCoinsChanged -= UpdateCoins;
    }

    private void Start()
    {
        UpdateCoins(0);
    }

    private void UpdateCoins(int coins)
    {
        coinsText.text = "Moedas: " + coins;
    }
}