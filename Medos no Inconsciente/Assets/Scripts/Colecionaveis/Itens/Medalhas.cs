using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medalhas : MonoBehaviour
{
    public GameObject[] medalhas;
    public static bool terminou = false;
    public Text quantidadeMoedas;
    private int moedas;
    private int moedasGanhas = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Moedas"))
            moedas = PlayerPrefs.GetInt("Moedas");
        else
            moedas = 0;

        for(int i = 0; i < medalhas.Length; i++)
        {
            medalhas[i].SetActive(false);
        }
    }

    void Update()
    {
        if (terminou)
        {
            Terminou();
            terminou = false;
        }
    }

    void Terminou()
    {
        if (Arma.balasUsadas >= 10)
        {
            moedasGanhas = Random.Range(5, 9);
            moedas += moedasGanhas;
            PlayerPrefs.SetInt("Moedas", moedas);
            medalhas[2].SetActive(true);
            medalhas[5].SetActive(true);
            PlayerPrefs.SetString("Medalha1_3", "Sim");
        }
        else if (Arma.balasUsadas > 5)
        {
            moedasGanhas = Random.Range(10, 14);
            moedas += moedasGanhas;
            PlayerPrefs.SetInt("Moedas", moedas);
            medalhas[1].SetActive(true);
            medalhas[4].SetActive(true);
            PlayerPrefs.SetString("Medalha1_2", "Sim");
        }
        else
        {
            moedasGanhas = Random.Range(15, 20);
            moedas += moedasGanhas;
            PlayerPrefs.SetInt("Moedas", moedas);
            medalhas[0].SetActive(true);
            medalhas[3].SetActive(true);
            PlayerPrefs.SetString("Medalha1_1", "Sim");
        }

        quantidadeMoedas.text = moedasGanhas.ToString();
    }
}
