using UnityEngine;

namespace Model
{
    public class Spawner : IUpdatable
    {
        private readonly float _spawnLineCoord;
        private readonly float _minSpawnPointY;
        private readonly float _maxSpawnPointY;

        private const float _cooldownMultiplier = 0.95f;
        private const float _criticalSpawningCooldown = 0.1f;

        private Castle _castle;
        private float _spawningCooldown;
        private float _currentTime;

        public event System.Action<Enemy> Spawned;

        public Spawner(Castle castle, float spawnLineCoord, float minSpawnPointY, float maxSpawnPointY, float startSpawningCooldown)
        {
            _castle = castle;
            _spawnLineCoord = spawnLineCoord;
            _minSpawnPointY = minSpawnPointY;
            _maxSpawnPointY = maxSpawnPointY;
            _spawningCooldown = startSpawningCooldown;
            _currentTime = 0;
        }

        public void Update(float deltaTime)
        {
            _currentTime += deltaTime;

            if(_currentTime > _spawningCooldown)
            {
                _currentTime -= _spawningCooldown;

                if (_spawningCooldown > _criticalSpawningCooldown)
                    _spawningCooldown *= _cooldownMultiplier;

                SpawnZombie(new Vector2(_spawnLineCoord, Random.Range(_minSpawnPointY, _maxSpawnPointY)));
            }
        }

        private void SpawnZombie(Vector2 spawnPoint)
        {
            var enemy = new Zombie(spawnPoint, _castle);
            Spawned?.Invoke(enemy);
        }
    }
}