using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IMuerte, IHacerDanio
{
   
    private IPlayerInput playerInput;
    private JugadorMovimiento movement;
    private JugadorSalto jumping;
    private JugadorDisparo shooting;

    //Para activar escena de pausa
    private JugadorPausaJuego pause;

    private float maxHealth = 100f; // Vida máxima del jugador    
    private float currentHealth;
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }


    // Eventos para notificar cambios
    public event Action<float> OnHealthChanged; // Notifica cambios en la vida
    public event Action OnPlayerDied; // Notifica la muerte del jugador
    
    void Start()
    {
        playerInput = GetComponent<IPlayerInput>(); // Asumimos que la entrada se maneja por PlayerInput
        movement = GetComponent<JugadorMovimiento>();
        jumping = GetComponent<JugadorSalto>();
        shooting = GetComponent<JugadorDisparo>();
        pause = GetComponent<JugadorPausaJuego>();

        // Inicializamos con la dependencia de entrada
        movement.Initialize(playerInput);
        jumping.Initialize(playerInput);
        shooting.Initialize(playerInput);
        pause.Initialize(playerInput);

        //Salud del jugador
        currentHealth = MaxHealth;
    }

    void Update()
    {
        movement.Move();   // Movimiento horizontal
        jumping.Jump();    // Salto
        shooting.Shoot(); //Disparo
        pause.PauseGame();
    }
    

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);

        // Notificar cambios en la vida
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }     
        
    }    

    public void Die()
    {
        
        Debug.Log("El jugador ha muerto.");

        // Notificar la muerte del jugador
        OnPlayerDied?.Invoke();

        //Destruir el objeto
        //Destroy(gameObject);
        gameObject.SetActive(false); //solo lo desactivo

    }    
}
