using UnityEngine;

public class TelaInicial : MonoBehaviour
{
    public void IniciarJogo()
    {
        GameManager.Instancia.CarregarCena("Jogo");
    }

    public void Sair()
    {
        GameManager.Instancia.SairJogo();
    }
}