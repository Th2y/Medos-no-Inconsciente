using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject panelCartas;
    [SerializeField] private Text[] conteudoCartas;
    [SerializeField] private Text[] aviso;
    [SerializeField] private AudioSource abriuCarta, fechouCarta;
    [SerializeField] private GameObject[] colisor;
    [SerializeField] private Collider col1;
    private int a = 0;
    private bool apertou = false, leu = false, mus = false, estaLendo = true, iniciou = true, ultima = false;

    private void Start()
    {
        Ler1();
    }

    void Update()
    {
        if(a==1 && iniciou)
            Time.timeScale = 0f;

        if (estaLendo)
            Ler();

        if (Input.GetButtonDown("Fire2") && mus)
        {
            fechouCarta.Play();
            leu = true;
            apertou = false;
            estaLendo = false;
            panelCartas.SetActive(false);
            aviso[1].gameObject.SetActive(false);
            aviso[2].gameObject.SetActive(false);
            if(!ultima)
                aviso[3].gameObject.SetActive(true);
            else
                aviso[3].gameObject.SetActive(false);
            Time.timeScale = 1f;
            mus = false;
            AcabouLeitura();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Carta"))
        {
            aviso[0].gameObject.SetActive(true);
            aviso[3].gameObject.SetActive(false);
            estaLendo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (leu)
        {
            Collider col = other.gameObject.GetComponent<Collider>();
            Destroy(col);
        }
    }

    private void Ler1()
    {
        Time.timeScale = 0f;
        abriuCarta.Play();
        leu = false;
        apertou = true;
        panelCartas.SetActive(true);
        aviso[2].gameObject.SetActive(true);
        conteudoCartas[0].gameObject.SetActive(true);
        estaLendo = false;
        a++;
        mus = true;
    }

    private void Ler()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            abriuCarta.Play();
            leu = false;
            apertou = true;
            panelCartas.SetActive(true);
            aviso[1].gameObject.SetActive(true);
            
            if (a == 1)
                conteudoCartas[1].gameObject.SetActive(true);
            else if (a == 2)
                conteudoCartas[2].gameObject.SetActive(true);
            else if (a == 3)
                conteudoCartas[3].gameObject.SetActive(true);
            else if (a == 4)
            {
                conteudoCartas[4].gameObject.SetActive(true);
                ultima = true;
            }
            else if (a == 5)
                conteudoCartas[5].gameObject.SetActive(true);

            estaLendo = false;

            Time.timeScale = 0f;
            a++;
            mus = true;
            LuzCarta.instancia.ApagarCarta();
        }

        if (apertou)
            aviso[0].gameObject.SetActive(false);
    }

    private void AcabouLeitura()
    {
        if (a == 1)
        {
            iniciou = false;
            conteudoCartas[0].gameObject.SetActive(false);
            Destroy(col1);
        }
        else if (a == 2)
        {
            conteudoCartas[1].gameObject.SetActive(false);
            Destroy(colisor[0]);
        }
        else if (a == 3)
        {
            conteudoCartas[2].gameObject.SetActive(false);
            Destroy(colisor[1]);
        }
        else if (a == 4)
        {
            conteudoCartas[3].gameObject.SetActive(false);
            Destroy(colisor[2]);
        }
        else if (a == 5)
        {
            conteudoCartas[4].gameObject.SetActive(false);
            Destroy(colisor[3]);
        }
    }
}
