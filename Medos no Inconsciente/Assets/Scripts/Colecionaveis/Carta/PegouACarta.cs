using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PegouACarta : MonoBehaviour
{
    public Text[] cartasPegas;
    public Text[] cartasPegasLidas;
    public Button[] botoesCartas;
    List<string> lista = new List<string>();
    public Image[] cadeado;
    public Image[] carta;
    private string[] cartasFase1Lidas;

    private void Update()
    {
        TextAsset fase1 = (TextAsset)Resources.Load("Txt/CartasFase1");
        cartasFase1Lidas = fase1.text.Split('\n');

        for (int i = 0; i < cartasFase1Lidas.Length; i++)
        {
            lista.Add(cartasFase1Lidas[i]);
        }
        cartasPegas[0].text = PlayerPrefs.GetString("PegouCarta1");
        cartasPegas[1].text = PlayerPrefs.GetString("PegouCarta2");
        cartasPegas[2].text = PlayerPrefs.GetString("PegouCarta3");
        cartasPegas[3].text = PlayerPrefs.GetString("PegouCarta4");
        cartasPegas[4].text = PlayerPrefs.GetString("PegouCarta5");

        if (cartasPegas[0].text == lista[0] || cartasPegas[1].text == lista[0] || cartasPegas[2].text == lista[0] || cartasPegas[3].text == lista[0] || cartasPegas[4].text == lista[0])
        {
            cadeado[0].gameObject.SetActive(false);
            carta[0].gameObject.SetActive(true);
            botoesCartas[0].interactable = true;
            cartasPegasLidas[0].text = cartasFase1Lidas[0];
        }
        else
        {
            cadeado[0].gameObject.SetActive(true);
            carta[0].gameObject.SetActive(false);
            botoesCartas[0].interactable = false;
        }

        if (cartasPegas[0].text == lista[1] || cartasPegas[1].text == lista[1] || cartasPegas[2].text == lista[1] || cartasPegas[3].text == lista[1] || cartasPegas[4].text == lista[1])
        {
            cadeado[1].gameObject.SetActive(false);
            carta[1].gameObject.SetActive(true);
            botoesCartas[1].interactable = true;
            cartasPegasLidas[1].text = cartasFase1Lidas[1];
        }
        else
        {
            cadeado[1].gameObject.SetActive(true);
            carta[1].gameObject.SetActive(false);
            botoesCartas[1].interactable = false;
        }

        if (cartasPegas[0].text == lista[2] || cartasPegas[1].text == lista[2] || cartasPegas[2].text == lista[2] || cartasPegas[3].text == lista[2] || cartasPegas[4].text == lista[2])
        {
            cadeado[2].gameObject.SetActive(false);
            carta[2].gameObject.SetActive(true);
            botoesCartas[2].interactable = true;
            cartasPegasLidas[2].text = cartasFase1Lidas[2];
        }
        else
        {
            cadeado[2].gameObject.SetActive(true);
            carta[2].gameObject.SetActive(false);
            botoesCartas[2].interactable = false;
        }

        if (cartasPegas[0].text == lista[3] || cartasPegas[1].text == lista[3] || cartasPegas[2].text == lista[3] || cartasPegas[3].text == lista[3] || cartasPegas[4].text == lista[3])
        {
            cadeado[3].gameObject.SetActive(false);
            carta[3].gameObject.SetActive(true);
            botoesCartas[3].interactable = true;
            cartasPegasLidas[3].text = cartasFase1Lidas[3];
        }
        else
        {
            cadeado[3].gameObject.SetActive(true);
            carta[3].gameObject.SetActive(false);
            botoesCartas[3].interactable = false;
        }

        if (cartasPegas[0].text == lista[4] || cartasPegas[1].text == lista[4] || cartasPegas[2].text == lista[4] || cartasPegas[3].text == lista[4] || cartasPegas[4].text == lista[4])
        {
            cadeado[4].gameObject.SetActive(false);
            carta[4].gameObject.SetActive(true);
            botoesCartas[4].interactable = true;
            cartasPegasLidas[4].text = cartasFase1Lidas[4];
        }
        else
        {
            cadeado[4].gameObject.SetActive(true);
            carta[4].gameObject.SetActive(false);
            botoesCartas[4].interactable = false;
        }

        for(int i = 5; i < botoesCartas.Length; i++)
        {
            botoesCartas[i].interactable = false;
            cadeado[i].gameObject.SetActive(true);
            carta[i].gameObject.SetActive(false);
        }

    }
}
