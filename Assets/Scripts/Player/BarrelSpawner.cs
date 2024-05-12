using UnityEngine;
using Zenject;

public class BarrelSpawner : MonoBehaviour
{
    [SerializeField] private Barrel _BurrelPrefab;
    private GameObjectFactory _factory;
    private Field _field;
    private PlayerStats _playerStats;
    private GameStateController _stateController;

    [Inject]
    private void Construct(
        PlayerStats playerStats,
        GameObjectFactory factory,
        Field field, 
        GameStateController stateController)
    {
        _field = field;
        _factory = factory;
        _playerStats = playerStats;
        _stateController = stateController;
    }

    void Update()
    {
        if (_stateController.IsCurrentState(GamePlayState.Name) == false) 
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_playerStats.EnoughBomb() == false)
            {
                return;
            }

            var cellTransform = _field.GetClosestCell(this.transform);
            _factory.InstantiatePrefab(_BurrelPrefab, cellTransform.position, Quaternion.identity);
        }
    }
}
