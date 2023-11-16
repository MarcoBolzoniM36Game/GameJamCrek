using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficoltà : MonoBehaviour
{
    public GameObject[] spawnPointBlock;
    public GameObject[] spawnPrefabBlock;

    public List<GameObject> instances;
    public RageBarManager rage;

    private void Start()
    {
        instances.Clear();
    }
    private void Update()
    {
        //SpawnPrefabBlock(2);
        //DestroyBlock();
    }
    public void SpawnPrefabBlock(int numSpawn)
    {
        List<GameObject> used = new List<GameObject>();
        used.Clear();
        for (int k = 0; k < numSpawn; k++)
        {
            GameObject prefab = spawnPrefabBlock[Random.Range(0, spawnPrefabBlock.Length)];
            bool exit = false;
            do
            {
                GameObject go = spawnPointBlock[Random.Range(0, spawnPointBlock.Length)];
                if (!used.Contains(go))
                {
                    GameObject inst = Instantiate(prefab, go.transform);
                    used.Add(go);
                    instances.Add(inst);
                    exit = true;
                }
            } while (!exit);
            
        }
        used.Clear();
    }

    public void DestroyBlock()
    {
        if ( rage.currentRage==2000 || rage.currentRage == 0 )
        {
            for (int i = 0; i < instances.Count; i++)
            {
                Destroy(instances[i]);
            }
            instances.Clear();
        }
    }
}
