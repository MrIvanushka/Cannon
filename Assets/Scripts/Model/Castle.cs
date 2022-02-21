using System;

namespace Model
{
    public class Castle
    {
        private Health _health;
        
        public float FrontLine { get; }
        public IHealth Health => _health;

        public event Action GameOver;

        public Castle(float maxHealth, float frontline)
        {
            FrontLine = frontline;
            _health = new Health(maxHealth);
            _health.Dying += ConcedeDefeat;
        }

        ~Castle()
        {
            _health.Dying -= ConcedeDefeat;
        }

        private void ConcedeDefeat()
        {
            GameOver?.Invoke();
        }
    }
}
