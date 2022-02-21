using UnityEngine;
using Model;

public class SpawnerPresenter : MonoBehaviour
{
    [SerializeField] private EnemyPresenter _zombieTemplate;

    private Spawner _model;
    
    public void Initialize(Spawner spawner)
    {
        _model = spawner;
        enabled = true;
    }

    private void OnEnable()
    {
        _model.Spawned += SpawnEnemy;
    }

    private void OnDisable()
    {
        _model.Spawned -= SpawnEnemy;
    }

    private void Update()
    {
        _model.Update(Time.deltaTime);
    }

    private void SpawnEnemy(Enemy enemyModel)
    {
        Spawn((dynamic)enemyModel);
    }

    private void Spawn(Zombie enemyModel)
    {
        EnemyPresenter newEnemy = Instantiate(_zombieTemplate, enemyModel.Position, Quaternion.identity);
        newEnemy.Initialize(enemyModel);
    }
}
