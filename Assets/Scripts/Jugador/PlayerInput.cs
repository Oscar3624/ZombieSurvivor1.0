using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    public float GetHorizontalInput()
    {
        return Input.GetAxis("Horizontal");  // Devuelve la entrada horizontal (A/D, izquierda/derecha).
    }

    public bool GetJumpInput()
    {
        return Input.GetButtonDown("Jump"); // Detecta la entrada de salto en este caso es el espacio
    }

    public bool GetAttackInput()
    {
        return Input.GetButtonDown("Fire1");  // Detecta si se presiona el botonde ataque (por defecto Ctrl izquierdo).
    }

    public bool GetPressPause()
    {
        return Input.GetButtonDown("Cancel");
    }
}
