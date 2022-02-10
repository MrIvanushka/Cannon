using UnityEngine;
using Model;

public class CannonView : MonoBehaviour
{
    [SerializeField] private Transform _weapon;

    private Cannon _model;

    private void OnEnable()
    {
        _model.Moved += Move;
        _model.Rotated += Rotate;
    }

    private void OnDisable()
    {
        _model.Moved -= Move;
        _model.Rotated -= Rotate;
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
}
