# 2DPhotonGame

A 2D game with multiplayer photon capabilities.

# most important classes implementation details

# class: Player
Controls the Input and player network entity, Player health and collision detection is only computed on the master client.

# class: GameplayManager
Responsible for networked entities creation and spawning position assignment from SpawnPositionPicker.

# class: GameLobbyManager
Handlers room joining and networked scene loading.
