using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;
    
    
    public TextMeshProUGUI msgVitoria;
    public int restantes;
    public AudioClip clipMoeda, clipVitoria;

    public enum EstadoJogo
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    public EstadoJogo estadoAtual;
    private PlayerInput entradaJogador;

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
            return;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += AoCarregarCena;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= AoCarregarCena;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Splash")
        {
            AtualizarEstadoPorCena("Splash");
            AlocarInput();
        }
        else
        {
            CarregarCena("Splash");
        }
    }

    public void CarregarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    private void AoCarregarCena(Scene cena, LoadSceneMode modo)
    {
        AtualizarEstadoPorCena(cena.name);
        AlocarInput();
    }

    private void AtualizarEstadoPorCena(string nomeCena)
    {
        if (nomeCena == "Splash")
        {
            MudarEstado(EstadoJogo.Iniciando);
        }
        else if (nomeCena == "Menu Principal")
        {
            MudarEstado(EstadoJogo.MenuPrincipal);
        }
        else if (nomeCena == "GetStarted_Scene")
        {
            MudarEstado(EstadoJogo.Gameplay);
            
            
            if (!SceneManager.GetSceneByName("GUI").isLoaded)
            {
                SceneManager.LoadScene("GUI", LoadSceneMode.Additive);
            }
        }
    }

    public void MudarEstado(EstadoJogo novoEstado)
    {
        estadoAtual = novoEstado;
        Debug.Log("Estado atual alterado para: " + estadoAtual);
    }

    public void AlocarInput()
    {
        entradaJogador = FindFirstObjectByType<PlayerInput>();
        if (entradaJogador != null)
        {
            Debug.Log("Player Input encontrado na cena atual!");
        }
        else
        {
            Debug.Log("Nenhum Player Input encontrado nesta cena.");
        }
    }
    
    public void SubtrairMoedas(int valor)
    {
        restantes -= valor;
        
    
        PlayerObserverManager.NotificarMoedas(restantes);
       
        if (restantes <= 0)
        {
            if (msgVitoria != null)
            {
                msgVitoria.text = "PARABÉNS!";
            }
        }
    }

    public void SairJogo()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}