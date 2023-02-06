using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    public GameObject originalObject;
    public Transform[] spawnpoints;
    public float timeBetweenSpawns;
    public int randomPointIndex;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TiempoentreSpawns(timeBetweenSpawns));
    }

    // Update is called once per frame
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
        int instanciado = 0;
        while ( instanciado <= 9)
        {
            yield return new WaitForSecondsRealtime(time);
            Instantiate();
            instanciado ++;
        }
    }
}
