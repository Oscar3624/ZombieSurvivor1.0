using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour, IRecolectable
{
    [SerializeField] private float healthValue = 10;   

    // Evento est�tico para notificar la recolecci�n
    public static event Action<float> OnHeartCollected; // Env�a la cantidad de vida ganada

    public void Collect()
    {
        
        Debug.Log("Corazon recolectado");

        // Notificar que el coraz�n fue recolectado y enviar el valor de vida
        OnHeartCollected?.Invoke(healthValue);

        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
