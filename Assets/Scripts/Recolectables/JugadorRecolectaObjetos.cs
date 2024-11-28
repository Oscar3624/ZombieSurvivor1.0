using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorRecolectaObjetos : MonoBehaviour
{
    private IRecolectable collectible; // Interface para la recoleccion de objetos

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Ingresa a trigger");

        collectible = other.GetComponent<IRecolectable>();
        if (collectible != null)
        {
            collectible.Collect(); // El jugador recoge la un objeto que se puede recolectar puede ser un d o c
        }
    }
}
