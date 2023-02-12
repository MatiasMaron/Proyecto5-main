using System.Collections;
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

    public bool spawneando = true;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Esperar(3));
        puntosplayerscript = FindObjectOfType<PuntosPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        absolutEnemyHealth = Mathf.Clamp(enemyHealth, 0, 100);
        if (absolutEnemyHealth == 0 && alreadyHit == false)
        {
            Invoke(nameof(DestroyEnemy), 0.2f);
            puntosplayerscript.SumarPuntos(50);
            alreadyHit = true;
            enemigosCurados++;
            enemigosCuradosDos++;
        }
        else
        {
            animator.SetTrigger("Hit");
            StartCoroutine(Esperar(1    ));
            puntosplayerscript.SumarPuntos(10);
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
     Instantiate(cientifico, transform.position, transform.rotation);
	}
}
