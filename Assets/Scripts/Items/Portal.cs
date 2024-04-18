using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
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
            _gameState.WinGame();
        }
    }
}
