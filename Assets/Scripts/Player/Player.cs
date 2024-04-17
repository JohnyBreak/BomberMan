using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController2D _characterController;
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private Animator _animator;
    [SerializeField] private Field _field;
    [SerializeField] private Barrel _BurrelPrefab;

    private int _verticalHash = Animator.StringToHash("Vertical"); 
    private int _horizontalHash = Animator.StringToHash("Horizontal");
    private int _lastVerticalHash = Animator.StringToHash("LastVertical");
    private int _lastHorizontalHash = Animator.StringToHash("LastHorizontal");
    private int _speedHash = Animator.StringToHash("Speed");
    private Vector2 _moveVector;

    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        _moveVector = new Vector2(x, y).normalized * _moveSpeed;

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

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            var cellTransform = _field.GetClosestCell(this.transform);
            var barrel = Instantiate(_BurrelPrefab, cellTransform.position, Quaternion.identity);
            barrel.Init(_field);
        }
    }
}
