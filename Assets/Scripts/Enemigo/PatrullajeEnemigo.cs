using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullajeEnemigo : MonoBehaviour, IMuerte, IHacerDanio
{
    [SerializeField] private float velocidadEnemigo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool haciaDerecha;

    private float vida = 50f;

    private Rigidbody2D rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D infoSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);
        rb.velocity = new Vector2(velocidadEnemigo * Time.deltaTime, rb.velocity.y);

        if (infoSuelo == false)
        {
            Girar();
        }
    }

    private void Girar()
    {
        haciaDerecha = !haciaDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidadEnemigo *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
    }

    public void Die()
    {
        Debug.Log("Enemigo se murio.");
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        Debug.Log("Se muere pobrecito");
        vida -= amount;

        if (vida <= 0)
        {
            Die();
        }
    }
}
