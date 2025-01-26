using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
public class NetworkManagerLobby : NetworkManager
{   
    [Scene] [SerializeField] private string menuScene = string.Empty;
    [Header("Room")]
    [SerializeField] private NetworkManagerLobby roomPlayerPrefab = null;

    public static event Action OnClientConnected;
    public static event Action OnPlayerDisconnected;
    public override void OnStartServer() => spawnPrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs").ToList();
    // Start is called before the first frame update
    public override void OnStartClient()
    {
        var spawnPrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs");

        foreach (var prefab in spawnPrefabs){
            NetworkClient.RegisterPrefab(prefab);
        }
    }
    public override void OnClientConnect()
    {
        base.OnClientConnect();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
