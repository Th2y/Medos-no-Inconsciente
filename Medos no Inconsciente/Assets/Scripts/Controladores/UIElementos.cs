using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElementos : MonoBehaviour
{
    public Text municao;
    public Text tempoRecarga;
    public Image mira;

    public Text avisoItem;
    float tempoItemAviso = 1f;
    float tempoAtualItemAviso;
    public static UIElementos instancia;

    void Start()
    {
        mira.gameObject.SetActive(false);
        avisoItem.gameObject.SetActive(false);
        instancia = this;
    }

    void Update()
    {
        municao.text = Arma.instancia.quantidadeBalas.ToString();
        tempoRecarga.text = Arma.mostrarTempoRecarga + "s";

        if(Arma.estaMirando)
            mira.gameObject.SetActive(true);
        else
            mira.gameObject.SetActive(false);

        //Verificar se o Game Object está ativo
        if(avisoItem.gameObject.activeSelf)
        {
            tempoAtualItemAviso += Time.deltaTime;
            if (tempoAtualItemAviso >= tempoItemAviso)
                avisoItem.gameObject.SetActive(false);
        }
    }

    public void MostrarMensagemItem()
    {
        avisoItem.gameObject.SetActive(true);
        tempoAtualItemAviso = 0f;
    }
}
