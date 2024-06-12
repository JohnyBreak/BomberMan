using UnityEngine;
using Zenject;

public class GameRunner : MonoBehaviour
{
    [SerializeField] private BootStrap _bootStrap;

    private DiContainer _container;

    [Inject]
    private void Construct(DiContainer container)
    {
        _container = container;
    }

    private void Awake()
    {
        var result = FindObjectOfType<BootStrap>();

        if(result != null) 
        {
            Destroy(this.gameObject);
            return;
        }

        _container.InstantiatePrefab(_bootStrap);
        //Instantiate(_bootStrap);
    }
}
