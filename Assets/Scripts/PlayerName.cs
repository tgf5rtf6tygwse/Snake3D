using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class PlayerName : NetworkBehaviour
{
    [SerializeField] private TMP_Text playerNameText;
    [SyncVar(hook = nameof(HandlePlayerNameUpdated))] private string playerName;

    public override void OnStartServer()
    {
        playerName = $"Player {connectionToClient.connectionId}";
    }
    private void HandlePlayerNameUpdated(string oldName, string newName)
    {
        playerNameText.text = newName;
    }

}
