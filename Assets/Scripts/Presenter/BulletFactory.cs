using UnityEngine;
using Model;

public class BulletFactory : MonoBehaviour
{
    [SerializeField] private BulletPresenter _template;

    public void CreateBullet(Bullet bullet)
    {
        CreateBullet((dynamic)bullet);
    }

    private void CreateBullet(DefaultBullet bullet)
    {
        InstantiateBullet(_template, bullet);
    }

    private void InstantiateBullet(BulletPresenter template, Bullet bullet)
    {
        BulletPresenter presenter = Instantiate(template, bullet.Position, Quaternion.Euler(0, 0, bullet.Rotation));
        presenter.Initialize(bullet);
    }
}
