using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour, IHUD
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image barImage;

    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private TextMeshProUGUI keyText;
    

    public void UpdateCoins(int amount)
    {
        //coinsText.text = "Diamonds: " + amount;
        coinsText.text = amount.ToString();
    }

    public void UpdateHealth(float health)
    {
        //healthText.text = "Health: " + health;

        //Actualizar la barra de vida
        barImage.fillAmount = health / 100f;
    }

    public void UpdateKeys(int amount)
    {
        keyText.text = amount.ToString();
    }

    public void UpdateTimer(float currentTime)
    {
        if (currentTime > 0f) 
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
