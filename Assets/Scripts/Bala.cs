using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour, IProyectil
{
    private Rigidbody2D rb;
    private float lifeTime = 5f;
    private float damageBullet = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float speed)
    {
        if (rb != null)
        {
            rb.velocity = direction * speed;

            Destroy(gameObject, lifeTime); // Destruir la bala después de un tiempo
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Logica al colisionar (por ejemplo, danar enemigos).
        IHacerDanio damageable = collider.gameObject.GetComponent<IHacerDanio>();
        if (damageable != null)
        {
            damageable.TakeDamage(damageBullet); //daño de una bala
        }

        Destroy(gameObject); // Destruir el proyectil tras colisionar.
    }

}
