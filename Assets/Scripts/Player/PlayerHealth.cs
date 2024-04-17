using UnityEngine;

public class PlayerHealth : MonoBehaviour, IExplodable
{
    public void Explode()
    {
        TakeDamage();
    }

    private void TakeDamage() 
    {
        Debug.Log("player exploded");
    }
}
