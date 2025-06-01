using System;
using TMPro;
using UnityEngine;

public class SistemaVidas : MonoBehaviour
{
    [SerializeField] public float vidas;

    [Header("Solo para Player")]
    [SerializeField] private TextMeshProUGUI vidasText;
    [SerializeField] private GameManager gameManager;
    private float vidaMaxima;

    void Start()
    {
        vidaMaxima = vidas;
    }

    public void RecibirDanio(float danioRecibido)
    {
        vidas -= danioRecibido;

        if(this.gameObject.CompareTag("PlayerHitBox"))
        {
            vidasText.text = vidas.ToString();

            if(vidas <= 0) {
                gameManager.EndGame();
            }
        }

        if(vidas <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    internal void OtorgarVida(float vidaOtorgada)
    {
        //Solo damos vida si tenemos vida por rellenar
        if(vidas < vidaMaxima)
        {
            vidas += vidaOtorgada;
            //Si nos pasamos del maximo, capamos a ese valor
            if(vidas > vidaMaxima)
            {
                vidas = vidaMaxima;
            }
            vidasText.text = vidas.ToString();
        }
    }
}
