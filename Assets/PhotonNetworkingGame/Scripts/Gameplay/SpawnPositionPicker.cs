using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhotonNetworkingGame.Gameplay
{
    public class SpawnPositionPicker : MonoBehaviour
    {
        [SerializeField]
        private Transform[] spawnPoints;

        public Vector3 GetPositionForNetworkPlayerId()
        {
            return spawnPoints[PhotonNetwork.LocalPlayer.ActorNumber % spawnPoints.Length].position;
        }

        public Vector3 GetRandomPosition()
        {
            return spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        }
    }
}
