using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    public GameObject originalObject;
    public Transform[] spawnpoints;
    public float timeBetweenSpawns;
    public int randomPointIndex;
    public int zombiesASpawnear;
    public int ronda;
    

    void Start()
    {
        StartCoroutine(TiempoentreSpawns(timeBetweenSpawns));
    }


    void Update()
    {

        
    }
    public void Instantiate()
    {
        randomPointIndex = Random.Range(0, spawnpoints.Length);
        Instantiate(originalObject,spawnpoints[randomPointIndex].position,Quaternion.identity);
    }
    IEnumerator TiempoentreSpawns(float time)
    {
        while ( zombiesASpawnear <= 9)
        {
            yield return new WaitForSecondsRealtime(time);
            Instantiate();
            zombiesASpawnear ++;
        }
    }
}
