using System;
using UnityEngine;

namespace Model
{
    public abstract class Bullet : Transformable, IUpdatable
    {
        private const float _gravityAcceleration = -10f;
        private const float _wallHeight = 20f;
        private readonly float _startPositionY;

        private Vector2 _velocity;
        
        protected abstract float StartSpeed { get; }

        public event Action Exploded;

        public Bullet(Vector2 position, float rotation, float force) : base(position, rotation) 
        {
            _startPositionY = position.y;
            Vector2 startDirection = Quaternion.Euler(0, 0, Rotation) * Vector3.up;
            _velocity = startDirection * StartSpeed * force;
        }

        public void Update(float deltaTime)
        {
            MoveTo(_velocity * deltaTime + new Vector2(0, _gravityAcceleration * deltaTime * deltaTime / 2));
            _velocity += new Vector2(0, _gravityAcceleration * deltaTime);
            CheckGroundCollision();
        }

        private void CheckGroundCollision()
        {
            if(_startPositionY - Position.y > _wallHeight)
                Exploded?.Invoke();
        }
    }
}