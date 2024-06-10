using UnityEngine;
using Zenject;

public class TimerStarter : MonoBehaviour
{
    [SerializeField] private TimeDuration _durationUnit;

    private Timer _timer;

    [Inject]
    private void Construct(Timer timer) 
    {
        _timer = timer;
    }

    private void Start()
    {
        _timer.Start((int)_durationUnit.GetTotalSeconds(), 0);
    }
}
