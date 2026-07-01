using UnityEngine;

public class Coin : MonoBehaviour
{
    public int velocidadeGiro = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instancia != null)
            {
                GameManager.Instancia.SubtrairMoedas(1);
            }
            
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up * velocidadeGiro * Time.deltaTime, Space.World);
    }
}