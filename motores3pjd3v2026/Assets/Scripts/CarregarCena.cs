using UnityEngine;

public class CarregarCena : MonoBehaviour
{
    public void IniciarJogo()
    {
        GameManager.Instancia.CarregarCena("Menu");
    }

    public void Sair()
    {
        GameManager.Instancia.SairJogo();
    }
}