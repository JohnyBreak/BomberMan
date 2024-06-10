using TMPro;
using UnityEngine;
using Zenject;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    private Timer _timer;

    [Inject] 
    private void Construct(Timer timer) 
    {
        _timer = timer;
        _timer.TickEvent += OnTick;
    }

    private void OnTick(int value) 
    {
        int minutes = value / 60;
        int seconds = value % 60;
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnDestroy() 
    {
        _timer.TickEvent -= OnTick;
    }
}
