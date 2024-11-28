using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Diamante : MonoBehaviour, IRecolectable
{
    [SerializeField] private int value = 1;    

    // Evento estático para notificar la recolección    
    public static event Action<int> OnCoinsChanged;

    public void Collect()    {
        

        // Logica para anadir valor a la puntuacion, destruir la moneda, etc.
        Debug.Log($"Recolectada una diamante de valor: {value}");

        OnCoinsChanged?.Invoke( value );

        Destroy(gameObject);        
    }
}
