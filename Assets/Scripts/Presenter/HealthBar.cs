using UnityEngine;
using UnityEngine.UI;
using Model;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider _slider;
    private IHealth _model;

    public void Initialize(IHealth model)
    {
        _model = model;
        enabled = true;
    }

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _model.GotHit += RenderHealth;
        _model.Dying += Destroy;
    }

    private void OnDisable()
    {
        _model.GotHit -= RenderHealth;
        _model.Dying -= Destroy;
    }

    private void RenderHealth()
    {
        _slider.value = _model.CurrentHealth / _model.MaxHealth;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
