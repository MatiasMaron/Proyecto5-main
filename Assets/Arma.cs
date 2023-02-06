using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Arma : MonoBehaviour
{
    public GameObject bala;
    public Transform spawnBala;
    public float enfriamiento;
    public float precision;
    float enfriamientoActual;
    public int municionActual;
    public int municion;
    public int municionMaxima;
    public int cargador;
    public TextMeshProUGUI balasUI;
    public GameObject nobalasUI;
    public float tiempoRecarga;
    public float tiempoRecargaActual;
    public Image barraRecarga;
    public GameObject barraRecargaImagen;



    void Start()
    {
        nobalasUI.SetActive(false);
        enfriamientoActual = enfriamiento;
        tiempoRecargaActual = tiempoRecarga;
    }

    void Update()
    {
        if (tiempoRecargaActual < tiempoRecarga)
        {
            tiempoRecargaActual += Time.deltaTime;
            barraRecargaImagen.SetActive(true);
            barraRecarga.fillAmount = tiempoRecargaActual / tiempoRecarga;
        }
        if (tiempoRecargaActual >= tiempoRecarga)
        {
            barraRecargaImagen.SetActive(false);
        }

        if (enfriamientoActual > 0)
        {
            enfriamientoActual -= Time.deltaTime;
        }

        if (Input.GetMouseButton(0) && enfriamientoActual <= 0 && tiempoRecargaActual >= tiempoRecarga)
        {
            if(municion > 0)
            {
                DispararYDescontarbalas();
            }
            else
            {
                Recargar();
            }
        }

        balasUI.text = municion.ToString() + "/" + municionActual.ToString();

        if (Input.GetKey(KeyCode.R))
        {
            Recargar();
        }

    }

    void Recargar()
    {
        int balasgastadas = cargador - municion;

        if (municionActual < balasgastadas)
        {
            nobalasUI.SetActive(true);
        }
        else
        {
            municionActual -= balasgastadas;
            municion += balasgastadas;
            tiempoRecargaActual = 0;
            nobalasUI.SetActive(false);
        }
    }

    void DispararYDescontarbalas()
    {
        var Bala = Instantiate(bala, spawnBala.position, spawnBala.rotation);
        Bala.transform.forward = Camera.main.transform.forward;
        enfriamientoActual = enfriamiento;
        municion--;
    }

}
