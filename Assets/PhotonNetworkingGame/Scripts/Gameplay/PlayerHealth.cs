using Photon.Pun;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace PhotonNetworkingGame.Gameplay
{
    public class PlayerHealth : MonoBehaviourPun
    {
        public event Action PlayerDead;

        [SerializeField]
        private int initialHealthPoints = 3;

        [SerializeField]
        private Slider healthSlider;

        private int currentHealthPoints;

        public void ResetHealth()
        {
            base.photonView.RPC("RPC_ResetHealth", RpcTarget.All);
        }

        public void TakeDamage()
        {
            base.photonView.RPC("RPC_TakeDamage", RpcTarget.All);
        }

        [PunRPC]
        public void RPC_ResetHealth()
        {
            healthSlider.maxValue = initialHealthPoints;
            currentHealthPoints = initialHealthPoints;
            healthSlider.value = currentHealthPoints;
        }

        [PunRPC]
        public void RPC_TakeDamage()
        {
            currentHealthPoints--;
            healthSlider.value = currentHealthPoints;

            if (currentHealthPoints == 0)
            {
                PlayerDead?.Invoke();
            }
        }
    }
}
