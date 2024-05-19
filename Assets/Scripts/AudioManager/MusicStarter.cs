using UnityEngine;
using Zenject;

public class MusicStarter : MonoBehaviour
{
    [SerializeField] private string _musicCategoryName;
    [SerializeField] private bool _loop = true;
    private AudioManager _manager;
    private AudioDB _audioDB;

    [Inject]
    private void Construct(AudioManager manager, AudioDB audioDB) 
    {
        _manager = manager;
        _audioDB = audioDB;
    }

    void Start()
    {
        var clip = _audioDB.GetClip(_musicCategoryName);

        if (clip == null) 
        {
            return;
        }

        _manager.PlayMusic(clip, _loop);
    }

}
