using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    private IPlayerInput playerInput;
    private Rigidbody2D rb;

    //Controlar las animaciones
    private Animator animator;
    private float horizontalInput;    

    [SerializeField] private float moveSpeed = 5f;

    public void Initialize(IPlayerInput input)
    {
        playerInput = input;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();        
    }

    public void Move()
    {
        horizontalInput = playerInput.GetHorizontalInput();


        if (horizontalInput!= 0)
        {
            // Animación de correr
            animator.SetBool("Running", true);

            // ??? Revisar forma de que el jugador
         // animator.SetBool("Grounded", true);

            //Girar sprite de jugador dependiendo si va a la izquierda o derecha  
            MirrorPlayer();

            Vector2 moveVelocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
            rb.velocity = moveVelocity;          
            
        }
        else
        {
            // Animación de correr
            animator.SetBool("Running", false);
        }
        
        
    }

    private void MirrorPlayer()
    {
        //Girar sprite de jugador dependiendo si va a la izquierda o derecha 

        if (horizontalInput < 0.0f)
        {
            transform.localScale = new Vector3(-0.18f, 0.18f, 0f);
        }
        else if (horizontalInput > 0.0f)
        {
            transform.localScale = new Vector3(0.18f, 0.18f, 0f);
        }
    }
}
