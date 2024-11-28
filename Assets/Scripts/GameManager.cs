using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player; // Referencia al jugador    

    private IHUD hud;
    [SerializeField] private HUDController hudController;
    [SerializeField] private TimerController timerController;

    private int diamondCount = 0; //Contador de diamantes
    private int keyCount = 0;

    [SerializeField] private AudioClip collectObjets;
    

    private void Awake()
    {
        hud = hudController;
    }
    private void Start()
    {
        // Actualiza el HUD con los valores iniciales
        hud.UpdateCoins(diamondCount);
        hud.UpdateHealth(player.MaxHealth);
        hud.UpdateKeys(keyCount);
    }

    private void OnEnable()
    {
        // Suscribirse a los eventos del jugador
        if (player != null)
        {
            player.OnHealthChanged += UpdateHealthUI;
            player.OnPlayerDied += HandlePlayerDeath;
            Diamante.OnCoinsChanged += IncrementCountDiamond;
            Corazon.OnHeartCollected += AddPlayerHeal;
            Llave.OnKeysChanged += IncrementCountKey;
            Cerradura.OnPadlockChanged += LoadSceneVictory;
        }

        if (timerController != null)
        {
            timerController.OnTimeChanged += HandleTimeChanged; // Escuchar cambios en el tiempo
            timerController.OnTimeOver += HandleTimeOver;       // Escuchar cuando el tiempo se acaba
        }
    }

    private void OnDisable()
    {
        // Desuscribirse de los eventos del jugador
        if (player != null)
        {
            player.OnHealthChanged -= UpdateHealthUI;
            player.OnPlayerDied -= HandlePlayerDeath;
            Diamante.OnCoinsChanged -= IncrementCountDiamond;
            Corazon.OnHeartCollected -= AddPlayerHeal;
            Llave.OnKeysChanged -= IncrementCountKey;
            Cerradura.OnPadlockChanged -= LoadSceneVictory;
        }

        if (timerController != null)
        {
            timerController.OnTimeChanged -= HandleTimeChanged; 
            timerController.OnTimeOver -= HandleTimeOver;       
        }
    }

    private void LoadSceneVictory()
    {
        if (keyCount > 0)
        {
            SceneManager.LoadScene("Victory");
        }
    }

    private void IncrementCountKey(int obj)
    {
        AudioManager.Instance.PlaySound(collectObjets);

        keyCount += obj;

        hud.UpdateKeys(keyCount);
    }

    private void AddPlayerHeal(float obj)
    {
        AudioManager.Instance.PlaySound(collectObjets);

        player.CurrentHealth += obj;

        //Asegurar que la vida no supere la cantidad maxima estipulada
        player.CurrentHealth = Mathf.Clamp(player.CurrentHealth, 0, player.MaxHealth);

        //Actualizar UI
        hud.UpdateHealth(player.CurrentHealth);
    }

    private void IncrementCountDiamond(int obj)
    {
        AudioManager.Instance.PlaySound(collectObjets);

        diamondCount += obj;
        Debug.Log("Contador de diamantes: " + diamondCount);
        hud.UpdateCoins(diamondCount);
    }

    private void UpdateHealthUI(float currentHealth)
    {
        Debug.Log("Vida actual del jugador: " + currentHealth);

        // Aquí actualizar la UI de HUD
        hud.UpdateHealth(currentHealth);
    }

    private void HandlePlayerDeath()
    {
        //Actualizar la vida a 0
        hud.UpdateHealth(0f);

        //Cargo la escena de game over
        SceneManager.LoadScene("GameOver");
    }

    private void HandleTimeOver()
    {
        HandlePlayerDeath();
    }

    private void HandleTimeChanged(float currentTime)
    {        
        hud.UpdateTimer(currentTime);
    }

}
