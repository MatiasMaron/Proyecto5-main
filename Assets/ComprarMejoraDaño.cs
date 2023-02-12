using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComprarMejoraDaño : MonoBehaviour
{
    bool canPress;
    public GameObject errorHolder;
    public GameObject textoMejoraD;
    public TextMeshProUGUI error;
    public TextMeshProUGUI textoCostoDaño;
    public TextMeshProUGUI textorandom;
    public PuntosPlayer puntosPlayer;
    public PuntosPlayer txtpuntos;
    public int costoMejoraDaño = 250;

    void Start()
    {
        puntosPlayer = FindObjectOfType<PuntosPlayer>();
        txtpuntos = FindObjectOfType<PuntosPlayer>();
        textoMejoraD.SetActive(false);
        textorandom.text = "Daño: " + Bullet.dañoBala.ToString();
        textoCostoDaño.text = "Pulsa CLICK DERECHO para comprar una mejora de daño Coste" + "[" + costoMejoraDaño + "]";
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canPress)
        {
            if(puntosPlayer.puntos >= costoMejoraDaño)
            {
                puntosPlayer.puntos -= costoMejoraDaño;
                Bullet.dañoBala += 10;
                costoMejoraDaño = costoMejoraDaño * 2;
                textoCostoDaño.text = "Pulsa CLICK DERECHO para comprar una mejora de daño Coste" + "[" + costoMejoraDaño + "]";
                txtpuntos.txtPuntos.text = puntosPlayer.puntos.ToString();
                textorandom.text = "Daño: " + Bullet.dañoBala.ToString(); ;
            }
            else
            {
                //error, te faltan puntos
                errorHolder.SetActive(true);
                error.text = "No puedes comprar esta mejora, te faltan puntos";
                Invoke("LimpiarTexto", 3f);
            }
        }

    }
    void OnTriggerEnter(Collider Col)
    {
        textoMejoraD.SetActive(true);
        canPress = true;

    }

    void OnTriggerExit(Collider other)
    {
        textoMejoraD.SetActive(false);
        canPress = false;

    }

    void LimpiarTexto()
    {
        error.text = "";
        errorHolder.SetActive(false);
    }
}
