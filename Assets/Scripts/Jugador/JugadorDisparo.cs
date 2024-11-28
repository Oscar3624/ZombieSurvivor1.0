using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDisparo : MonoBehaviour
{
    private IArma weapon;

    private IPlayerInput playerInput;

    //Controlar las animaciones
    private Animator animator;

    [SerializeField] private AudioClip shootSound;

    //private Transform transform;


    public void Initialize(IPlayerInput input)
    {
        playerInput = input;
        animator = GetComponent<Animator>();
        //transform = GetComponent<Transform>();

        // Encuentra el arma del jugador automaticamente si esto en el mismo GameObject.
        weapon = GetComponentInChildren<IArma>();
    }

    public void Shoot()
    {
        //Enviar la direccion de la bala
        Vector3 direction;
        if (transform.localScale.x > 0.0f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }


        if (playerInput.GetAttackInput() && weapon != null)
        {
            animator.SetBool("Shooting", true);

            weapon.PlayerShoot(direction);

            AudioManager.Instance.PlaySound(shootSound);

        }else
        {
            animator.SetBool("Shooting", false);
        }
    }


       
}
