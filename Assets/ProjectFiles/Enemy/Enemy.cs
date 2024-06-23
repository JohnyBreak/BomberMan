using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private uint _walkDistance = 1;
    [SerializeField] private float _moveSpeed = 3;
    [SerializeField] private LayerMask _obstacleMask;

    private float _checkRadius = .8f;
    private List<Vector3> _gizmoPositions = new List<Vector3>();

    private Coroutine _moveRoutine;
    

    private void Start()
    {
        StartCoroutine(CheckNewDirection());
    }

    private void PeekDirection()
    {
        int index = UnityEngine.Random.Range(0, _gizmoPositions.Count);

        StartMoveToPosition(_gizmoPositions[index]);
    }

    private void StartMoveToPosition(Vector3 position) 
    {
        StopMoveRoutine();

        _moveRoutine = StartCoroutine(MoveRoutine(position));
    }

    private IEnumerator MoveRoutine(Vector3 position) 
    {
        Vector3 moveVector = position - transform.position;

        while ((transform.position - position).magnitude > 0.1f) 
        {
            transform.position += moveVector * Time.deltaTime * _moveSpeed;

            yield return null;
        }

        transform.position = position;

        StartCoroutine(CheckNewDirection());
    }

    private IEnumerator CheckNewDirection() 
    {
        _gizmoPositions.Clear();

        CheckDirections(Vector3.up);
        CheckDirections(Vector3.right);
        CheckDirections(Vector3.down);
        CheckDirections(Vector3.left);

        yield return new WaitForSeconds(1);

        PeekDirection();
    }

    private void StopMoveRoutine() 
    {
        if (_moveRoutine != null) 
        {
            StopCoroutine(_moveRoutine);
            _moveRoutine = null;
        }
    }

    private void CheckDirections(Vector3 direction)
    {
        for (int i = 0; i < _walkDistance; i++)
        {
            var rayDir = transform.position + direction * (i + 1);
            var obstacleResult = Physics2D.OverlapBox(rayDir, Vector2.one * _checkRadius, 0, _obstacleMask);

            if (obstacleResult != null)
            {
                break;
            }

            _gizmoPositions.Add(GetRoundedPosition() + direction);

        }
    }

    private Vector3 GetRoundedPosition() 
    {
        return new Vector3(Mathf.Round(this.transform.position.x), Mathf.Round(this.transform.position.y), 0);
    }

    private void OnDrawGizmos()
    {
        foreach (var position in _gizmoPositions)
        {
            Gizmos.DrawWireSphere(position, 0.45f);
        }
    }
}
