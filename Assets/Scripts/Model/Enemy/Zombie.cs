using UnityEngine;

namespace Model
{
    public class Zombie : Enemy
    {
        public Zombie(Vector2 position, Castle target) : base(position, target)
        { }

        protected override void Initialize(out float maxHealth, out float damage, out float cooldown, out float velocity,
            out EnemyStateMachine stateMachine, Castle target)
        {
            maxHealth = 100;
            damage = 10;
            cooldown = 2;
            velocity = 3;
            stateMachine = new EnemyStateMachine(
                new MovingState(this, new DistanceTransition(this, target.FrontLine,
                new AttackState(this, new TargetAliveTransition(target.Health,
                new CelebratingState())))));
        }
    }
}
