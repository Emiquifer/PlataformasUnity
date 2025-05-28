using System.Collections;
using UnityEngine;

public class Bat : BasicEnemy
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destinoActual = waypoints[indiceActual].position;
        StartCoroutine(Patrulla());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
