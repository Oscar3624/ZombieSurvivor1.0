using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioEnemigo : MonoBehaviour
{
    [SerializeField] private float damageAmount = 5f;
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        //El jugador implementa la interfaz IHacerDanio
        IHacerDanio damageable = collision.gameObject.GetComponent<IHacerDanio>();
        if (damageable != null)
        {
            Debug.Log("Colisionando con player......");

            damageable.TakeDamage(damageAmount * Time.deltaTime);
        }
    }
}
