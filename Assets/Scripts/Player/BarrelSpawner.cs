using UnityEngine;
using Zenject;

public class BarrelSpawner : MonoBehaviour
{
    [SerializeField] private Barrel _BurrelPrefab;
    private GameObjectFactory _factory;
    private Field _field;
    private Player _player;

    [Inject]
    private void Construct(Player player, GameObjectFactory factory, Field field)
    {
        _field = field;
        _factory = factory;
        _player = player;
    }

    void Update()
    {
        if (_player.Alive == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var cellTransform = _field.GetClosestCell(this.transform);
            _factory.InstantiatePrefab(_BurrelPrefab, cellTransform.position, Quaternion.identity);
        }
    }
}
