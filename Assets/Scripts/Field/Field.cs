using System.Collections.Generic;
using UnityEngine;

public class Field
{
    private int _columnCount;
    private int _rowCount;
    private List<Cell> _cells = new List<Cell>();

    public void SetLevelSize(int columnCount, int rowCount) 
    {
        _columnCount = columnCount;
        _rowCount = rowCount;
    }

    public void AddCell(Cell cell) 
    {
        _cells.Add(cell);
    }

    public Vector2 GetClosestCellPosition(Vector2 playerTransform) 
    {
        float diff = 0;
        float minDiff = float.MaxValue;
        int closestX = 0;
        var playerPos = playerTransform;
        var playerX = playerPos.x;

        for (int i = 0; i < _columnCount; i++) 
        {
            if (_cells[i % _columnCount] == null)
            {
                continue;
            }

            if (_cells[i % _columnCount].Occupied) 
            {
                continue;
            }

            diff = _cells[i % _columnCount].X - playerX;

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

            if (_cells[index] == null)
            {
                continue;
            }

            if (_cells[index].Occupied)
            {
                continue;
            }

            diff = _cells[index].Y - playerY;

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

        return new Vector2(_cells[N].X, _cells[N].Y);
    }
}
