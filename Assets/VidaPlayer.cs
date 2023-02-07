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
    public Image barraVida;
    public PantallaDaño pantalla;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vidaUI.text = vidaActual.ToString() + "/" + vidaMaxima.ToString();
        barraVida.fillAmount = vidaActual / vidaMaxima;
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
      pantalla.UpdateDamage(1 - (vidaActual / vidaMaxima));
        if (vidaActual <= 0)
        {
            //cambio de escena
        }
    }
}
