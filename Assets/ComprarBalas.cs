using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComprarBalas : MonoBehaviour
{
    [SerializeField] GameObject dialogueUI;
    [SerializeField] TextMeshProUGUI textoDelDialogo;
    bool canPress;
    public PuntosPlayer puntosPlayerScript;
    public Arma balasDelJugador;
    public PuntosPlayer txtpuntos;
    public TextMeshProUGUI error;
    public GameObject errorHolder;

    void Start()
    {
        dialogueUI.SetActive(false);
        errorHolder.SetActive(false);
        puntosPlayerScript = FindObjectOfType<PuntosPlayer>();
        balasDelJugador = FindObjectOfType<Arma>();
        txtpuntos = FindObjectOfType<PuntosPlayer>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canPress)
        {
            if (puntosPlayerScript.puntos >= 100 && balasDelJugador.municionActual <= balasDelJugador.municionMaxima - 10)
            {
                puntosPlayerScript.puntos -= 100;
                balasDelJugador.municionActual += 10;
                txtpuntos.txtPuntos.text = puntosPlayerScript.puntos.ToString();
            }
            else if (puntosPlayerScript.puntos >= 100 && balasDelJugador.municionActual > balasDelJugador.municionMaxima - 10)
            {
                //error, sobrepasas la cantidad maxima de municion, mejora la capacidad para comprar mas
                errorHolder.SetActive(true);
                error.text = "Si compras sobrepasaras la cantidad máxima de munición, mejora la capacidad para comprar más";
                Invoke("LimpiarTexto", 3f);
            }
            else
            {
                //error, te faltan puntos
                errorHolder.SetActive(true);
                error.text = "No puedes comprar munición, te faltan puntos";
                Invoke("LimpiarTexto", 3f);
            }
        }
    }
    void OnTriggerEnter(Collider Col)
    {
        dialogueUI.SetActive(true);
        canPress = true;

    }
    void OnTriggerExit(Collider other)
    {
        dialogueUI.SetActive(false);
        canPress = false;

    }

    void LimpiarTexto()
    {
        error.text = "";
        errorHolder.SetActive(false);
    }
}
