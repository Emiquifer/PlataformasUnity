using System;
using System.Collections;
using UnityEngine;

public class BolaFuego : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float impulso;
    [SerializeField] private float danioImpacto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       rb.AddForce(transform.right * impulso, ForceMode2D.Impulse);
       Destroy(this.gameObject, 2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerHitBox"))
        {
            SistemaVidas sistemaVidasPlayer = collision.gameObject.GetComponent<SistemaVidas>();
            sistemaVidasPlayer.RecibirDanio(danioImpacto);
            Destroy(this.gameObject);
        }
    }
}
