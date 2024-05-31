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

        if (Input.GetButtonDown("Jump"))
        {
            if (_playerStats.EnoughBomb() == false)
            {
                return;
            }

            var cellPosition = new Vector2(Mathf.Round(this.transform.position.x), Mathf.Round(this.transform.position.y));//_field.GetClosestCellPosition(this.transform.position);
            _factory.InstantiatePrefab(_BurrelPrefab, cellPosition, Quaternion.identity);
        }
    }
}
