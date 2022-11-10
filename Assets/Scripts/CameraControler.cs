using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraControler : NetworkBehaviour
{
    [SerializeField] private GameObject cam;

    public override void OnStartAuthority()
    {
        cam.SetActive(true);
    }
}
