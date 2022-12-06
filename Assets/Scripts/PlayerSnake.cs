using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class PlayerSnake : NetworkBehaviour
{
    [SerializeField] private TailSpawner spawner;
    [SerializeField] private PlayerName playerName;
    public static event Action<PlayerName> ServerOnPlayerSpawned;
    public static event Action<PlayerName> ServerOnPlayerDespawned;

    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out NetworkIdentity identity) && identity.connectionToClient == connectionToClient) return;
        switch (other.tag)
        {
            case "Border":
            case "Player":
            case "Tail":
                DestroySelf();
                break;

        }
    }

    public override void OnStartServer()
    {
        ServerOnPlayerSpawned?.Invoke(playerName);
    }

    private void DestroySelf()
    {
        ServerOnPlayerDespawned?.Invoke(playerName);
        foreach (var tail in spawner.Tails)
        {
            NetworkServer.Destroy(tail);
        }
        NetworkServer.Destroy(gameObject);
    }
}
