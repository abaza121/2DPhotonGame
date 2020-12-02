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
            if (base.photonView.IsMine)
            {
                this.playerCollisionHandler.PlayerCollidedWithAnotherPlayer += this.playerHealth.TakeDamage;
                this.playerHealth.PlayerDead += OnPlayerDead;
                playerHealth.ResetHealth();
            }

            playerMotor.IsMine = base.photonView.IsMine;
            playerMotor.Initialize();
        }

        void OnPlayerDead()
        {
            Respawn();
        }

        private void Respawn()
        {
            this.transform.position = GameplayManager.Instance.SpawnPositionPicker.GetRandomPosition();
            playerHealth.ResetHealth();
        }
    }
}
