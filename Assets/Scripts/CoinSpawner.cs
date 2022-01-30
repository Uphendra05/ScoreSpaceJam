using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinSpawner : MonoBehaviour
{
    public List <GameObject> spawnPoints = new List<GameObject>();
    public GameObject coinPrefab;
    public float spawnTime;
    public float destroyTime;
    public System.Random randInd = new System.Random();
    void Start()
    {
        StartCoroutine(CoinSpawnWait());
        
    }

    
    void Update()
    {
        
    }


    public void SpawnCoins()
    {
        
        int randomInd = randInd.Next(0, spawnPoints.Count);
        GameObject temp =  Instantiate(coinPrefab, spawnPoints[randomInd].transform.position, Quaternion.identity);
        Destroy(temp, destroyTime);

    }

    IEnumerator CoinSpawnWait()
    {
        yield return new WaitForSeconds(spawnTime);
        SpawnCoins();
        yield return new WaitForSeconds(destroyTime);
        StartCoroutine(CoinSpawnWait());
    }
}
