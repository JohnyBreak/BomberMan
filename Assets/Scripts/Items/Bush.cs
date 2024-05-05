using UnityEngine;
using Zenject;

public class Bush : MonoBehaviour, IExplodable
{
    private PlayerScore _score;

    [Inject]
    private void Construct(PlayerScore score)
    {
        _score = score;
    }

    public void Explode()
    {
        _score.Increase(10);

       Destroy(gameObject);
    }
}
