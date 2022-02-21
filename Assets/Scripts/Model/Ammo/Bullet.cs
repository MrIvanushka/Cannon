using System;
using UnityEngine;

namespace Model
{
    public abstract class Bullet : Transformable, IUpdatable
    {
        public readonly float GroungHeight;

        private const float _gravityAcceleration = -10f;
        private const float _wallHeight = 2f;

        private Vector2 _velocity;

        public abstract float ExplosionRange { get; }
        public abstract float Damage { get; }

        protected abstract float StartSpeed { get; }
        

        public event Action Exploded;

        public Bullet(Vector2 position, float rotation, float force) : base(position, rotation) 
        {
            GroungHeight = position.y - _wallHeight;
            Vector2 startDirection = Quaternion.Euler(0, 0, Rotation) * Vector3.right;
            _velocity = startDirection * StartSpeed * force;
        }

        public void Update(float deltaTime)
        {
            MoveTo(Position + _velocity * deltaTime + new Vector2(0, _gravityAcceleration * deltaTime * deltaTime / 2));
            _velocity += new Vector2(0, _gravityAcceleration * deltaTime);
            CheckGroundCollision();
        }

        private void CheckGroundCollision()
        {
            if(Position.y < GroungHeight)
                Exploded?.Invoke();
        }
    }
}