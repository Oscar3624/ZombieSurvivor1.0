using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour, IMuerte, IHacerDanio
{
    private float health = 100f;
    private float detectionRange = 2.5f;
    private float attackRange = 0.5f;
    
    private float speedZombie = 100f;    

    
    //Solo publico para pruebas, debo implementar get y set
    public Animator animator;
    public Rigidbody2D rb;
    public AudioClip attackZombie;


    private Transform player;
    //private bool isAttacking = false;

    // Referencia al estado actual
    private IZombieState currentState;    

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //Comienza con estado de reposo
        SetState(new ZombieIdleState(this));   
        
    }

    
    void Update()
    {
        currentState.HandleInput();
        currentState.UpdateState();
    }

    public void SetState(IZombieState newState)
    {
        currentState = newState;
        currentState.EnterState();
    }

    public bool IsPlayerInRange(float range)
    {
        return Vector2.Distance(transform.position, Player.position) < detectionRange;

    } 
    
    public bool IsPlayerInRangeAttack(float range)
    {
        return Vector2.Distance(transform.position, Player.position) < attackRange;

    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }


    //Getters and Setters
    public float DetectionRange { get => detectionRange; set => detectionRange = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }
    public Transform Player { get => player; set => player = value; }
    public float SpeedZombie { get => speedZombie; set => speedZombie = value; }  


    /*
    //Metodo para cambiar al siguiente punto de patrullaje
    public void SwitchPatrolTarget()
    {
        currentPatrolTarget = (currentPatrolTarget == patrullajePuntoA) ? patrullajePuntoB : patrullajePuntoA;

        //Girar los sprites 
        haciaDerecha = !haciaDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        moveSpeed *= -1;
    }

    public void MoverHaciaPuntoDePatrullaje()
    {
        //Mover zombie hacia el punto de patrullaje objetivo
        Vector2 direction = (currentPatrolTarget.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }*/
}

