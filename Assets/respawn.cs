using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class NetworkRespawnButton : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnRespawnClicked);
    }

    void OnRespawnClicked()
    {
        var localPlayer = NetworkClient.localPlayer;
        if (localPlayer != null)
        {
            var deathScreen = localPlayer.GetComponent<death_screen>();
            if (deathScreen != null)
            {
                // Call the respawn command on the player's death screen component
                deathScreen.CmdRespawn();
            }
        }
    }
}
