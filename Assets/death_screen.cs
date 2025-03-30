using Mirror;
using UnityEngine;

public class death_screen : NetworkBehaviour
{
    public bool isDead = false;
    public bool PohybKamery;
    public bool PohybHrace;
    // ... (other variables and methods)

    [Command]
    public void CmdRespawn()
    {
        // Reset health on server
        GetComponent<Health>().currentHealth = GetComponent<Health>().maxHealth;

        // Tell all clients to respawn this player
        RpcRespawnPlayer();

        // Reset position on server (example)
        transform.position = NetworkManager.startPositions[Random.Range(0, NetworkManager.startPositions.Count)].position;
    }

    [ClientRpc]
    void RpcRespawnPlayer()
    {
        if (!isLocalPlayer) return;

        // Reset local death state
        isDead = false;

        PohybHrace = true;
        

        // Lock cursor again
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Re-enable camera
        if (PohybKamery != null)
        {
            PohybKamery = true;
        }
    }
}