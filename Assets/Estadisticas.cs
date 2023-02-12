using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Estadisticas : MonoBehaviour
{
    public GameObject menuEstadistica;
    public Image menuUno;
    public Image menuDos;
    public GameObject txtEstadisticas;
    public GameObject txtDaño;
    public GameObject txtMunicion;
    public GameObject txtEnemigosCurados;
    public TextMeshProUGUI txtEnemigosCur;

    void Start()
    {
        menuUno.enabled = false;
        menuDos.enabled = false;
        txtEstadisticas.SetActive(false);
        txtDaño.SetActive(false);
        txtMunicion.SetActive(false);
        txtEnemigosCurados.SetActive(false);
    }


    void Update()
    {
        txtEnemigosCur.text = "Enemigos curados: " + Enemigo.enemigosCuradosDos.ToString();
        if (Input.GetKey(KeyCode.Tab))
        {
            menuUno.enabled = true;
            menuDos.enabled = true;
            txtEstadisticas.SetActive(true);
            txtDaño.SetActive(true);
            txtMunicion.SetActive(true);
            txtEnemigosCurados.SetActive(true);

        }
        else
        {
            menuUno.enabled = false;
            menuDos.enabled = false;
            txtEstadisticas.SetActive(false);
            txtDaño.SetActive(false);
            txtMunicion.SetActive(false);
            txtEnemigosCurados.SetActive(false);
        }
    }
}
