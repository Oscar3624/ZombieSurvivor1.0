using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.Mathematics;
using UnityEngine;

public class ZonaPicos : MonoBehaviour
{
    [SerializeField] private float damagePerSecond = 10f; // Daño por segundo
    private bool playerInZone = false; // Bandera para verificar si el jugador está en la zona con picos
    private IHacerDanio player; // Referencia al jugador (u otro objeto que implemente IHacerDanio)

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra implementa IHacerDanio
        player = other.GetComponent<IHacerDanio>();
        if (player != null)
        {
            playerInZone = true; // Marca que el jugador está dentro de la zona
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica si el objeto que sale es el mismo jugador
        if (other.GetComponent<IHacerDanio>() == player)
        {
            playerInZone = false; // Marca que el jugador salió de la zona
            player = null; // Limpia la referencia
        }
    }

    private void Update()
    {
        // Si el jugador está en la zona, aplica daño progresivo
        if (playerInZone && player != null)
        {            

            player.TakeDamage(damagePerSecond * Time.deltaTime);
            
        }
    }

}
