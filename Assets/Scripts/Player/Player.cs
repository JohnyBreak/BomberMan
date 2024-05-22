using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController2D _characterController;

    [SerializeField] private Animator _animator;

    private int _verticalHash = Animator.StringToHash("Vertical");
    private int _horizontalHash = Animator.StringToHash("Horizontal");
    private int _lastVerticalHash = Animator.StringToHash("LastVertical");
    private int _lastHorizontalHash = Animator.StringToHash("LastHorizontal");
    private int _speedHash = Animator.StringToHash("Speed");
    private int _deathHash = Animator.StringToHash("Death");

    private Vector2 _inputVector;
    private Vector2 _moveVector;
    private PlayerStats _stats;
    private GameStateController _gameStateController;

    [Inject]
    private void Construct(PlayerStats stats, GameStateController stateController)
    {
        _stats = stats;
        _gameStateController = stateController;
    }

    public void Kill()
    {
        _gameStateController.SetState(LoseState.Name);
        _animator.SetTrigger(_deathHash);
    }

    private void Update()
    {
        if (_gameStateController.IsCurrentState(GamePlayState.Name) == false)
        {
            return;
        }

        GetInput();

        HandleAnimations();

        Move();
    }

    private void GetInput()
    {
        _inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveVector = _inputVector.normalized * _stats.PlayerMoveSpeed;
    }

    private void HandleAnimations() 
    {
        _animator.SetFloat(_horizontalHash, _inputVector.x);
        _animator.SetFloat(_verticalHash, _inputVector.y);

        var magnitude = _moveVector.magnitude;
        _animator.SetFloat(_speedHash, magnitude);

        if (magnitude > 0.1f)
        {
            _animator.SetFloat(_lastHorizontalHash, _inputVector.x);
            _animator.SetFloat(_lastVerticalHash, _inputVector.y);
        }
    }

    private void Move()
    {
        _characterController.Move(_moveVector);
    }
}
