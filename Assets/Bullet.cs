using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int bulletDamage;
    public static int dañoBala = 20;

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
            enemigo.TakeDamage(dañoBala);
            Destroy(transform.parent.gameObject);
            
        }
       
    }


}
