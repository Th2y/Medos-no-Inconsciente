using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortaAuto : MonoBehaviour
{
    public GameObject portaAberta, portaFechada;

    public GameObject portaAtual;
    public GameObject inimigo;
    public Text aviso;

    public static bool ganhou;

    private float tempo = 5f;

    public float velocidade = 2f;

    private Vector3 posInicial;
    private int numObjDentro;

    void Start()
    {
        ganhou = false;
        numObjDentro = 0;
        posInicial = portaFechada.transform.localPosition;
        aviso.gameObject.SetActive(false);
    }

    void Update()
    {
        if (portaAtual.name == "PortaAuto")
        {
            if (numObjDentro > 0)
                portaFechada.transform.localPosition = Vector3.Lerp(portaFechada.transform.localPosition, portaAberta.transform.localPosition, velocidade * Time.deltaTime);
            else
                portaFechada.transform.localPosition = Vector3.Lerp(portaFechada.transform.localPosition, posInicial, velocidade * Time.deltaTime);
        }
        else if (portaAtual.name == "PortaChave")
        {
            if (inimigo != null)
            {
                if (numObjDentro > 0 && tempo >= 0)
                {
                    tempo -= Time.deltaTime;
                    aviso.gameObject.SetActive(true);
                }
                else
                    aviso.gameObject.SetActive(false);
            }
            else
            {
                if (numObjDentro > 0)
                {
                    portaFechada.transform.localPosition = Vector3.Lerp(portaFechada.transform.localPosition, portaAberta.transform.localPosition, velocidade * Time.deltaTime);
                    ganhou = true;
                }
                else
                    portaFechada.transform.localPosition = Vector3.Lerp(portaFechada.transform.localPosition, posInicial, velocidade * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            numObjDentro++;
    }

    private void OnTriggerExit(Collider other)
    {
        numObjDentro--;
        if (numObjDentro < 0)
            numObjDentro = 0;
    }
}
