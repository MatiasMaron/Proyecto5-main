using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntosPlayer : MonoBehaviour
{
    public int puntos;
    public TextMeshProUGUI txtPuntos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SumarPuntos(int val)
    {
        puntos += val;
        txtPuntos.text = puntos.ToString();
    }
}
