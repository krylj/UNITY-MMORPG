using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{

    public GameObject MobPrefab;
    public float SpawnDelay = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawningLoop());
    }


    IEnumerator SpawningLoop()
    {
        while (true)
        {
            Instantiate(MobPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(SpawnDelay);
        }
    }

}
