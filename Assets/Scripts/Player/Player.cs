using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController2D _characterController;
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private Animator _animator;
    [SerializeField] private Field _field;
    [SerializeField] private Barrel _BurrelPrefab;
    [SerializeField] private LayerMask _layerMask;

    private int _verticalHash = Animator.StringToHash("Vertical"); 
    private int _horizontalHash = Animator.StringToHash("Horizontal");
    private int _lastVerticalHash = Animator.StringToHash("LastVertical");
    private int _lastHorizontalHash = Animator.StringToHash("LastHorizontal");
    private int _speedHash = Animator.StringToHash("Speed");
    private int _deathHash = Animator.StringToHash("Death");

    private Vector2 _moveVector;

    private bool _alive = true;

    private Vector3 _movePosition;

    private float _cashedX;
    private float _cashedY;

    private void Awake()
    {
        _movePosition = transform.position;
    }

    public void Kill() 
    {
        _alive = false;
        _animator.SetTrigger(_deathHash);
    }

    private void Update()
    {
        if (_alive == false) 
        {
            return;
        }


        //transform.position = Vector3.MoveTowards(transform.position, _movePosition, _moveSpeed * Time.deltaTime);

        //var x = Input.GetAxisRaw("Horizontal");
        //var y = Input.GetAxisRaw("Vertical");
        

        //if (Vector3.Distance(transform.position, _movePosition) <= 0.05f)
        //{
        //    _animator.SetFloat(_lastHorizontalHash, _cashedX);
        //    _animator.SetFloat(_lastVerticalHash, _cashedY);

        //    _animator.SetFloat(_speedHash, 0);

        //    //_cashedX = 0;
        //    //_cashedY = 0;

        //    if (x != 0)
        //    {
        //        if (!Physics2D.OverlapCircle(_movePosition + new Vector3(x, 0, 0), 0.2f, _layerMask))
        //        {
        //            _movePosition += new Vector3(x, 0, 0);
        //        }
        //    }
        //    else if (y != 0)
        //    {
        //        if (!Physics2D.OverlapCircle(_movePosition + new Vector3(0, y, 0), 0.2f, _layerMask))
        //        {
        //            _movePosition += new Vector3(0, y, 0);
        //        }
        //    }
        //}
        //else 
        //{
        //    _cashedX = x;
        //    _cashedY = y;

        //    _animator.SetFloat(_horizontalHash, _cashedX);
        //    _animator.SetFloat(_verticalHash, _cashedY);

        //    _animator.SetFloat(_speedHash, 1);
        //}



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
