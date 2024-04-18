using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] Portal _portal;
    [SerializeField] private DestructionTarget[] _targets;

    private int currentTargetsCount;

    private void Awake()
    {
        currentTargetsCount = _targets.Length;
    }

    internal void ReduceTargets()
    {
        if (currentTargetsCount <= 0)
        {
            return;
        }
        
        currentTargetsCount--;

        if (currentTargetsCount <= 0) 
        {
            _portal.Enable();
        }

    }
}
