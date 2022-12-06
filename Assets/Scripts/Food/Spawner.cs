using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Spawner : NetworkBehaviour
{
    [SerializeField] private GameObject foodspawner;
    public override void OnStartServer()
    {
        var spawner = Instantiate(foodspawner);
        NetworkServer.Spawn(spawner);
    }
}
