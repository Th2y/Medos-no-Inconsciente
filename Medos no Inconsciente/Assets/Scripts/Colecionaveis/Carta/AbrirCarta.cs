using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AbrirCarta : MonoBehaviour
{
    private int num, a = 0, cartasF1;
    private bool apertou = false, leu = false, mus = false, estaLendo = false;
    public Text[] aviso;
    public GameObject panelCartas;
    public Text[] conteudoCartas;
    private float tempo = 2f;
    string[] cartasFase1;
    List<string> lista = new List<string>();
    public string nomeDaCena;
    public AudioSource abriuCarta, fechouCarta;
    private GameObject luz;

    private void Awake()
    {
        nomeDaCena = SceneManager.GetActiveScene().name;

        if (nomeDaCena == "Fase2")
        {
            TextAsset fase1 = (TextAsset)Resources.Load("Txt/CartasFase1");
            cartasFase1 = fase1.text.Split('\n');

            for (int i = 0; i < cartasFase1.Length; i++)
            {
                lista.Add(cartasFase1[i]);
            }
        }
    }

    void Start()
    {
        if(nomeDaCena == "Fase1")
            conteudoCartas[0].text = "15/02/2019 Onde estou?!Não posso ficar aqui! Preciso encontrar minha irmã antes que seja tarde demais...";

        else
        {
            if (!PlayerPrefs.HasKey("CartasF1_1"))
            {
                do
                {
                    if (num == 0)
                    {
                        cartasF1 = Random.Range(0, 4);
                        PlayerPrefs.SetString("CartasF1_1", lista[cartasF1]);
                        conteudoCartas[0].text = PlayerPrefs.GetString("CartasF1_1");
                        lista.RemoveAt(cartasF1);
                    }
                    else if (num == 1)
                    {
                        cartasF1 = Random.Range(0, 3);
                        PlayerPrefs.SetString("CartasF1_2", lista[cartasF1]);
                        conteudoCartas[1].text = PlayerPrefs.GetString("CartasF1_2");
                        lista.RemoveAt(cartasF1);
                    }
                    else if (num == 2)
                    {
                        cartasF1 = Random.Range(0, 2);
                        PlayerPrefs.SetString("CartasF1_3", lista[cartasF1]);
                        conteudoCartas[2].text = PlayerPrefs.GetString("CartasF1_3");
                        lista.RemoveAt(cartasF1);
                    }
                    else if (num == 3)
                    {
                        cartasF1 = Random.Range(0, 1);
                        PlayerPrefs.SetString("CartasF1_4", lista[cartasF1]);
                        conteudoCartas[3].text = PlayerPrefs.GetString("CartasF1_4");
                        lista.RemoveAt(cartasF1);
                    }
                    else if (num == 4)
                    {
                        PlayerPrefs.SetString("CartasF1_5", lista[0]);
                        conteudoCartas[4].text = PlayerPrefs.GetString("CartasF1_5");
                    }
                    num++;
                } while (num < 5);
            }

            else
            {
                do
                {
                    if (num == 0)
                        conteudoCartas[0].text = PlayerPrefs.GetString("CartasF1_1");
                    else if (num == 1)
                        conteudoCartas[1].text = PlayerPrefs.GetString("CartasF1_2");
                    else if (num == 2)
                        conteudoCartas[2].text = PlayerPrefs.GetString("CartasF1_3");
                    else if (num == 3)
                        conteudoCartas[3].text = PlayerPrefs.GetString("CartasF1_4");
                    else if (num == 4)
                        conteudoCartas[4].text = PlayerPrefs.GetString("CartasF1_5");

                    num++;
                } while (num < 5);
            }
        }        

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
            if(nomeDaCena == "Fase1")
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
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    conteudoCartas[i].gameObject.SetActive(false);
                }

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
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Carta"))
        {
            aviso[0].gameObject.SetActive(true);
            estaLendo = true;
            luz = other.gameObject;
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

            if(nomeDaCena != "Menu" && nomeDaCena != "Carregamento")
                conteudoCartas[0].gameObject.SetActive(true);
            else
            {
                if (a == 0)
                {
                    conteudoCartas[0].gameObject.SetActive(true);
                    PlayerPrefs.SetString("PegouCarta1", "Sim");
                }
                else if (a == 1)
                {
                    conteudoCartas[1].gameObject.SetActive(true);
                    PlayerPrefs.SetString("PegouCarta2", "Sim");
                }
                else if (a == 2)
                {
                    conteudoCartas[2].gameObject.SetActive(true);
                    PlayerPrefs.SetString("PegouCarta3", "Sim");
                }
                else if (a == 3)
                {
                    conteudoCartas[3].gameObject.SetActive(true);
                    PlayerPrefs.SetString("PegouCarta4", "Sim");
                }
                else if (a == 4)
                {
                    conteudoCartas[4].gameObject.SetActive(true);
                    PlayerPrefs.SetString("PegouCarta5", "Sim");
                }
            }
            
            estaLendo = false;

            Time.timeScale = 0f;
            a++;
            mus = true;
            LuzCarta.instancia.ApagarCarta();
        }

        if (tempo <= 0f || apertou)
        {
            aviso[0].gameObject.SetActive(false);
            tempo = 2f;
        }
    }
}