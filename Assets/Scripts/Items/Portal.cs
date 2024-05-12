using UnityEngine;
using Zenject;

public class Portal : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private GameStateController _stateController;

    [Inject]
    private void Construct(GameStateController stateController)
    {
        _stateController = stateController;
        Disable();
    }

    public void Disable()
    {
        _collider.enabled = false;
        _spriteRenderer.enabled = false;
    }

    public void Enable() 
    {
        _spriteRenderer.enabled = true;
        _collider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player)) 
        {
            _collider.enabled = false;

            _stateController.SetState(WinState.Name);
        }
    }
}
