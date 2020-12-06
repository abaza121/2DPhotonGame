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

        public PlayerDeathHandler PlayerDeathHandler
        {
            get
            {
                return playerDeathHandler;
            }
        }

        [SerializeField]
        private SpawnPositionPicker spawnPositionPicker;
        [SerializeField]
        private PlayerDeathHandler playerDeathHandler;
        [SerializeField]
        private string playerPrefab;

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            Photon.Pun.PhotonNetwork.Instantiate(playerPrefab, spawnPositionPicker.GetRandomPosition(), Quaternion.identity);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
