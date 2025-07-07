using UnityEngine;

    using UnityEngine;
    using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{  
    public Vector2 entrada;
     Rigidbody2D rb;
    public float velocidad = 5f;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = velocidad * entrada;
    }


    public void Movimiento(InputAction.CallbackContext Contexto)
    {

        Vector2 valorEntrada = Contexto.ReadValue<Vector2>();

        animator.SetBool("estaCaminando", true);

        // Determinar el eje dominante
        if (Mathf.Abs(valorEntrada.x) > Mathf.Abs(valorEntrada.y))
        {
            // Movimiento horizontal
            entrada = new Vector2(Mathf.Sign(valorEntrada.x), 0);
        }
        else if (Mathf.Abs(valorEntrada.y) > 0)
        {
            // Movimiento vertical
            entrada = new Vector2(0, Mathf.Sign(valorEntrada.y));
        }
        else
        {
            entrada = Vector2.zero;
        }

        //asignar valores a los parametros entradaX y entradaY
        animator.SetFloat("entradaX", entrada.x);
        animator.SetFloat("entradaY", entrada.y);

        if (Contexto.canceled){
            animator.SetBool("estaCaminando", false);
        }
    }

    
}
