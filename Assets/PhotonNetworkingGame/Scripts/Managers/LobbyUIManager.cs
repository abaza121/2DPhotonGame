using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhotonNetworkingGame.Managers
{
    public class LobbyUIManager : MonoBehaviour
    {
        [SerializeField]
        private GameLobbyManager gameLobbyManager;

        [SerializeField]
        private TextMeshProUGUI statusLabel;
        [SerializeField]
        private TextMeshProUGUI connectedMessageLabel;
        [SerializeField]
        private TextMeshProUGUI connectedPlayersCountLabel;
        [SerializeField]
        private GameObject connectedPanel;
        [SerializeField]
        private Button startGameButton;
        [SerializeField]
        private GameObject joinedRoomPanel;

        public void UpdateUIbasedOnGameConnectionStatus(GameConnectionStatus gameConnectionStatus)
        {
            if (connectedPanel == null)
            {
                return;
            }

            connectedPanel.SetActive(gameConnectionStatus == GameConnectionStatus.Connected);
            joinedRoomPanel.SetActive(gameConnectionStatus == GameConnectionStatus.RoomJoined);
            startGameButton.interactable = PhotonNetwork.LocalPlayer.IsMasterClient;
            this.UpdateStatusLabel(gameConnectionStatus);
        }

        public void UpdateMessageLabelWithText(string text)
        {
            this.connectedMessageLabel.text = text;
        }

        public void UpdateConnectedCountLabel(byte count)
        {
            this.connectedPlayersCountLabel.text = "Current Connected Players Count: " + count;
        }

        public void OnJoinRoomButtonPressed()
        {
            gameLobbyManager.JoinRoom();
        }

        public void OnStartGameButtonPressed()
        {
            gameLobbyManager.StartGame();
        }

        private void UpdateStatusLabel(GameConnectionStatus gameConnectionStatus)
        {
            this.statusLabel.text = "Current State: " + gameConnectionStatus.ToString();
        }
    }

    public enum GameConnectionStatus
    {
        Disconnected,
        Connected,
        RoomJoined
    }
}
