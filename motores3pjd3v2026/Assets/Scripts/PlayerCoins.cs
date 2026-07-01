using System;

public static class PlayerObserverManager
{
    // Tem que ter public static aqui:
    public static event Action<int> OnCoinCountChanged;

    // Tem que ter public static aqui também:
    public static void SendCoinCount(int currentCoins)
    {
        OnCoinCountChanged?.Invoke(currentCoins);
    }
}