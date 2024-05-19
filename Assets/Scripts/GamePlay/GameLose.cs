using UnityEngine;
using Zenject;

public class GameLose : MonoBehaviour
{
    [SerializeField] private string _loseClipName;
    private AudioManager _manager;
    private bool _activated = false;
    private AudioDB _audioDB;

    [Inject]
    private void Construct(AudioManager manager, AudioDB audioDB)
    {
        _manager = manager;
        _audioDB = audioDB;
    }

    public void Activate() 
    {
        if (_activated)
        {
            return;
        }

        _manager.StopAllSounds();
        _manager.PlayOneShot(_audioDB.GetClip(_loseClipName));

        _activated = true;
    }
}
