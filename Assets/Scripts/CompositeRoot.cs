using UnityEngine;
using Model;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private CannonShootingRouter _cannonShooting;
    [SerializeField] private CannonMovingRouter _cannonMoving;
    [SerializeField] private CannonView _cannonView;
    [SerializeField] private SpawnerPresenter _spawner;
    [SerializeField] private Transform _castleFrontPoint;

    private void Awake()
    {
        Castle castle = new Castle(100, _castleFrontPoint.position.x);

        Cannon cannon = new Cannon(_cannonView.transform.position, 0);
        _cannonShooting.Initialize(cannon);
        _cannonView.Initialize(cannon);
        _cannonMoving.Initialize(cannon);

        _spawner.Initialize(new Spawner(castle, _spawner.transform.position.x, -4, 2.5f, 2f));
    }
}
