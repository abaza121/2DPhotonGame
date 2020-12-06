using Photon.Pun;
using UnityEngine;
using PhotonNetworkingGame.Managers;
using System.Collections;

namespace PhotonNetworkingGame.Gameplay
{
    public class Player : MonoBehaviourPun
    {
        public bool IsMine;

        [SerializeField]
        private PlayerCollisionHandler playerCollisionHandler;
        [SerializeField]
        private PlayerHealth playerHealth;
        [SerializeField]
        private PlayerMotor playerMotor;

        void Start()
        {
            this.IsMine = base.photonView.IsMine;
            if(base.photonView.IsMine)
            {
                this.playerHealth.PlayerDead += OnPlayerDead;
            }

            if(PhotonNetwork.IsMasterClient)
            {
                this.playerCollisionHandler.PlayerCollidedWithAnotherPlayer += this.playerHealth.TakeDamage;
                playerHealth.ResetHealth();
            }

            this.playerHealth.PlayerDead += GameplayManager.Instance.PlayerDeathHandler.OnPlayerDead;
            playerMotor.IsMine = base.photonView.IsMine;
            playerMotor.Initialize();
        }

        void OnPlayerDead(Vector3 position)
        {
            Respawn();
        }

        private void OnDestroy()
        {
            if (this.IsMine)
            {
                this.playerHealth.PlayerDead -= OnPlayerDead;
            }

            if (PhotonNetwork.IsMasterClient)
            {
                this.playerCollisionHandler.PlayerCollidedWithAnotherPlayer -= this.playerHealth.TakeDamage;
            }
        }

        private void Respawn()
        {
            this.transform.position = GameplayManager.Instance.SpawnPositionPicker.GetRandomPosition();
            playerHealth.ResetHealth();
        }
    }
}
