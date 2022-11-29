using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AparecerLetrasEnPantalla : MonoBehaviour
{
    [SerializeField] GameObject dialogueUI;
    [SerializeField] TextMeshProUGUI textoDelDialogo;

    bool canPress;
    public PuntosPlayer puntosPlayerScript;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
        puntosPlayerScript = FindObjectOfType<PuntosPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPress)
        {
            if (puntosPlayerScript.puntos >= 1000)
            {
                SceneManager.LoadScene("Ganaste");

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
    void OnTriggerStay(Collider other)
    {


    }
    void OnTriggerExit(Collider other)
    {
        dialogueUI.SetActive(false);
        canPress = false;

    }
}
