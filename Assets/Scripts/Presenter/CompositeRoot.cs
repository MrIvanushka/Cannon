using UnityEngine;
using Model;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private CannonShootingRouter _cannonShooting;
    [SerializeField] private CannonMovingRouter _cannonMoving;
    [SerializeField] private CannonView _cannonView;

    private void Awake()
    {
        Cannon cannon = new Cannon(_cannonShooting.transform.position, 0);
        _cannonShooting.Initialize(cannon);
        _cannonView.Initialize(cannon);
        _cannonMoving.Initialize(cannon);
        _cannonShooting.enabled = true;
        _cannonMoving.enabled = true;
        _cannonView.enabled = true;
    }
}
