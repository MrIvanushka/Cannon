using UnityEngine;
using Model;

public class CannonView : MonoBehaviour
{
    [SerializeField] private Transform _weapon;
    [SerializeField] private BulletFactory _bulletFactory;

    private Cannon _model;

    private void OnEnable()
    {
        _model.Moved += Move;
        _model.Rotated += Rotate;
        _model.Shooting += Shoot;
    }

    private void OnDisable()
    {
        _model.Moved -= Move;
        _model.Rotated -= Rotate;
        _model.Shooting -= Shoot;
    }

    public void Initialize(Cannon model)
    {
        _model = model;
        enabled = true;
    }

    private void Move()
    {
        transform.position = _model.Position;
    }

    private void Rotate()
    {
        _weapon.transform.rotation = Quaternion.Euler(0, 0, _model.Rotation);
    }

    private void Shoot(Bullet bullet)
    {
        _bulletFactory.CreateBullet(bullet);
    }
}
