using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour, IRecolectable
{
    [SerializeField] private float healthValue = 10;   

    // Evento estático para notificar la recolección
    public static event Action<float> OnHeartCollected; // Envía la cantidad de vida ganada

    public void Collect()
    {
        
        Debug.Log("Corazon recolectado");

        // Notificar que el corazón fue recolectado y enviar el valor de vida
        OnHeartCollected?.Invoke(healthValue);

        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
