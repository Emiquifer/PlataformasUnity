using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputH;

    [Header("Sistema de movimiento")]
    [SerializeField] private Transform pies;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private float distanciaSuelo;
    [SerializeField] private LayerMask sueloLayer;

    [Header("Sistema de ataque")]
    [SerializeField] private Transform puntoAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask hitBoxLayer;
    [SerializeField] private float danioAtaque;

    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Saltar();
        LanzarAtaque();
    }

    private void Movimiento()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(inputH * velocidadMovimiento, rb.linearVelocity.y);

        if (inputH != 0)
        {
            anim.SetBool("running", true);
            if(inputH > 0)
            {
                transform.eulerAngles = Vector3.zero;
            } else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        else
        {
            anim.SetBool("running", false);
        }
    }

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EstoyEnSuelo())
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            anim.SetTrigger("jump");
        }
    }

    private bool EstoyEnSuelo()
    {
        return Physics2D.Raycast(pies.position, Vector3.down, distanciaSuelo, sueloLayer);
    }

    private void LanzarAtaque()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");
        }
    }

    //Se ejecuta desde evento de animacion de ataque
    private void Ataque()
    {
        Collider2D[] collidersAtacados = Physics2D.OverlapCircleAll(puntoAtaque.position, radioAtaque, hitBoxLayer);
        foreach (Collider2D item in collidersAtacados)
        {
            SistemaVidas sistemaVidasEnemigo = item.gameObject.GetComponent<SistemaVidas>();
            sistemaVidasEnemigo.RecibirDanio(danioAtaque);            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(puntoAtaque.position, radioAtaque);
    }
}
