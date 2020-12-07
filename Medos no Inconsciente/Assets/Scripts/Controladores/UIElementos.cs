using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElementos : MonoBehaviour
{
    public Image mira;

    public static UIElementos instancia;

    void Start()
    {
        mira.gameObject.SetActive(false);
        instancia = this;
    }

    void FixedUpdate()
    {
        if(Arma.estaMirando)
            mira.gameObject.SetActive(true);
        else
            mira.gameObject.SetActive(false);
    }
}
