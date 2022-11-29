using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int bulletDamage;

    public LayerMask whatIsEnemies;
    void Start()
    {
        Destroy(transform.parent.gameObject, lifeTime);
    }

    private void Update()
    {
        transform.position += transform.up * speed;
       
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        Enemigo enemigo = collision.gameObject.GetComponent<Enemigo>();
        if (enemigo)
        {
            enemigo.TakeDamage(20);
            Destroy(transform.parent.gameObject);
            
        }
       
    }

    private void BombDamage()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, whatIsEnemies);

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemigo>().TakeDamage(bulletDamage);
        }

        Invoke("Delay", 0.05f);
    }
}
