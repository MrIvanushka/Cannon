using System;
using UnityEngine;

namespace Model
{
    public abstract class Transformable : Movable
    {
        public float Rotation { get; private set; }
        public Vector2 Forward => Quaternion.Euler(0, 0, Rotation) * Vector3.up;

        public event Action Rotated;

        public Transformable(Vector2 position, float rotation) : base(position) 
        {
            Rotation = rotation;
        }

        public void Rotate(float newRotation)
        {
            Rotation = Mathf.Repeat(newRotation, 360);
            Rotated?.Invoke();
        }

    }
}
