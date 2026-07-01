using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;

    public enum EstadoJogo
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    public EstadoJogo estadoAtual;
    private PlayerInput entradaJogador;

    [Header("Configurações do Splash")]
    [SerializeField] private float tempoDoSplash = 2f; // Tempo que o Splash vai durar

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        MudarEstado(EstadoJogo.Iniciando);
        AlocarInput();

        // INICIA A CONTAGEM DO SPLASH ASSIM QUE O JOGO ABRE
        StartCoroutine(RotinaSplash());
    }

    private IEnumerator RotinaSplash()
    {
        // Espera os 2 segundos na tela de Splash
        yield return new WaitForSeconds(tempoDoSplash);

        // Carrega o Menu Principal automaticamente usando o nome EXATO da cena
        CarregarCena("MenuPrincipal");
    }

    public void MudarEstado(EstadoJogo novoEstado)
    {
        estadoAtual = novoEstado;
        Debug.Log("Estado atual: " + estadoAtual);
    }

    public void CarregarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);

        if (nomeCena == "Splash")
        {
            MudarEstado(EstadoJogo.Iniciando);
        }
        else if (nomeCena == "MenuPrincipal" || nomeCena == "Menu")
        {
            MudarEstado(EstadoJogo.MenuPrincipal);
        }
        else if (nomeCena == "Jogo")
        {
            MudarEstado(EstadoJogo.Gameplay);
        }

        AlocarInput();
    }

    public void AlocarInput()
    {
        entradaJogador = FindFirstObjectByType<PlayerInput>();
        if (entradaJogador != null)
        {
            Debug.Log("Player Input encontrado!");
        }
        else
        {
            Debug.Log("Nenhum Player Input encontrado.");
        }
    }

    public void SairJogo()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}