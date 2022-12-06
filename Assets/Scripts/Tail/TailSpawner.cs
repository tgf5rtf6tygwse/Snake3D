using Mirror;
using UnityEngine;
using System.Collections.Generic;

public class TailSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject tailPrefab;

    public List<GameObject> Tails { get; } = new List<GameObject>();
    public override void OnStartServer()
    {
        Food.ServerOnFoodEaten += AddTail;
    }

    public override void OnStopServer()
    {
        Food.ServerOnFoodEaten -= AddTail;
    }

    private void AddTail(GameObject playerWhoAte)
    {
        if(playerWhoAte != gameObject)
        {
            return;
        }
        GameObject tail = Instantiate(tailPrefab);
        NetworkServer.Spawn(tail, connectionToClient);
    }
}
