using UnityEngine;

public class BolaFuego : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float impulso;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       rb.AddForce(transform.right * impulso, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
