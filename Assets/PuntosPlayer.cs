using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntosPlayer : MonoBehaviour
{
    public int puntos;
    public TextMeshProUGUI txtPuntos;

    void Start()
    {
        txtPuntos.text = puntos.ToString();
    }


    void Update()
    {
        
    }
    public void SumarPuntos(int val)
    {
        puntos += val;
        txtPuntos.text = puntos.ToString();
    }
}
