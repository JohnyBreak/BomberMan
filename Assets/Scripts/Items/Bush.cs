using UnityEngine;

public class Bush : MonoBehaviour, IExplodable
{
    [SerializeField] private PlayerScore _score;

    public void Explode()
    {
        _score.Increase(10);

       Destroy(gameObject);
    }
}
