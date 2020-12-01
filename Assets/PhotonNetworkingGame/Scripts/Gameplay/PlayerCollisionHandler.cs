using System;
using UnityEngine;

namespace PhotonNetworkingGame.Gameplay
{
    public class PlayerCollisionHandler : MonoBehaviour
    {
        public event Action PlayerCollidedWithAnotherPlayer;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Player")
            {
                PlayerCollidedWithAnotherPlayer?.Invoke();
            }
        }
    }
}
