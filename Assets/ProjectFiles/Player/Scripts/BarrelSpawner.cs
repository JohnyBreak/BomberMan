using GameState;
using UnityEngine;
using Zenject;

public class BarrelSpawner : MonoBehaviour
{
    [SerializeField] private Barrel _BurrelPrefab;
    private GameObjectFactory _factory;
    private PlayerStats _playerStats;
    private GameStateMachine _stateController;

    [Inject]
    private void Construct(
        PlayerStats playerStats,
        GameObjectFactory factory,
        GameStateMachine stateController)
    {
        _factory = factory;
        _playerStats = playerStats;
        _stateController = stateController;
    }

    void Update()
    {
        if (_stateController.IsCurrentState<GamePlayState>() == false) 
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (_playerStats.EnoughBomb() == false)
            {
                return;
            }

            var cellPosition = new Vector2(Mathf.Round(this.transform.position.x), Mathf.Round(this.transform.position.y));
            _factory.InstantiatePrefab(_BurrelPrefab, cellPosition, Quaternion.identity);
        }
    }
}
