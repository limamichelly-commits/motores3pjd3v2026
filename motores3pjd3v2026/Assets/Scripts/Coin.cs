using UnityEngine;

public class Coin : MonoBehaviour
{
    // Opcional: Apenas para dar um efeito visual na moeda girando
    void Update()
    {
        transform.Rotate(Vector3.up * 90 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se quem colidiu foi o jogador
        if (other.CompareTag("Player"))
        {
            // Tenta pegar o componente Player da entidade que colidiu
            PlayerCoins player = other.GetComponent<PlayerCoins>();
            
            if (player != null)
            {
                player.AddCoin(); // Adiciona a moeda ao jogador
                Destroy(gameObject); // Remove a moeda da cena
            }
        }
    }
}