using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelSystem
{
    private Portal _portal;
    private List<DestructionTarget> _targets = new();

    private int currentTargetsCount;

    [Inject]
    private void Construct(Portal portal) 
    {
        _portal = portal;
    }

    public void RegisterDestructable(DestructionTarget target) 
    {
        _targets.Add(target);
        currentTargetsCount = _targets.Count;
    }

    internal void ReduceTargets()
    {
        if (currentTargetsCount <= 0)
        {
            return;
        }
        
        currentTargetsCount--;
        Debug.LogError(currentTargetsCount);
        if (currentTargetsCount <= 0) 
        {
            GameObject.FindObjectOfType<Portal>(true).Enable();
        }

    }
}
