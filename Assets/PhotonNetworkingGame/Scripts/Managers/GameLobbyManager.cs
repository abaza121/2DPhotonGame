using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace PhotonNetworkingGame.Managers
{
    public class GameLobbyManager : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private LobbyUIManager lobbyUIManager;

        // Start is called before the first frame update
        void Start()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = Application.version;
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnected()
        {
            lobbyUIManager.UpdateUIbasedOnGameConnectionStatus(GameConnectionStatus.Connected);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log("Game Disconnected due to " + cause.ToString());
            lobbyUIManager.UpdateUIbasedOnGameConnectionStatus(GameConnectionStatus.Disconnected);
        }

        public override void OnJoinedRoom()
        {
            lobbyUIManager.UpdateUIbasedOnGameConnectionStatus(GameConnectionStatus.RoomJoined);
            lobbyUIManager.UpdateMessageLabelWithText(string.Empty);
            lobbyUIManager.UpdateConnectedCountLabel(PhotonNetwork.CurrentRoom.PlayerCount);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            base.OnJoinRoomFailed(returnCode, message);
            lobbyUIManager.UpdateMessageLabelWithText("Failed to join room with reason: " + message);
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            lobbyUIManager.UpdateConnectedCountLabel(PhotonNetwork.CurrentRoom.PlayerCount);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            lobbyUIManager.UpdateConnectedCountLabel(PhotonNetwork.CurrentRoom.PlayerCount);
        }

        public void JoinRoom()
        {
            var roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 3;
            PhotonNetwork.JoinOrCreateRoom("defaultRoom", roomOptions, TypedLobby.Default);
        }

        public void StartGame()
        {
            PhotonNetwork.LoadLevel(1);
        }
    }
}
