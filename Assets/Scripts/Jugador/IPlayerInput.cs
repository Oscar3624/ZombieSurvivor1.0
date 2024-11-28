using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInput
{
    float GetHorizontalInput();
    bool GetJumpInput();
    bool GetAttackInput();   // Devuelve si el jugador presiona el boton de mouse para disparar
    bool GetPressPause(); //Detecta si el jugador presiona la tecla de escape para pausa

}
