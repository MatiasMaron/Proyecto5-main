using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn = null;
    public float cooldown;
    public float inacuracy;
    float currcooldown;
    public int MaxAmo;
    public int currentAmo;
    public int cargador;
    public TextMeshProUGUI balasUI;
    public float reloadTime;
    public float currReloadTime;

    

    void Start()
    {
        currcooldown = cooldown;
        currReloadTime = reloadTime;
               
    }
    void Update()
    {
        if(currReloadTime < reloadTime)
        {
          currReloadTime += Time.deltaTime;
        }

        if (currReloadTime >= reloadTime)
        {

        }
       
        if (currcooldown > 0)
        {
            currcooldown -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && currcooldown <= 0 && currReloadTime >= reloadTime )
        {

            if (currentAmo > 0)
            {
              DistaraYDescuentaBalas();

            }
            else
            {
                Recargar();

            }
        }

        
        
        balasUI.text = currentAmo.ToString()+"/"+MaxAmo.ToString();
        if (Input.GetKey(KeyCode.R))
        {
            Recargar();
        }
               
        
    }
    void DistaraYDescuentaBalas()
    {
        var b = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        b.transform.forward = Camera.main.transform.forward;
        currcooldown = cooldown;
        currentAmo--;
    }
    void Recargar()
    {
        int balasfaltantes = cargador - currentAmo;
        if (MaxAmo < balasfaltantes){
        }
        else
        {
            MaxAmo -= balasfaltantes;
            currentAmo += balasfaltantes;
            currReloadTime = 0;
        }
    }

}
    
    

