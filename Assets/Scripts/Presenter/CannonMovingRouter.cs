using UnityEngine;
using Model;

public class CannonMovingRouter : MonoBehaviour
{
    [SerializeField] private DraggableObject _rails;

    private Cannon _model;

    public void Initialize(Cannon cannon)
    {
        _model = cannon;
    }

    private void OnEnable()
    {
        _rails.Dragged += Move;
    }

    private void OnDisable()
    {
        _rails.Dragged -= Move;
    }

    private void Move(Vector2 newPosition)
    {
        _model.Move(newPosition);
    }
}
