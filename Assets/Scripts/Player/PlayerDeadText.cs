using UnityEngine;

public class PlayerDeadText : MonoBehaviour
{
    [SerializeField] private GameObject TextObject;

    private void Awake()
    {
        TextObject.SetActive(false);
    }

    public void Activate() 
    {
        TextObject.SetActive(true);
    }
}
