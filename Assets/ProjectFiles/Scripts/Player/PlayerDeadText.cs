using UnityEngine;
using Zenject;

public class PlayerDeadText : MonoBehaviour
{
    [SerializeField] private GameObject TextObject;
    
    
    private bool _activated = false;

    

    private void Awake()
    {
        TextObject.SetActive(false);
        _activated = false;
    }

    public void Activate() 
    {
        if (_activated)
        {
            return;
        }

        TextObject.SetActive(true);

        _activated = true;
    }
}
