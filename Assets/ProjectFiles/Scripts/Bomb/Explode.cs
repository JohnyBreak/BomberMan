using GameState;
using System.Collections;
using UnityEngine;
using Zenject;

public class Explode : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3;
    [SerializeField]  private LayerMask _mask;

    private WaitForSeconds _sleepTime;
    private GameStateMachine _gameStateMachine;

    [Inject]
    private void Construct(
        GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    private void Start()
    {
        _sleepTime = new WaitForSeconds(0.2f);

        StartCoroutine(WaitRoutine());
        StartCoroutine(DamageRoutine());

        var result = Physics2D.OverlapBox(transform.position, Vector2.one * 0.9f, 0, _mask);

        if (result == null) 
        {
            return;
        }

        if (result.TryGetComponent(out IExplodable explodable)) 
        {
            explodable.Explode();
        }
    }

    private IEnumerator DamageRoutine() 
    {
        while (true)
        {
            if (_gameStateMachine.IsCurrentState<GamePlayState>() == false)
            {
                yield return null;
                continue;
            }

            yield return _sleepTime;

            var result = Physics2D.OverlapBox(transform.position, Vector2.one * 0.9f, 0, _mask);

            if (result == null)
            {
                continue;
            }

            if (result.TryGetComponent(out IExplodable explodable))
            {
                explodable.Explode();
            }
        }
    }

    private IEnumerator WaitRoutine()
    {
        //yield return new WaitForSeconds(_lifeTime);
        
        float time = 0;
        while (time < _lifeTime)
        {
            if (_gameStateMachine.IsCurrentState<GamePlayState>() == false)
            {
                yield return null;
                continue;
            }

            time += Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
    }
}
