using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using Unity.IO.LowLevel.Unsafe;
using System.Text;
using UnityEngine;

public class DB : MonoBehaviour
{

    public string filePath = "gameData.txt";
    private string fileContent;
    private StreamWriter streamWriter;
    private StreamReader streamReader;

    void Start()
    {
        streamWriter = new StreamWriter(filePath);
        streamReader = new StreamReader(filePath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnAplicationQuit()
    {
        streamWriter.Close();
    }
}
