using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerradura : MonoBehaviour, IRecolectable
{
    public static event Action OnPadlockChanged;

    public void Collect()
    {
        Debug.Log("Solo ganaras si recolectaste por lo menos una llave.");
        OnPadlockChanged?.Invoke();

    }
}
