using UnityEngine;

namespace Model
{
    public class DefaultAmmunition : Ammunition
    {
        public DefaultAmmunition(int count) : base(count) { }

        public override Bullet Aim(Vector2 position, float rotation, float force)
        {
            return new DefaultBullet(position, rotation, force);
        }
    }
}