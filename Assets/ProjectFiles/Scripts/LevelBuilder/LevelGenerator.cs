using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform m_SpawnParent;
    [SerializeField] private List<KeyAssetPair> m_Pairs;

    private Dictionary<char, GameObject> m_AssetDict = new();
    private GameObjectFactory _factory;
    

    //private readonly char[,] m_Level = new char[,]
    //{
    //    { '0', '0', '0', '1', '0', '0', '0' },
    //    { '1', '2', '0', '2', '1', '2', '0' },
    //    { '0', '1', '0', '0', '0', '0', '0' },
    //    { '1', '2', '1', '2', '0', '2', '0' },
    //    { '0', '1', '0', '1', '0', '1', '0' },
    //    { '0', '2', '0', '2', '1', '2', '0' },
    //    { '0', '1', '0', '0', '0', '1', '0' },
    //};

    private readonly char[,] m_Level = new char[,]
    {
        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' , ' '},
        { ' ', '@', '0', '0', '1', '0', ' ', ' ', '1', 'T', '0', '1' , ' '},
        { ' ', '1', '2', '0', '2', '1', ' ', ' ', '2', '1', '2', '0' , ' '},
        { ' ', '0', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0' , ' '},
        { ' ', '1', '2', '1', '2', '0', ' ', '0', '2', '0', '2', '0' , ' '},
        { ' ', '0', '1', '0', '1', '0', ' ', ' ', '1', '0', '1', '0' , ' '},
        { ' ', '0', '2', '0', '2', '1', ' ', ' ', '2', '1', '2', '0' , ' '},
        { ' ', '0', '1', '0', 'T', '0', ' ', ' ', 'P', '0', '1', '0' , ' '},
        { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' , ' '},
    };

    [Inject]
    private void Construct(GameObjectFactory factory)
    {
        _factory = factory;
    }

    public void Init()
    {
        FillDictionary();
        GenerateLevel();
    }

    private void GenerateLevel()
    {

        for (var y = 0; y < m_Level.GetLength(0); y++)
        {
            for (var x = 0; x < m_Level.GetLength(1); x++)
            {
                char key = m_Level[y, x];

                Vector2 currentPosition = new Vector2(x, -y);

                if (key != ' ' && key != '0')
                {
                    CreateTile('0', currentPosition);
                }

                CreateTile(key, currentPosition);
            }
        }
    }

    private void CreateTile(char key, Vector2 position) 
    {
        if (m_AssetDict.TryGetValue(key, out var asset))
        {
            var tile = _factory.InstantiatePrefab(asset, m_SpawnParent);
            tile.transform.position = position;
        }
    }

    private void FillDictionary()
    {
        foreach (var pair in m_Pairs)
        {
            m_AssetDict.Add(pair.Key, pair.Asset);
        }
    }
}

[Serializable]
public class KeyAssetPair
{
    [SerializeField] private char m_Key;
    [SerializeField] private GameObject m_Asset;

    public char Key => m_Key;
    public GameObject Asset => m_Asset;
}