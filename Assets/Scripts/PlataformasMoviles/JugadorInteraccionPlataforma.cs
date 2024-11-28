using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorInteraccionPlataforma : MonoBehaviour
{
    private Transform originalParent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            originalParent = transform.parent; // Guardar el padre original del jugador
            transform.SetParent(collision.transform); // Vincular al jugador a la plataforma
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            StartCoroutine(ChangeParentDelayed());

        }
    }

    private IEnumerator ChangeParentDelayed()
    {
        yield return null; // Espera un fotograma
        // Restaurar el padre original del jugador al salir de la plataforma
        transform.SetParent(originalParent);
    }

}
