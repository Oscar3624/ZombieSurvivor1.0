using UnityEngine;

public class ZombiePersecutionState : IZombieState
{
    private Zombie zombie;
    

    //Constructor
    public ZombiePersecutionState(Zombie zombie)
    {
        this.zombie = zombie;
    }

    public void EnterState()
    {
        //Iniciar animacion de correr
        zombie.animator.SetBool("Running", true);
        zombie.animator.SetBool("Attacking", false);
    }

    public void HandleInput()
    {
        if (zombie.IsPlayerInRangeAttack(zombie.AttackRange))
        {
            zombie.SetState(new ZombieAttackState(zombie));

        }
        else if (!zombie.IsPlayerInRange(zombie.DetectionRange))
        {
            zombie.SetState(new ZombieIdleState(zombie));   
        }

    }
    public void UpdateState()
    {
        //Debug.Log("Ingresa a persecucion.");
        
        Vector2 direction = zombie.Player.position - zombie.transform.position;

        if (direction.x > 0.0f)
        {
            zombie.rb.velocity = new Vector2(zombie.SpeedZombie * Time.deltaTime, zombie.rb.velocity.y);

        }
        else if (direction.x < 0.0f)
        {
            zombie.rb.velocity = new Vector2(-zombie.SpeedZombie * Time.deltaTime, zombie.rb.velocity.y);
        }
    }





    /*public void UpdateState()
    {
        Debug.Log("Ingresa a esta de persecucion...");
        //Mover zombie hacia el jugador
        Vector2 direction = (zombie.Player.position - zombie.transform.position).normalized;

        //
        Debug.Log(direction * zombie.MoveSpeed * Time.deltaTime);

        zombie.transform.Translate(direction * zombie.MoveSpeed * Time.deltaTime);
    }*/
}
