    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VidaPlayer : MonoBehaviour
{
    public TextMeshProUGUI vidaUI;
    public int vidaActual;
    public int vidaMaxima;
    public Image barraVida;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        vidaUI.text = vidaActual.ToString() + "/" + vidaMaxima.ToString();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Enemy")
        {
            
        }
    }
    public void GetHurt()
    {
      vidaActual --;
      barraVida.fillAmount = vidaActual / vidaMaxima;
        if (vidaActual <= 0)
        {
            //cambio de escena
        }
    }
}
