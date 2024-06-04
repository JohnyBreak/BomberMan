using UnityEngine;
using Zenject;

public class SceneStarter : MonoBehaviour
{
    private Transition _screen;

    [Inject]
    private void Construct(Transition screen) 
    {
        _screen = screen;
    }

    void Start()
    {
        _screen.FadeOut();
    }
}
