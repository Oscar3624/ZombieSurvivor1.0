using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour, IRecolectable
{
    [SerializeField] private int value = 1;

    // Evento est�tico para notificar la recolecci�n    
    public static event Action<int> OnKeysChanged;

    public void Collect()
    {
        //Debug.Log("LLave Recolectada");

        OnKeysChanged?.Invoke(value);

        Destroy(gameObject);
    }
}
