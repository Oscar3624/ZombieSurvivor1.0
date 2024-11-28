using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.Mathematics;
using UnityEngine;

public class ZonaPicos : MonoBehaviour
{
    [SerializeField] private float damagePerSecond = 10f; // Da�o por segundo
    private bool playerInZone = false; // Bandera para verificar si el jugador est� en la zona con picos
    private IHacerDanio player; // Referencia al jugador (u otro objeto que implemente IHacerDanio)

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra implementa IHacerDanio
        player = other.GetComponent<IHacerDanio>();
        if (player != null)
        {
            playerInZone = true; // Marca que el jugador est� dentro de la zona
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica si el objeto que sale es el mismo jugador
        if (other.GetComponent<IHacerDanio>() == player)
        {
            playerInZone = false; // Marca que el jugador sali� de la zona
            player = null; // Limpia la referencia
        }
    }

    private void Update()
    {
        // Si el jugador est� en la zona, aplica da�o progresivo
        if (playerInZone && player != null)
        {            

            player.TakeDamage(damagePerSecond * Time.deltaTime);
            
        }
    }

}
