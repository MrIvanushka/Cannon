using UnityEngine;
using Model;

public class CannonShooter : MonoBehaviour
{
    [SerializeField] private BulletFactory _bulletFactory;

    private Cannon _cannon;

    public void Initialize(Cannon cannon)
    {
        _cannon = cannon;
        enabled = true;
    }

    private void OnEnable()
    {
       _cannon.Shooting += Shoot;
    }

    private void OnDisable()
    {
      _cannon.Shooting -= Shoot;
    }

    private void Shoot(Bullet bullet)
    {
        _bulletFactory.CreateBullet(bullet);
    }
}
