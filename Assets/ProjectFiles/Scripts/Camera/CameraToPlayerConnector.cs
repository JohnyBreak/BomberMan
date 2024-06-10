using Cinemachine;
using UnityEngine;
using Zenject;

public class CameraToPlayerConnector : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    [Inject]
    private void Construct(PlayerProvider provider) 
    {
        Player player = provider.GetPlayer();

        if (player == null)
        {
            provider.OnPlayerSetted += (newPlayer) =>
            {
                _virtualCamera.Follow = newPlayer.transform;
            };
            return;
        }

        _virtualCamera.Follow = player.transform;
    }
    
}
