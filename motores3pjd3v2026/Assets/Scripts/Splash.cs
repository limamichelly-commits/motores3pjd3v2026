using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);

        GameManager.Instancia.CarregarCena("MenuPrincipal");
    }
}