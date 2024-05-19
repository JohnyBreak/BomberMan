using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneStarter : MonoBehaviour
{
    private TransitionScreen _screen;

    [Inject]
    private void Construct(TransitionScreen screen) 
    {
        _screen = screen;
    }

    void Start()
    {
        _screen.FadeOut();
    }
}
