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
    private string[] cartasFase1Lidas, cartasFase2Lidas, cartasFase3Lidas, cartasFase4Lidas;

    private void Start()
    {
        TextAsset fase1 = (TextAsset)Resources.Load("Txt/CartasFase1");
        cartasFase1Lidas = fase1.text.Split('\n');
        for (int i = 0; i < cartasFase1Lidas.Length; i++)
        {
            lista.Add(cartasFase1Lidas[i]);
        }

        TextAsset fase2 = (TextAsset)Resources.Load("Txt/CartasFase2");
        cartasFase2Lidas = fase2.text.Split('\n');
        for (int i = 0; i < cartasFase2Lidas.Length; i++)
        {
            lista.Add(cartasFase2Lidas[i]);
        }

        TextAsset fase3 = (TextAsset)Resources.Load("Txt/CartasFase3");
        cartasFase3Lidas = fase3.text.Split('\n');
        for (int i = 0; i < cartasFase3Lidas.Length; i++)
        {
            lista.Add(cartasFase3Lidas[i]);
        }

        TextAsset fase4 = (TextAsset)Resources.Load("Txt/CartasFase4");
        cartasFase4Lidas = fase4.text.Split('\n');
        for (int i = 0; i < cartasFase4Lidas.Length; i++)
        {
            lista.Add(cartasFase4Lidas[i]);
        }
    }

    private void Update()
    {
        cartasPegas[0].text = PlayerPrefs.GetString("PegouCarta1");
        cartasPegas[1].text = PlayerPrefs.GetString("PegouCarta2");
        cartasPegas[2].text = PlayerPrefs.GetString("PegouCarta3");
        cartasPegas[3].text = PlayerPrefs.GetString("PegouCarta4");
        cartasPegas[4].text = PlayerPrefs.GetString("PegouCarta5");

        cartasPegas[5].text = PlayerPrefs.GetString("PegouCarta6");
        cartasPegas[6].text = PlayerPrefs.GetString("PegouCarta7");
        cartasPegas[7].text = PlayerPrefs.GetString("PegouCarta8");
        cartasPegas[8].text = PlayerPrefs.GetString("PegouCarta9");
        cartasPegas[9].text = PlayerPrefs.GetString("PegouCarta10");

        cartasPegas[10].text = PlayerPrefs.GetString("PegouCarta11");
        cartasPegas[11].text = PlayerPrefs.GetString("PegouCarta12");
        cartasPegas[12].text = PlayerPrefs.GetString("PegouCarta13");
        cartasPegas[13].text = PlayerPrefs.GetString("PegouCarta14");
        cartasPegas[14].text = PlayerPrefs.GetString("PegouCarta15");

        cartasPegas[15].text = PlayerPrefs.GetString("PegouCarta16");
        cartasPegas[16].text = PlayerPrefs.GetString("PegouCarta17");
        cartasPegas[17].text = PlayerPrefs.GetString("PegouCarta18");
        cartasPegas[18].text = PlayerPrefs.GetString("PegouCarta19");
        cartasPegas[19].text = PlayerPrefs.GetString("PegouCarta20");

        if (cartasPegas[0].text == "Sim")
        {
            cadeado[0].gameObject.SetActive(false);
            carta[0].gameObject.SetActive(true);
            botoesCartas[0].interactable = true;
            cartasPegasLidas[0].text = PlayerPrefs.GetString("CartasF1_1");
        }
        else
        {
            cadeado[0].gameObject.SetActive(true);
            carta[0].gameObject.SetActive(false);
            botoesCartas[0].interactable = false;
        }

        if (cartasPegas[1].text == "Sim")
        {
            cadeado[1].gameObject.SetActive(false);
            carta[1].gameObject.SetActive(true);
            botoesCartas[1].interactable = true;
            cartasPegasLidas[1].text = PlayerPrefs.GetString("CartasF1_2");
        }
        else
        {
            cadeado[1].gameObject.SetActive(true);
            carta[1].gameObject.SetActive(false);
            botoesCartas[1].interactable = false;
        }

        if (cartasPegas[2].text == "Sim")
        {
            cadeado[2].gameObject.SetActive(false);
            carta[2].gameObject.SetActive(true);
            botoesCartas[2].interactable = true;
            cartasPegasLidas[2].text = PlayerPrefs.GetString("CartasF1_3");
        }
        else
        {
            cadeado[2].gameObject.SetActive(true);
            carta[2].gameObject.SetActive(false);
            botoesCartas[2].interactable = false;
        }

        if (cartasPegas[3].text == "Sim")
        {
            cadeado[3].gameObject.SetActive(false);
            carta[3].gameObject.SetActive(true);
            botoesCartas[3].interactable = true;
            cartasPegasLidas[3].text = PlayerPrefs.GetString("CartasF1_4");
        }
        else
        {
            cadeado[3].gameObject.SetActive(true);
            carta[3].gameObject.SetActive(false);
            botoesCartas[3].interactable = false;
        }

        if (cartasPegas[4].text == "Sim")
        {
            cadeado[4].gameObject.SetActive(false);
            carta[4].gameObject.SetActive(true);
            botoesCartas[4].interactable = true;
            cartasPegasLidas[4].text = PlayerPrefs.GetString("CartasF1_5");
        }
        else
        {
            cadeado[4].gameObject.SetActive(true);
            carta[4].gameObject.SetActive(false);
            botoesCartas[4].interactable = false;
        }

        if (cartasPegas[5].text == "Sim")
        {
            cadeado[5].gameObject.SetActive(false);
            carta[5].gameObject.SetActive(true);
            botoesCartas[5].interactable = true;
            cartasPegasLidas[5].text = PlayerPrefs.GetString("CartasF2_1");
        }
        else
        {
            cadeado[5].gameObject.SetActive(true);
            carta[5].gameObject.SetActive(false);
            botoesCartas[5].interactable = false;
        }

        if (cartasPegas[6].text == "Sim")
        {
            cadeado[6].gameObject.SetActive(false);
            carta[6].gameObject.SetActive(true);
            botoesCartas[6].interactable = true;
            cartasPegasLidas[6].text = PlayerPrefs.GetString("CartasF2_2");
        }
        else
        {
            cadeado[6].gameObject.SetActive(true);
            carta[6].gameObject.SetActive(false);
            botoesCartas[6].interactable = false;
        }

        if (cartasPegas[7].text == "Sim")
        {
            cadeado[7].gameObject.SetActive(false);
            carta[7].gameObject.SetActive(true);
            botoesCartas[7].interactable = true;
            cartasPegasLidas[7].text = PlayerPrefs.GetString("CartasF2_3");
        }
        else
        {
            cadeado[7].gameObject.SetActive(true);
            carta[7].gameObject.SetActive(false);
            botoesCartas[7].interactable = false;
        }

        if (cartasPegas[8].text == "Sim")
        {
            cadeado[8].gameObject.SetActive(false);
            carta[8].gameObject.SetActive(true);
            botoesCartas[8].interactable = true;
            cartasPegasLidas[8].text = PlayerPrefs.GetString("CartasF2_4");
        }
        else
        {
            cadeado[8].gameObject.SetActive(true);
            carta[8].gameObject.SetActive(false);
            botoesCartas[8].interactable = false;
        }

        if (cartasPegas[9].text == "Sim")
        {
            cadeado[9].gameObject.SetActive(false);
            carta[9].gameObject.SetActive(true);
            botoesCartas[9].interactable = true;
            cartasPegasLidas[9].text = PlayerPrefs.GetString("CartasF2_5");
        }
        else
        {
            cadeado[9].gameObject.SetActive(true);
            carta[9].gameObject.SetActive(false);
            botoesCartas[9].interactable = false;
        }

        if (cartasPegas[10].text == "Sim")
        {
            cadeado[10].gameObject.SetActive(false);
            carta[10].gameObject.SetActive(true);
            botoesCartas[10].interactable = true;
            cartasPegasLidas[10].text = PlayerPrefs.GetString("CartasF3_1");
        }
        else
        {
            cadeado[10].gameObject.SetActive(true);
            carta[10].gameObject.SetActive(false);
            botoesCartas[10].interactable = false;
        }

        if (cartasPegas[11].text == "Sim")
        {
            cadeado[11].gameObject.SetActive(false);
            carta[11].gameObject.SetActive(true);
            botoesCartas[11].interactable = true;
            cartasPegasLidas[11].text = PlayerPrefs.GetString("CartasF3_2");
        }
        else
        {
            cadeado[12].gameObject.SetActive(true);
            carta[12].gameObject.SetActive(false);
            botoesCartas[12].interactable = false;
        }

        if (cartasPegas[12].text == "Sim")
        {
            cadeado[12].gameObject.SetActive(false);
            carta[12].gameObject.SetActive(true);
            botoesCartas[12].interactable = true;
            cartasPegasLidas[12].text = PlayerPrefs.GetString("CartasF3_3");
        }
        else
        {
            cadeado[12].gameObject.SetActive(true);
            carta[12].gameObject.SetActive(false);
            botoesCartas[12].interactable = false;
        }

        if (cartasPegas[13].text == "Sim")
        {
            cadeado[13].gameObject.SetActive(false);
            carta[13].gameObject.SetActive(true);
            botoesCartas[13].interactable = true;
            cartasPegasLidas[13].text = PlayerPrefs.GetString("CartasF3_4");
        }
        else
        {
            cadeado[13].gameObject.SetActive(true);
            carta[13].gameObject.SetActive(false);
            botoesCartas[13].interactable = false;
        }

        if (cartasPegas[14].text == "Sim")
        {
            cadeado[14].gameObject.SetActive(false);
            carta[14].gameObject.SetActive(true);
            botoesCartas[14].interactable = true;
            cartasPegasLidas[14].text = PlayerPrefs.GetString("CartasF3_5");
        }
        else
        {
            cadeado[14].gameObject.SetActive(true);
            carta[14].gameObject.SetActive(false);
            botoesCartas[14].interactable = false;
        }

        if (cartasPegas[15].text == "Sim")
        {
            cadeado[15].gameObject.SetActive(false);
            carta[15].gameObject.SetActive(true);
            botoesCartas[15].interactable = true;
            cartasPegasLidas[15].text = PlayerPrefs.GetString("CartasF4_1");
        }
        else
        {
            cadeado[15].gameObject.SetActive(true);
            carta[15].gameObject.SetActive(false);
            botoesCartas[15].interactable = false;
        }

        if (cartasPegas[16].text == "Sim")
        {
            cadeado[16].gameObject.SetActive(false);
            carta[16].gameObject.SetActive(true);
            botoesCartas[16].interactable = true;
            cartasPegasLidas[16].text = PlayerPrefs.GetString("CartasF4_2");
        }
        else
        {
            cadeado[16].gameObject.SetActive(true);
            carta[16].gameObject.SetActive(false);
            botoesCartas[16].interactable = false;
        }

        if (cartasPegas[17].text == "Sim")
        {
            cadeado[17].gameObject.SetActive(false);
            carta[17].gameObject.SetActive(true);
            botoesCartas[17].interactable = true;
            cartasPegasLidas[17].text = PlayerPrefs.GetString("CartasF4_3");
        }
        else
        {
            cadeado[17].gameObject.SetActive(true);
            carta[17].gameObject.SetActive(false);
            botoesCartas[17].interactable = false;
        }

        if (cartasPegas[18].text == "Sim")
        {
            cadeado[18].gameObject.SetActive(false);
            carta[18].gameObject.SetActive(true);
            botoesCartas[18].interactable = true;
            cartasPegasLidas[18].text = PlayerPrefs.GetString("CartasF4_4");
        }
        else
        {
            cadeado[18].gameObject.SetActive(true);
            carta[18].gameObject.SetActive(false);
            botoesCartas[18].interactable = false;
        }

        if (cartasPegas[19].text == "Sim")
        {
            cadeado[19].gameObject.SetActive(false);
            carta[19].gameObject.SetActive(true);
            botoesCartas[19].interactable = true;
            cartasPegasLidas[19].text = PlayerPrefs.GetString("CartasF4_5");
        }
        else
        {
            cadeado[19].gameObject.SetActive(true);
            carta[19].gameObject.SetActive(false);
            botoesCartas[19].interactable = false;
        }

        for (int i = 20; i < botoesCartas.Length; i++)
        {
            botoesCartas[i].interactable = false;
            cadeado[i].gameObject.SetActive(true);
            carta[i].gameObject.SetActive(false);
        }
    }
}
