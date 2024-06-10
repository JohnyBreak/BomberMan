using UnityEngine;
using Zenject;

public class LevelBuilder : MonoBehaviour
{
    private IStorageService _service;

    [Inject]
    private void Construct(IStorageService service)
    {
        _service = service;
    }

    void Start()
    {
        _service.Load<int>("LevelNumber", (level) => 
        {
            Debug.Log(level);
        });
    }
}
