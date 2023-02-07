using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantallaDaño : MonoBehaviour
{
    public Image bloodEffectImage;
    public float a;
    public Color color;
    
    void Start()
    {
        a = bloodEffectImage.color.a;
        color = bloodEffectImage.color;
    }


    void Update()
    {
        a = Mathf.Clamp(a, 0, 1f);

        
    }

    public void UpdateDamage(float damage)
    {
        Debug.Log(damage);
        color.a = damage;
        bloodEffectImage.color = color;
    }
}
