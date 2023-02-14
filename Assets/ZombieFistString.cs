using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFistString : MonoBehaviour
{
    bool pegar = false;

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
        if (other.gameObject.name == "FPSController" && !pegar)
        {            
            other.gameObject.GetComponent<VidaPlayer>().HacerDaño();
        }
    }

 
    IEnumerator Esperar()
    {

        pegar = true;
        yield return new WaitForSeconds(1);
        pegar = false;
    }


}
