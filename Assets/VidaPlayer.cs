    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VidaPlayer : MonoBehaviour
{
    public TextMeshProUGUI vidaUI;
    public float vidaActual;
    public float vidaMaxima;
    public float regeneracion = 0.01f;
    public Image barraVida;
    public PantallaDaño pantalla;
    public AudioSource audioS;
    public AudioClip sonidoDaño;


    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }


    void Update()
    {
        vidaActual = Mathf.Clamp(vidaActual, 0, 100);
        vidaUI.text = ((int)vidaActual).ToString() + "/" + vidaMaxima.ToString();
        barraVida.fillAmount = vidaActual / vidaMaxima;

        if(vidaActual <= vidaMaxima)
        {
            vidaActual += regeneracion;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Enemy")
        {
            
        }
    }
    public void HacerDaño()
    {
      vidaActual -=5;
      audioS.PlayOneShot(sonidoDaño);
      pantalla.UpdateDamage(1 - (vidaActual / vidaMaxima));
        if (vidaActual <= 0)
        {
            //cambio de escena
        }
    }
}
