using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFistString : MonoBehaviour
{
    bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController" && !hit)
        {            
            other.gameObject.GetComponent<VidaPlayer>().GetHurt();
            StartCoroutine(Esperar());
        }
    }

 
    IEnumerator Esperar()
    {

        hit = true;
        yield return new WaitForSeconds(1);
        hit = false;
    }


}
