using UnityEngine;

public class CarregarCena : MonoBehaviour
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