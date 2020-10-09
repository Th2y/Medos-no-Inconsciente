using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class AbrirCarta : MonoBehaviour
{
    int num;
    int cartas1;
    bool apertou = false;
    bool leu = false;
    bool mus = false;
    public bool[] leuLinha;
    public Text[] aviso;
    public GameObject panelCartas;
    public Text conteudoCartas;
    bool estaLendo = false;
    public float tempo = 5f;
    string[] cartasFase1;
    List<string> lista = new List<string>();
    public string nomeDaCena;
    public AudioSource abriuCarta, fechouCarta;

    void Start()
    {
        nomeDaCena = SceneManager.GetActiveScene().name;

        TextAsset fase1 = (TextAsset)Resources.Load("Txt/CartasFase1");
        cartasFase1 = fase1.text.Split('\n');

        for(int i = 0; i < cartasFase1.Length; i++)
        {
            lista.Add(cartasFase1[i]);
        }

        leuLinha = new bool[5];

        aviso[0].gameObject.SetActive(false);
        aviso[1].gameObject.SetActive(false);
        panelCartas.SetActive(false);
    }

    void Update()
    {
        if (estaLendo)
        {
            tempo -= Time.deltaTime;
            Ler();
        }
        if (Input.GetButtonDown("Fire2") && mus)
        {
            fechouCarta.Play();
            leu = true;
            apertou = false;
            estaLendo = false;            
            panelCartas.SetActive(false);
            aviso[1].gameObject.SetActive(false);
            Time.timeScale = 1f;
            mus = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Carta"))
        {
            aviso[0].gameObject.SetActive(true);
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

    public void Ler()
    {
        if ((Input.GetKeyUp(KeyCode.F) && tempo >= 0f))
        {
            abriuCarta.Play();
            leu = false;
            apertou = true;
            panelCartas.SetActive(true);
            aviso[1].gameObject.SetActive(true);
            cartas1 = Random.Range(0, lista.Count);

            conteudoCartas.text = lista[cartas1];
            if (num == 0)
                PlayerPrefs.SetString("PegouCarta1", conteudoCartas.text);
            else if (num == 1)
                PlayerPrefs.SetString("PegouCarta2", conteudoCartas.text);
            else if (num == 2)
                PlayerPrefs.SetString("PegouCarta3", conteudoCartas.text);
            else if (num == 3)
                PlayerPrefs.SetString("PegouCarta4", conteudoCartas.text);
            else if (num == 4)
                PlayerPrefs.SetString("PegouCarta5", conteudoCartas.text);

            leuLinha[cartas1] = true;
            estaLendo = false;
            if (lista.Count > 0)
                lista.RemoveAt(cartas1);

            Time.timeScale = 0f;
            num++;
            mus = true;
        }

        if (tempo <= 0f || apertou)
        {
            aviso[0].gameObject.SetActive(false);
            tempo = 5f;
        }
    }
}