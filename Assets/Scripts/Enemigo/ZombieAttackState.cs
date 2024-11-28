using UnityEngine;

public class ZombieAttackState : IZombieState
{
    private Zombie zombie;

    public ZombieAttackState(Zombie zombie)
    {
        this.zombie = zombie;
    }

    public void EnterState()
    {
        // Aqui animacion de ataque
        zombie.animator.SetBool("Attacking", true);

        AudioManager.Instance.PlaySound(zombie.attackZombie);
    }

    public void HandleInput()
    {
        //Logica para que zombie deje de atacar
    }

    public void UpdateState()
    {
        if (zombie.IsPlayerInRangeAttack(zombie.AttackRange)) 
        {
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
        else
        {
            zombie.SetState(new ZombiePersecutionState(zombie)); //perseguir nuevamente si se aleja
        }

    }
}
