using System;

namespace Model
{
    public interface IHealth
    {
        public float MaxHealth { get; }
        public float CurrentHealth { get; }

        public event Action GotHit;
        public event Action Dying;
    }

    public class Health : IHealth
    {
        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }

        public event Action GotHit;
        public event Action Dying;

        public Health(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException();
            else if (CurrentHealth <= 0)
                throw new InvalidOperationException();

            CurrentHealth -= damage;
            GotHit?.Invoke();

            if (CurrentHealth <= 0)
                Dying?.Invoke();
        }
    }
}
