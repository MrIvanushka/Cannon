using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class Cannon : Transformable
    {
        private const float _maxPositionY = 4f;
        private const float _minPositionY = -4f;

        private Queue<Ammunition> _arsenal;

        public event Action<Bullet> Shooting;

        public Cannon(Vector2 position, float rotation) : base(position, rotation) 
        {
            _arsenal = new Queue<Ammunition>();
            _arsenal.Enqueue(new DefaultAmmunition(int.MaxValue));
        }

        public void SwitchAmmunition()
        {
            do
            {
                var switchingAmmunition = _arsenal.Dequeue();
                _arsenal.Enqueue(switchingAmmunition);
            }
            while (_arsenal.Peek().BulletCount < 1);
        }

        public void Move(Vector2 newPosition)
        {
            newPosition.x = Position.x;
            newPosition.y = Mathf.Clamp(newPosition.y, _minPositionY, _maxPositionY);
            MoveTo(newPosition);
        }

        public void Shoot(float force)
        {
            Ammunition currentAmmunition = _arsenal.Peek();
            Shooting?.Invoke(currentAmmunition.Aim(Position, Rotation, force));
            Debug.Log("Shooting");
        }
    }
}
