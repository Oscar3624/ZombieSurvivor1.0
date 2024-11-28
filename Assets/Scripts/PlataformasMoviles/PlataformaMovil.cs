using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlataformaMovil : MonoBehaviour, IPlataformaMovil
{
    protected bool isMoving = true;

    private void Update()
    {
        if (isMoving)
        {
            Move();
        }
    }

    public abstract void Move();

}
