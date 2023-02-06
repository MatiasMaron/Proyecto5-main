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
    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
        puntosPlayerScript = FindObjectOfType<PuntosPlayer>();
        balasDelJugador = FindObjectOfType<Arma>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canPress)
        {
            if (puntosPlayerScript.puntos >= 100)
            {
                puntosPlayerScript.puntos -= 100;
                balasDelJugador.municionMaxima = 30;
            }
            else
            {
                Debug.Log("No tienes suficientes puntos");
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
}
