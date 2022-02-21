using UnityEngine;
using System;

namespace Model
{
    public abstract class Enemy : Transformable, IUpdatable
    {
        private Health _health;
        private EnemyStateMachine _stateMachine;
        private float _damage;
        private float _cooldown;

        private float _maxHealth;
        private float _velocity;

        public Health Health => _health;
        public float Velocity => _velocity;
        public float Damage => _damage;
        public float Cooldown => _cooldown;

        public event Action Attacking;

        public Enemy(Vector2 position, Castle target) : base(position, 0)
        {
            Initialize(out _maxHealth, out _damage, out _cooldown, out _velocity, out _stateMachine, target);
            _health = new Health(_maxHealth);
        }

        public void Update(float deltaTime)
        {
            _stateMachine.Update(deltaTime);
        }

        public void MoveForward(float deltaTime)
        {
            MoveTo(Position - new Vector2(_velocity * deltaTime, 0));
        }

        public void Attack()
        {
            Attacking?.Invoke();
        }

        protected abstract void Initialize(out float maxHealth, out float damage, out float cooldown, 
            out float velocity, out EnemyStateMachine stateMachine, Castle target);
    }
}
