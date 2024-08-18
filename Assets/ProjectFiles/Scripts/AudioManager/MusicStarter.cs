public class MusicStarter
{
    private AudioManager _manager;
    private AudioDB _audioDB;

    private string _musicCategoryName;
    private bool _loop = true;

    public MusicStarter(AudioManager manager, AudioDB audioDB, string category, bool loop) 
    {
        _manager = manager;
        _audioDB = audioDB;
        _musicCategoryName = category;
        _loop = loop;
    }

    public void Init()
    {
        var clip = _audioDB.GetClip(_musicCategoryName);

        if (clip == null) 
        {
            return;
        }

        _manager.PlayMusic(clip, _loop);
    }

}
