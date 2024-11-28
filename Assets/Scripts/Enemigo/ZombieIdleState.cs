using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ZombieIdleState : IZombieState
{
    private Zombie zombie;    
    
    //private float distancia = 3f;
    //private bool haciaDerecha;

    //Constructor
    public ZombieIdleState (Zombie zombie)
    {
        this.zombie = zombie;
    }

    public void EnterState()
    {
        //Inicializar animaciones
        zombie.animator.SetBool("Running", false);

    }

    public void HandleInput()
    {
        if (zombie.IsPlayerInRange(zombie.DetectionRange))
        {
            zombie.SetState(new ZombiePersecutionState(zombie));
        }
    }

    public void UpdateState()
    {
        Vector3 direction = zombie.Player.transform.position - zombie.transform.position;

        if (direction.x >= 0.0f)
        {
            zombie.transform.localScale = new Vector3(0.54f, 0.54f, 0f);
        }
        else
        {
            zombie.transform.localScale = new Vector3(-0.54f, 0.54f, 0f);
        }

    }


    //Para que el zombie patrulle entre dos puntos
    /*zombie.MoverHaciaPuntoDePatrullaje();        

        //SI el zombie llego a al punto de patrullaje cambia a otro punto
        if ((Vector2.Distance(zombie.transform.position, zombie.CurrentPatrolTarget.position) < 0.7f))
        {
            zombie.SwitchPatrolTarget();
        }*/

}
