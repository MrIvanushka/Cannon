using System;
using UnityEngine;

namespace Model
{
    public abstract class Movable
    {
        public Vector2 Position { get; private set; }

        public event Action Moved;
        public event Action Destroying;

        public Movable(Vector2 position) => Position = position;

        public void MoveTo(Vector2 position)
        {
            Position = position;
            Moved?.Invoke();
        }

        public void Destroy()
        {
            Destroying?.Invoke();
        }
    }
}
