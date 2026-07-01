using UnityEngine;
using TMPro;

public class ControladorInterface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoMoedas;

    private void OnEnable()
    {
        PlayerObserverManager.OnMoedasAtualizadas += AtualizarTextoMoedas;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnMoedasAtualizadas -= AtualizarTextoMoedas;
    }

    private void Start()
    {
        
        if (GameManager.Instancia != null)
        {
            AtualizarTextoMoedas(GameManager.Instancia.restantes);
        }
    }

    private void AtualizarTextoMoedas(int moedasRestantes)
    {
        if (textoMoedas != null)
        {
            textoMoedas.text = $"Moedas Restantes: {moedasRestantes}";
        }
    }
}