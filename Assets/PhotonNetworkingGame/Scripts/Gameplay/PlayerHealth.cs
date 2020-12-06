using Photon.Pun;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace PhotonNetworkingGame.Gameplay
{
    public class PlayerHealth : MonoBehaviourPun
    {
        public event Action<Vector3> PlayerDead;

        [SerializeField]
        private int initialHealthPoints = 3;

        [SerializeField]
        private Slider healthSlider;

        private int currentHealthPoints;

        private float timeSinceLastHit;
        private float damageCooldown = 0.5f;
        private bool isInCooldown;

        private void Update()
        {
            if(isInCooldown == false)
            {
                return;
            }

            if (timeSinceLastHit < damageCooldown)
            {
                timeSinceLastHit += Time.deltaTime;
            }
            else
            {
                timeSinceLastHit = 0;
                isInCooldown = false;
            }
        }

        public void ResetHealth()
        {
            base.photonView.RPC("RPC_ResetHealth", RpcTarget.All);
        }

        public void TakeDamage()
        {
            base.photonView.RPC("RPC_TakeDamage", RpcTarget.All);
        }

        public void TakeDamageFromEnemy()
        {
            base.photonView.RPC("RPC_TakeDamageFromEnemy", RpcTarget.All);
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
            isInCooldown = true;

            if (currentHealthPoints == 0)
            {
                PlayerDead?.Invoke(this.transform.position);
            }
        }

        [PunRPC]
        public void RPC_TakeDamageFromEnemy()
        {
            if (isInCooldown)
            {
                return;
            }

            Debug.Log("Forced damage from enemy");
            currentHealthPoints--;
            healthSlider.value = currentHealthPoints;

            if (currentHealthPoints == 0)
            {
                PlayerDead?.Invoke(this.transform.position);
            }
        }
    }
}
