using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController2D _characterController;
    
    [SerializeField] private Animator _animator;
    [SerializeField] private LayerMask _layerMask;

    private int _verticalHash = Animator.StringToHash("Vertical"); 
    private int _horizontalHash = Animator.StringToHash("Horizontal");
    private int _lastVerticalHash = Animator.StringToHash("LastVertical");
    private int _lastHorizontalHash = Animator.StringToHash("LastHorizontal");
    private int _speedHash = Animator.StringToHash("Speed");
    private int _deathHash = Animator.StringToHash("Death");

    private Vector2 _moveVector;
    //private float _moveSpeed = 2f;
    private PlayerStats _stats;
    private GameStateController _gameStateController;

    [Inject]
    private void Construct(PlayerStats stats, GameStateController stateController) 
    {
        _stats = stats;
        _gameStateController = stateController;
    }

    private Vector3 _movePosition;

    private float _cashedX;
    private float _cashedY;

    private void Awake()
    {
        _movePosition = transform.position;
    }

    public void Kill() 
    {
        _gameStateController.SetState(LoseState.Name);
        //_alive = false;
        _animator.SetTrigger(_deathHash);
    }

    private void Update()
    {
        if (_gameStateController.IsCurrentState(GamePlayState.Name) == false) 
        {
            return;
        }
        
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        _moveVector = new Vector2(x, y).normalized * _stats.PlayerMoveSpeed;

        _animator.SetFloat(_horizontalHash, x);
        _animator.SetFloat(_verticalHash, y);

        var magnitude = _moveVector.magnitude;
        _animator.SetFloat(_speedHash, magnitude);

        if (magnitude > 0.1f) 
        {
            _animator.SetFloat(_lastHorizontalHash, x);
            _animator.SetFloat(_lastVerticalHash, y);
        }

        _characterController.Move(_moveVector);
    }
}
