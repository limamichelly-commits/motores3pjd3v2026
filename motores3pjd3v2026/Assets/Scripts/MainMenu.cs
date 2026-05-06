using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuPrincipal : MonoBehaviour
{
    
    public void IniciarJogo()
    {
        
        SceneManager.LoadScene("GetStarted_Scene");
    }

    
    public void SairDoJogo()
    {
        
        Debug.Log("O jogador clicou em Sair");
        
        
        Application.Quit();
    }
}