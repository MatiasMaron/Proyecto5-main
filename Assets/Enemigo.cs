﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;   

public class Enemigo : MonoBehaviour
{
    bool alreadyHit = false;
    public float enemyHealth = 100;
    public float absolutEnemyHealth;
    public NavMeshAgent agent;
    public Animator animator;
    public PuntosPlayer puntosplayerscript;
	public GameObject cientifico;
    public static int enemigosCurados;
    public static int enemigosCuradosDos;
    public static int puntosCurado = 50;
    public static int puntosHit = 10;
    public AudioSource audioS;
    public AudioClip sonidoAtaque;
    public AudioClip sonidoZombie;
    public bool pegando;

    public bool spawneando = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Esperar(3));
        puntosplayerscript = FindObjectOfType<PuntosPlayer>();
        audioS = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            DestroyEnemy();
            enemigosCuradosDos++;
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        absolutEnemyHealth = Mathf.Clamp(enemyHealth, 0, 100);
        if (absolutEnemyHealth == 0 && alreadyHit == false)
        {
            Invoke(nameof(DestroyEnemy), 0.2f);
            puntosplayerscript.SumarPuntos(puntosCurado);
            alreadyHit = true;
            enemigosCurados++;
            enemigosCuradosDos++;
        }
        else
        {
            animator.SetTrigger("Hit");
            StartCoroutine(Esperar(1    ));
            puntosplayerscript.SumarPuntos(puntosHit);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
        SpawnCientifico();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "FPSController")
        {
            animator.SetTrigger("Pegar");

            if(!pegando)
            {
                audioS.clip = sonidoAtaque;
                audioS.PlayDelayed(0.2f);
            }

        }
    }

    IEnumerator Esperar(float time)
    {
        
        agent.speed = 0;
        yield return new WaitForSeconds(time);
        
        agent.speed = 3.5f;

    }
    void SpawnCientifico()
    {
        GameObject clone = Instantiate(cientifico, transform.position, transform.rotation);
        Destroy(clone, 8f);
    }

    void SonidoZombieDelayed()
    {
        audioS.PlayOneShot(sonidoZombie);
        new WaitForSeconds(3);
    }

    public void SonidoAtaque()
    {
        audioS.clip = sonidoAtaque;
        audioS.PlayDelayed(0.2f);
    }
}
