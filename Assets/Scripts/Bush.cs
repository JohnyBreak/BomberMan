using UnityEngine;

public class Bush : MonoBehaviour, IExplodable
{
    public void Explode()
    {
       Destroy(gameObject);
    }
}
