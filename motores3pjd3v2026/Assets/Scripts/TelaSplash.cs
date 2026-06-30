using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorMenu : MonoBehaviour
{
  
    [SerializeField] private string nomeDaCenaDestino = "Jogo"; 

    public void IrParaTelaInicial()
    {
        SceneManager.LoadScene(nomeDaCenaDestino);
    }
}