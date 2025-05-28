using System.Collections;
using UnityEngine;

public class Slime : BasicEnemy
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
