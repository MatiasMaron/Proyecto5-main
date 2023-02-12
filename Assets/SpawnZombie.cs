using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnZombie : MonoBehaviour
{
    public GameObject originalObject;
    public Transform[] spawnpoints;
    public float timeBetweenSpawns;
    public int randomPointIndex;
    public int zombiesSpawn;
    int zombiesASpawnear = 1;
    public TextMeshProUGUI textoRondas;
    public TextMeshProUGUI enemigosCuradosText;
    public TextMeshProUGUI enemigosVivos;
    int ronda = 1;
    

    void Start()
    {
        StartCoroutine(TiempoentreSpawns(timeBetweenSpawns));
        textoRondas.text = "Ronda: " + ronda;
    }

    // ARREGLAR PROBLEMA DE LAS RONDAS (LA RONDA 2 ES LA 1 Y ASI SUCESIVAMENTE)
    void Update()
    {
        enemigosVivos.text = "Zombies: " + (zombiesSpawn - Enemigo.enemigosCurados);
        enemigosCuradosText.text = "Enemigos curados: " + Enemigo.enemigosCurados;

        if (ronda < 1000 && ((zombiesASpawnear + 1) - Enemigo.enemigosCurados) == 0)
        {
          zombiesASpawnear += 2;
          Enemigo.enemigosCurados = 0;
          ronda ++;
          textoRondas.text = "Ronda: " + ronda;
          zombiesSpawn = 0;
          StartCoroutine(TiempoentreSpawns(timeBetweenSpawns));
        }

        if(ronda == 5)
        {

        }

        
    }
    public void Instantiate()
    {
        randomPointIndex = Random.Range(0, spawnpoints.Length);
        Instantiate(originalObject,spawnpoints[randomPointIndex].position,Quaternion.identity);
    }
    IEnumerator TiempoentreSpawns(float time)
    {
        while ( zombiesSpawn <= zombiesASpawnear)
        {
            yield return new WaitForSecondsRealtime(time);
            Instantiate();
            zombiesSpawn ++;
        }
    }
}
