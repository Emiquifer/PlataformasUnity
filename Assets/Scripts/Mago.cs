using System.Collections;
using UnityEngine;

public class Mago : MonoBehaviour
{
    [SerializeField] private BolaFuego bolaFuego; //Prefab
    [SerializeField] private Transform puntoSpawn;
    [SerializeField] private float tiempoAtaque;
    [SerializeField] private float danioAtaque;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(RutinaAtaque());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RutinaAtaque()
    {
        while (true)
        {
            anim.SetTrigger("atacar");
            yield return new WaitForSeconds(tiempoAtaque);
        }
    }

    private void LanzarBola()
    {
        Instantiate(bolaFuego, puntoSpawn.position, transform.rotation);
    }
}
