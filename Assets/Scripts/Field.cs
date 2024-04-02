using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private int _columnCount;
    [SerializeField] private int _rowCount;
    [SerializeField] private Transform[] _cells;

    public Transform GetClosestCell(Transform playerTransform) 
    {
        float diff = 0;
        float minDiff = float.MaxValue;
        int closestX = 0;
        var playerPos = playerTransform.position;
        var playerX = playerPos.x;

        for (int i = 0; i < _columnCount; i++) 
        {
            diff = _cells[i % _columnCount].position.x - playerX;

            diff = Mathf.Abs(diff);

            if ((diff) < minDiff)
            {
                minDiff = diff;
                closestX = i;
            }

            if (diff > minDiff) 
            {
                break;
            }
        }

        minDiff = float.MaxValue;
        int closestY = 0;
        var playerY = playerPos.y;

        int index = 0;

        for (int i = 0; i < _rowCount; i++)
        {
            index = i * _columnCount;
            diff = _cells[index].position.y - playerY;

            diff = Mathf.Abs(diff);

            if ((diff) < minDiff)
            {
                minDiff = diff;
                closestY = i;
            }

            if (diff > minDiff)
            {
                break;
            }
        }

        var N = (_columnCount * closestY) + closestX;

        return _cells[N];
    }
}
