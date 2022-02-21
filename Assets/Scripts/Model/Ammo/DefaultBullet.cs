using UnityEngine;

namespace Model
{
    public class DefaultBullet : Bullet
    {
        public override float ExplosionRange { get; } = 20f;
        public override float Damage { get; } = 30f;

        protected override float StartSpeed { get; } = 10f;

        public DefaultBullet(Vector2 position, float rotation, float force) : base(position, rotation, force) { }
    }
}
