using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

public class BulletPresenter : MonoBehaviour
{
    [SerializeField] private Transform _shadow;

    private Bullet _model;

    private void OnEnable()
    {
        _model.Exploded += Explode;
        _model.Moved += Move;
        _model.Rotated += Rotate;
        enabled = true;
    }

    private void OnDisable()
    {
        _model.Exploded -= Explode;
        _model.Moved -= Move;
        _model.Rotated -= Rotate;
    }

    public void Initialize(Bullet bullet)
    {
        _model = bullet;
        _shadow.rotation = Quaternion.identity;
        enabled = true;
    }

    private void Update()
    {
        _model.Update(Time.deltaTime);
    }

    private void Move()
    {
        transform.position = _model.Position;
        _shadow.position = new Vector2(_model.Position.x, _model.GroungHeight);
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _model.Rotation);
    }

    private void Explode()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(_model.Position, _model.ExplosionRange);

        foreach(var hitObject in hitObjects)
        {
            if(hitObject.TryGetComponent(out EnemyPresenter enemy))
            {
                enemy.TakeDamage(_model.Damage);
            }
        }

        Destroy(this.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, _model.ExplosionRange);
    }
}
