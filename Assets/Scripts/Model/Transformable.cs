using System;
using UnityEngine;

namespace Model
{
    public interface IPoint
    {
        Vector2 Position { get; }
        float Rotation { get; }

        Vector2 Forward { get; }
    }

    public abstract class Transformable : IPoint
    {
        public float Rotation { get; private set; }
        public Vector2 Position { get; private set; }

        public Vector2 Forward => Quaternion.Euler(0, 0, Rotation) * Vector3.up;

        public event Action Rotated;
        public event Action Moved;
        
        public Transformable(Vector2 position, float rotation)
        {
            Rotation = rotation;
            Position = position;
        }

        public void Rotate(float newRotation)
        {
            Rotation = Mathf.Repeat(newRotation, 360);
            Rotated?.Invoke();
        }

        public void MoveTo(Vector2 position)
        {
            Position = position;
            Moved?.Invoke();
        }
    }
}
