using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum Direction
    {
        None = 5,
        Up = 8,
        Down = 2,
        Left = 4,
        Right = 6,
    }

    [SerializeField] private Transform _sensor;
    [SerializeField] private float _sensorSize = 0.7f;
    [SerializeField] private float _sensorRange = 0.4f;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private LayerMask _obstacleMask;
    
    private bool _left;
    private bool _right;
    private bool _up;
    private bool _down;
    private Direction _sensorDirectoin;
    private bool _canMove;
    

    private void Update()
    {
        GetInput();
        GetSensorDirection();
        HandleSensorePosition();
        Move();
    }

    private void Move()
    {
        if (_canMove == false) 
        {
            return;
        }

        switch (_sensorDirectoin)
        {
            case Direction.Up:
                transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y + _moveSpeed * Time.deltaTime);
                break;
            case Direction.Down:
                transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y - _moveSpeed * Time.deltaTime);
                break;
            case Direction.Left:
                transform.position = new Vector2(transform.position.x - _moveSpeed * Time.deltaTime, Mathf.Round(transform.position.y));
                break;
            case Direction.Right:
                transform.position = new Vector2(transform.position.x + _moveSpeed * Time.deltaTime, Mathf.Round(transform.position.y));
                break;
        }
    }

    private void HandleSensorePosition()
    {
        switch (_sensorDirectoin)
        {
            case Direction.None:
                _sensor.localPosition = new Vector2(0, 0);
                break;
            case Direction.Up:
                _sensor.localPosition = new Vector2(0, _sensorRange);
                break;
            case Direction.Down:
                _sensor.localPosition = new Vector2(0, -_sensorRange);
                break;
            case Direction.Left:
                _sensor.localPosition = new Vector2(-_sensorRange, 0);
                break;
            case Direction.Right:
                _sensor.localPosition = new Vector2(_sensorRange, 0);
                break;
        }

        _canMove = !Physics2D.OverlapBox(_sensor.position, new Vector2(_sensorSize, _sensorSize), 0, _obstacleMask);
    }

    private void GetSensorDirection()
    {
        _sensorDirectoin = Direction.None;
        if (_left) _sensorDirectoin = Direction.Left;
        if (_right) _sensorDirectoin = Direction.Right;
        if (_up) _sensorDirectoin = Direction.Up;
        if (_down) _sensorDirectoin = Direction.Down;
    }

    private void GetInput()
    {
        Vector2 movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        _left = movementDirection.x < 0 && movementDirection.y == 0;
        _right = movementDirection.x > 0 && movementDirection.y == 0;
        _up = movementDirection.x == 0 && movementDirection.y > 0;
        _down = movementDirection.x == 0 && movementDirection.y < 0;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(_sensor.position, new Vector2(_sensorSize, _sensorSize));
    }
}
