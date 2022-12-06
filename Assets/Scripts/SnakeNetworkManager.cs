using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SnakeNetworkManager : NetworkManager
{
    [SerializeField] private GameObject foodspawner;
    [SerializeField] private GameObject gameOverHandlerPrafab;
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        if(numPlayers == 2)
        {
            var spawner = Instantiate(foodspawner);
            NetworkServer.Spawn(spawner);
        }
    }

    public override void OnStartServer()
    {
        NetworkServer.Spawn(Instantiate(gameOverHandlerPrafab));
    }

}
