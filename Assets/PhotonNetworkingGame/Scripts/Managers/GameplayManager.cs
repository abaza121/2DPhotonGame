using PhotonNetworkingGame.Gameplay;
using UnityEngine;

namespace PhotonNetworkingGame.Managers
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance
        {
            get;
            set;
        }

        public SpawnPositionPicker SpawnPositionPicker
        {
            get
            {
                return spawnPositionPicker;
            }
        }

        [SerializeField]
        private SpawnPositionPicker spawnPositionPicker;
        [SerializeField]
        private string playerPrefab;

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            Photon.Pun.PhotonNetwork.Instantiate(playerPrefab, spawnPositionPicker.GetPositionForNetworkPlayerId(), Quaternion.identity);
        }
    }
}
