using Mirror;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class NetworkController : MonoBehaviour
    {
        [SerializeField] private NetworkManager _networkManager;

        public void StartHost()
        {
            _networkManager.StartHost();
        }

        public void StartClient()
        {
            _networkManager.StartClient();
        }
    }
}
