using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class Food : NetworkBehaviour
{
    [SerializeField] GameObject particlePrefab;
    public static event Action<GameObject> ServerOnFoodEaten;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        NetworkServer.Destroy(gameObject);
        ServerParticles();
        ServerOnFoodEaten?.Invoke(other.gameObject);
    }
    [ServerCallback]
    private void ServerParticles()
    {
        GameObject boom = Instantiate
            (particlePrefab, transform.position, particlePrefab.transform.rotation);
        NetworkServer.Spawn(boom);
        StartCoroutine(DestroyOnServer(boom, 3f));
    }
    IEnumerator DestroyOnServer(GameObject gameObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        NetworkServer.Destroy(gameObject);

    }
}
