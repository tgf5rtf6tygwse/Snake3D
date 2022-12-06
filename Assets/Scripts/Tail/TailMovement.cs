using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class TailMovement : NetworkBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private TailNetwork tail;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = tail.Target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = tail.Owner.Speed;
        agent.SetDestination(tail.Target.transform.position);
    }
}
