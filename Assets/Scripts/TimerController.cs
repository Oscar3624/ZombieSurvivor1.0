using UnityEngine;
using System;

public class TimerController : MonoBehaviour
{
    [SerializeField] private float startTime = 120f; // Tiempo inicial en segundos
    private float currentTime;

    //Patron de diseño State
    public event Action<float> OnTimeChanged; // Evento para notificar cambios en el tiempo
    public event Action OnTimeOver;          // Evento para notificar que se acabó el tiempo

    private bool isRunning = true;

    private void Start()
    {
        currentTime = startTime;
        StartTimer();
    }

    private void Update()
    {
        if (isRunning && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            OnTimeChanged?.Invoke(currentTime);

            if (currentTime <= 0)
            {
                currentTime = 0;
                isRunning = false;
                OnTimeOver?.Invoke(); // Notificar que el tiempo se acabó
            }
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer(float newTime)
    {
        currentTime = newTime;
        isRunning = true;
        OnTimeChanged?.Invoke(currentTime);
    }
}

