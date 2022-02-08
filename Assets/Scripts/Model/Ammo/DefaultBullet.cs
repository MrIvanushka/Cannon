using UnityEngine;

namespace Model
{
    public class DefaultBullet : Bullet
    {
        private const float _startSpeed = 10f;

        protected override float StartSpeed => _startSpeed;

        public DefaultBullet(Vector2 position, float rotation, float force) : base(position, rotation, force) { }
    }
}
