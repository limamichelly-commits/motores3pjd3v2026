using System;

public static partial class PlayerObserverManager
{
    public static event Action<int> OnMoedasAtualizadas;
    public static void NotificarMoedas(int quantidade)
    {
        OnMoedasAtualizadas?.Invoke(quantidade);
    }
}