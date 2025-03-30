using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class NetworkQuitButton : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnQuitClicked);
    }

    void OnQuitClicked()
    {
        var networkManager = NetworkManager.singleton;

        if (NetworkServer.active && NetworkClient.isConnected)
        {
            networkManager.StopHost();
        }
        else if (NetworkClient.isConnected)
        {
            networkManager.StopClient();
        }
        else
        {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}