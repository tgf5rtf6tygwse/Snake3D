using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class GameOverHandler : NetworkBehaviour
{
    private List<PlayerName> players = new List<PlayerName>();
    public static event Action<string> ClientOnGameOver;

    public override void OnStartServer()
    {
        PlayerSnake.ServerOnPlayerSpawned += ServerHandlePlayerSpawned;
        PlayerSnake.ServerOnPlayerDespawned += ServerHandlePlayerDespawned;
    }

    public override void OnStopServer()
    {
        PlayerSnake.ServerOnPlayerSpawned -= ServerHandlePlayerSpawned;
        PlayerSnake.ServerOnPlayerDespawned -= ServerHandlePlayerDespawned;
    }

    private void ServerHandlePlayerSpawned(PlayerName player)
    {
        players.Add(player);
    }

    private void ServerHandlePlayerDespawned(PlayerName player)
    {
        players.Remove(player);
        if (players.Count != 1) return;
        RPCGameOver(players[0].Name);
    }

    [ClientRpc]
    private void RPCGameOver(string winner)
    {
        ClientOnGameOver?.Invoke(winner);
    }
}
