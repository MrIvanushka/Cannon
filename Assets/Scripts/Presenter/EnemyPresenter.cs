using System.Collections;
using UnityEngine;
using Model;

[RequireComponent(typeof(Animator))]
public class EnemyPresenter : MonoBehaviour
{
    private const float _dyingDuration = 2f;

    [SerializeField] private string _movingAnimationClip;
    [SerializeField] private string _attackAnimationClip;
    [SerializeField] private string _dyingAnimationClip;
    [SerializeField] private HealthBar _healthBar;

    private Enemy _model;
    private Animator _animator;
    private float _previousPositionX;

    public void Initialize(Enemy model)
    {
        _model = model;
        _healthBar.Initialize(model.Health);
        enabled = true;
    }

    private void OnEnable()
    {
        _model.Attacking += Attack;
        _model.Moved += Move;
        _model.Health.Dying += Die;
    }

    private void OnDisable()
    {
        _model.Attacking -= Attack;
        _model.Moved -= Move;
        _model.Health.Dying -= Die;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _previousPositionX = transform.position.x;
    }

    private void Update()
    {
        _model.Update(Time.deltaTime);

        float velocity = (_previousPositionX - transform.position.x) / Time.deltaTime;
        _previousPositionX = transform.position.x;

        _animator.SetFloat(_movingAnimationClip, velocity / _model.Velocity);
    }

    public void TakeDamage(float damage)
    {
        if(_model.Health.CurrentHealth > 0)
            _model.Health.TakeDamage(damage);
    }

    private void Move()
    {
        transform.position = _model.Position;
    }

    private void Attack()
    {
        _animator.SetTrigger(_attackAnimationClip);
    }

    private void Die()
    {
        _animator.SetTrigger(_dyingAnimationClip);
        StartCoroutine(Destroy());
        enabled = false;
    }

    private IEnumerator Destroy()
    {
        var delay = new WaitForSeconds(_dyingDuration);
        yield return delay;
        Destroy(this.gameObject);
    }
}
