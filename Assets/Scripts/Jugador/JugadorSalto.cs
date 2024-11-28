using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorSalto : MonoBehaviour
{
    private IPlayerInput playerInput;
    private Rigidbody2D rb;

    //Controlar las animaciones
    private Animator animator;

    [SerializeField] private AudioClip jumpSound;


    [SerializeField] private float jumpForce = 10f;

    public void Initialize(IPlayerInput input)
    {
        playerInput = input;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        //Debug.Log("Ingresa jump");

        if (playerInput.GetJumpInput() && Mathf.Abs(rb.velocity.y) < 0.01f)  // Solo salta si esta en el suelo
        {
            animator.SetBool("Grounded", false);

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            AudioManager.Instance.PlaySound(jumpSound);
        }
        else
        {
            if (Mathf.Abs(rb.velocity.y) <= 0.01f) 
            {
                animator.SetBool("Grounded", true);
            }
            
        }
       
    }
}
