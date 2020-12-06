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

        public Vector3 GetRandomPosition()
        {
            if(PhotonNetwork.LocalPlayer.ActorNumber == 0)
            return spawnPoints[Random.Range(0, 3)].position;
            else if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
            return spawnPoints[Random.Range(3, 6)].position;
            else if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
            return spawnPoints[Random.Range(6, 9)].position;
            else
            return spawnPoints[Random.Range(0, 9)].position;
        }
    }
}
