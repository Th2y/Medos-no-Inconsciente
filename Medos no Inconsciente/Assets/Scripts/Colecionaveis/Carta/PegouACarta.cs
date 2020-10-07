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

    private void Update()
    {
        string[] cartasFase1Lidas = File.ReadAllLines("Assets\\Txt\\CartasFase1.txt");
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
            botoesCartas[0].interactable = true;
            cartasPegasLidas[0].text = cartasFase1Lidas[0];
        }
        else
            botoesCartas[0].interactable = false;

        if (cartasPegas[0].text == lista[1] || cartasPegas[1].text == lista[1] || cartasPegas[2].text == lista[1] || cartasPegas[3].text == lista[1] || cartasPegas[4].text == lista[1])
        { 
            botoesCartas[1].interactable = true;
            cartasPegasLidas[1].text = cartasFase1Lidas[1];
        }
        else
            botoesCartas[1].interactable = false;

        if (cartasPegas[0].text == lista[2] || cartasPegas[1].text == lista[2] || cartasPegas[2].text == lista[2] || cartasPegas[3].text == lista[2] || cartasPegas[4].text == lista[2])
        { 
            botoesCartas[2].interactable = true;
            cartasPegasLidas[2].text = cartasFase1Lidas[2];
        }
        else
            botoesCartas[2].interactable = false;

        if (cartasPegas[0].text == lista[3] || cartasPegas[1].text == lista[3] || cartasPegas[2].text == lista[3] || cartasPegas[3].text == lista[3] || cartasPegas[4].text == lista[3])
        { 
            botoesCartas[3].interactable = true;
            cartasPegasLidas[3].text = cartasFase1Lidas[3];
        }
        else
            botoesCartas[3].interactable = false;

        if (cartasPegas[0].text == lista[4] || cartasPegas[1].text == lista[4] || cartasPegas[2].text == lista[4] || cartasPegas[3].text == lista[4] || cartasPegas[4].text == lista[4])
        { 
            botoesCartas[4].interactable = true;
            cartasPegasLidas[4].text = cartasFase1Lidas[4];
        }
        else
            botoesCartas[4].interactable = false;

    }
}
