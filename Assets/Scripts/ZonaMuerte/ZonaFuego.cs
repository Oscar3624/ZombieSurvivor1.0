using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaFuego : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        IMuerte killable = collider.GetComponent<IMuerte>();
        if (killable != null)
        {
            killable.Die();
        }
    }
}
