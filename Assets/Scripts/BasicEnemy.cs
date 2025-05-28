using System.Collections;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] protected Transform[] waypoints;
    [SerializeField] protected float velocidadPatrulla;
    [SerializeField] protected float danioAtaque;
    protected Vector3 destinoActual;
    protected int indiceActual = 1;

    protected IEnumerator Patrulla()
    {
        while (true)
        {
            while (transform.position != destinoActual)
            {
                transform.position = Vector3.MoveTowards(transform.position, destinoActual, velocidadPatrulla * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            DefinirNuevoDestino();
        }
    }

    private void DefinirNuevoDestino()
    {
        indiceActual++;
        if (indiceActual >= waypoints.Length)
        {
            indiceActual = 0;
        }
        destinoActual = waypoints[indiceActual].position;
        EnfocarDestino();
    }

    private void EnfocarDestino()
    {
        if (destinoActual.x > transform.position.x)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeteccionPlayer"))
        {

        }
        else if (collision.gameObject.CompareTag("PlayerHitBox"))
        {
            SistemaVidas sistemaVidasPlayer = collision.gameObject.GetComponent<SistemaVidas>();
            sistemaVidasPlayer.RecibirDanio(danioAtaque);
        }
    }
}
