using UnityEngine;
using Model;

public class CannonShootingRouter : MonoBehaviour
{
    private const float _maxHoldingTime = 2f;
    private Cannon _model;

    [SerializeField] private DraggableObject _field;

    private void OnEnable()
    {
        _field.StartedTouching += Aim;
        _field.Dragged += Aim;
        _field.EndedTouching += Shoot;
    }

    private void OnDisable()
    {
        _field.StartedTouching -= Aim;
        _field.Dragged -= Aim;
        _field.EndedTouching -= Shoot;
    }

    public void Initialize(Cannon cannon)
    {
        _model = cannon;
    }

    private void Aim(Vector2 holdPosition)
    {
        float degToRadianConstant = 180f / Mathf.PI;
        float Angle = Mathf.Asin((holdPosition - _model.Position).normalized.y);
        _model.Rotate(Angle * degToRadianConstant);

    }

    private void Shoot(Vector2 position, float holdingTime)
    {
        if (holdingTime > _maxHoldingTime)
            holdingTime = _maxHoldingTime;

        _model.Shoot();
    }
}
