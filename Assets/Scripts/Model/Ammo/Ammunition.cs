using System.Collections;
using System;
using UnityEngine;

namespace Model
{
    public abstract class Ammunition
    {
        public int BulletCount { get; private set; }

        public Ammunition(int count)
        {
            BulletCount = count;
        }

        public abstract Bullet Aim(Vector2 position, float rotation, float force);
    }
}
