using Mirror;
using UnityEngine;

public class TailNetwork : NetworkBehaviour
{
    [SyncVar] private Snake owner;
    [SyncVar] private GameObject target;

    public Snake Owner
    {
        get { return owner; }
        set { owner = value; } 
    }

    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }

    public override void OnStartServer()
    {
        owner = connectionToClient.identity.GetComponent<Snake>();
        var tails = owner.GetComponent<TailSpawner>().Tails;
        target = tails.Count == 0? owner.gameObject : tails[tails.Count -1];
        tails.Add(gameObject);
    }
}
