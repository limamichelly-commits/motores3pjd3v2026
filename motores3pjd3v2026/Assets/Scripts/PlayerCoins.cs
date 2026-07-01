using System;

public static partial class PlayerObserverManager
{
   
    public static event Action<int> OnCoinCountChanged;
    
    public static void SendCoinCount(int currentCoins)
    {
        OnCoinCountChanged?.Invoke(currentCoins);
    }
}