using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ComprarMejoraMunicion : MonoBehaviour
{

    bool canPress;
    bool puntosReload;
    public PuntosPlayer puntosPlayer;
    public PuntosPlayer txtpuntos;
    public Arma balasDelJugador;
    public GameObject errorHolder;
    public GameObject textoMejora;
    public TextMeshProUGUI error;
    public TextMeshProUGUI textoMunicion;
    public TextMeshProUGUI textoMunicionMax;
    public int costoMejoraMunicion = 250;


    void Start()
    {
        puntosPlayer = FindObjectOfType<PuntosPlayer>();
        balasDelJugador = FindObjectOfType<Arma>();
        textoMejora.SetActive(false);
        txtpuntos = FindObjectOfType<PuntosPlayer>();
        textoMunicionMax.text = "Munición máxima: " + balasDelJugador.municionMaxima;
        textoMunicion.text = "Pulsa CLICK DERECHO para comprar una mejora de municion maxima Coste" + "[" + costoMejoraMunicion + "]";
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canPress)
        {
            if (puntosPlayer.puntos >= costoMejoraMunicion)
            {
                puntosPlayer.puntos -= costoMejoraMunicion;
                balasDelJugador.municionMaxima += 10;
                costoMejoraMunicion = costoMejoraMunicion * 2;
                textoMunicion.text = "Pulsa CLICK DERECHO para comprar una mejora de municion maxima Coste" + "[" + costoMejoraMunicion + "]";
                txtpuntos.txtPuntos.text = puntosPlayer.puntos.ToString();
                textoMunicionMax.text = "Munición máxima: " + balasDelJugador.municionMaxima;
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
        textoMejora.SetActive(true);
        canPress = true;

    }

    void OnTriggerExit(Collider other)
    {
        textoMejora.SetActive(false);
        canPress = false;

    }

    void LimpiarTexto()
    {
        error.text = "";
        errorHolder.SetActive(false);
    }
}
